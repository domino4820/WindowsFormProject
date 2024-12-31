using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using LauncherGames.BLL.Services.Interface;
using LauncherGames.DAL.Models;
using Microsoft.Extensions.DependencyInjection;

namespace LauncherGames
{
    public partial class GameForm : Form
    {
        private readonly string gameName;
        private readonly string gameImage;
        private readonly decimal gamePrice;
        private readonly string downloadPath;
        private readonly string runPath;
        private readonly bool isPurchased;
        private readonly bool isInstalled;
        private readonly int gameId;
        private readonly int userId;
        private readonly string description;
        private string installationPath; // Removed the readonly modifier
        private readonly IUserGameDetailsService _userGameDetailsService;
        private readonly IPurchaseService _purchaseService;
        private readonly IServiceProvider _serviceProvider;

        private string gameDirectory;
        private bool isDownloading = false;

        public GameForm(int userId, string gameName, string gameImage, decimal gamePrice, string downloadPath, string runPath, string description, bool isPurchased, bool isInstalled, int gameId, string installationPath, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            this.gameName = gameName;
            this.gameImage = gameImage;
            this.gamePrice = gamePrice;
            this.downloadPath = downloadPath;
            this.runPath = runPath;
            this.isPurchased = isPurchased;
            this.isInstalled = isInstalled;
            this.gameId = gameId;
            this.description = description;
            this.userId = userId;
            this.installationPath = installationPath;
            _serviceProvider = serviceProvider;
            _userGameDetailsService = _serviceProvider.GetRequiredService<IUserGameDetailsService>();
            _purchaseService = _serviceProvider.GetRequiredService<IPurchaseService>();
        }

        private async void GameForm_Load_1(object sender, EventArgs e)
        {
            lblGameName.Text = gameName;
            picBoxGame.ImageLocation = gameImage;
            lblPrice.Text = gamePrice == 0 ? "Free" : $"{gamePrice:C}";
            txtGameDescription.Text = description;

            var gameDetails = await _userGameDetailsService.GetUserGameDetailsAsync(userId, gameId);
            if (gameDetails != null)
            {
                bool isGamePurchased = gameDetails.IsPurchased;
                bool isGameInstalled = gameDetails.IsInstalled;

                btnPurchase.Visible = !isGamePurchased;
                btnInstall.Visible = isGamePurchased && !isGameInstalled;
                btnPlay.Visible = isGameInstalled;
            }
            else
            {
                btnPurchase.Visible = !isPurchased;
                btnInstall.Visible = isPurchased && !isInstalled;
                btnPlay.Visible = isInstalled;
            }

            await UpdateButtonState(userId, gameId);
        }

        private async void btnPurchase_Click(object sender, EventArgs e)
        {
            if (userId <= 0)
            {
                MessageBox.Show("Invalid user ID.", "Error");
                return;
            }

            bool success = await _purchaseService.BuyGameAsync(userId, gameId);

            if (success)
            {
                var userGameDetails = await _userGameDetailsService.GetUserGameDetailsAsync(userId, gameId);
                if (userGameDetails != null)
                {
                    userGameDetails.IsPurchased = true;
                    await _userGameDetailsService.UpdateUserGameDetailsAsync(userGameDetails);
                }
                else
                {
                    await _userGameDetailsService.AddUserGameDetailsAsync(new UserGameDetail
                    {
                        UserId = userId,
                        GameId = gameId,
                        IsPurchased = true,
                        IsInstalled = false
                    });
                }

                MessageBox.Show("Mua game thành công!", "Thông báo");
                await UpdateButtonState(userId, gameId);
            }
            else
            {
                MessageBox.Show("Không đủ số dư để mua game.", "Lỗi");
            }
        }

        private async void btnInstall_Click(object sender, EventArgs e)
        {
            if (isDownloading)
            {
                MessageBox.Show("Đang tải xuống, vui lòng đợi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string downloadPath = (await _userGameDetailsService.GetUserGameDetailsAsync(userId, gameId))?.DownloadPath ?? string.Empty;
            if (string.IsNullOrEmpty(downloadPath))
            {
                MessageBox.Show("Không tìm thấy đường dẫn tải xuống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Chọn thư mục để lưu game";
                folderDialog.ShowNewFolderButton = true;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    gameDirectory = folderDialog.SelectedPath;
                    isDownloading = true;

                    using (ProgressForm progressForm = new ProgressForm(downloadPath))
                    {
                        progressForm.SavePath = Path.Combine(gameDirectory, $"{gameId}.zip");
                        progressForm.Show();

                        await DownloadAndInstallGame(downloadPath, gameDirectory, progressForm);
                    }
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn thư mục lưu.");
                }
            }
        }

        private async Task DownloadAndInstallGame(string downloadUrl, string saveDirectory, ProgressForm progressForm)
        {
            string savePath = Path.Combine(saveDirectory, $"{gameId}.zip");

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage response = await client.GetAsync(downloadUrl, HttpCompletionOption.ResponseHeadersRead))
                    {
                        response.EnsureSuccessStatusCode();

                        using (Stream contentStream = await response.Content.ReadAsStreamAsync(), fileStream = new FileStream(savePath, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true))
                        {
                            var totalBytes = response.Content.Headers.ContentLength;
                            var totalBytesRead = 0L;
                            var buffer = new byte[8192];
                            var bytesRead = 0;

                            while ((bytesRead = await contentStream.ReadAsync(buffer)) != 0)
                            {
                                await fileStream.WriteAsync(buffer.AsMemory(0, bytesRead));
                                totalBytesRead += bytesRead;

                                if (totalBytes.HasValue)
                                {
                                    var progress = (int)((totalBytesRead * 100) / totalBytes.Value);
                                    progressForm.UpdateProgress(progress);
                                }
                            }
                        }
                    }
                }
                if (savePath.EndsWith(".zip"))
                {
                    ZipFile.ExtractToDirectory(savePath, saveDirectory);
                    File.Delete(savePath);
                }

                var userGameDetails = await _userGameDetailsService.GetUserGameDetailsAsync(userId, gameId);
                if (userGameDetails != null)
                {
                    userGameDetails.IsInstalled = true;
                    userGameDetails.InstallationPath = saveDirectory;
                    await _userGameDetailsService.UpdateUserGameDetailsAsync(userGameDetails);
                }

                // Cập nhật trạng thái các nút và đường dẫn cài đặt ngay sau khi cài đặt
                installationPath = saveDirectory;
                await UpdateButtonState(userId, gameId);
                MessageBox.Show("Tải xuống và cài đặt thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnPlay.Visible = true; // Hiển thị nút Play ngay sau khi cài đặt thành công
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isDownloading = false;
                progressForm.Close();
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            PlayGame();
        }

        private void PlayGame()
        {
            string exePath = Path.Combine(installationPath, $"{gameName}/{gameName}.exe");

            if (File.Exists(exePath))
            {
                string logMessage = $"User {userId} play {gameName} (ID: {gameId}) from {exePath} at {DateTime.Now}";
                WriteLog(logMessage);

                try
                {
                    Process.Start(exePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi khi mở game: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy file thực thi. Vui lòng kiểm tra lại cài đặt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void WriteLog(string message)
        {
            string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs", "gamePlayLog.txt");
            Directory.CreateDirectory(Path.GetDirectoryName(logFilePath));

            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine(message);
            }
        }

        private async Task UpdateButtonState(int userId, int gameId)
        {
            var gameDetails = await _userGameDetailsService.GetUserGameDetailsAsync(userId, gameId);

            if (gameDetails == null)
            {
                btnPurchase.Visible = true;
                btnInstall.Visible = false;
                btnPlay.Visible = false;
            }
            else if (gameDetails.IsPurchased && !gameDetails.IsInstalled)
            {
                btnPurchase.Visible = false;
                btnInstall.Visible = true;
                btnPlay.Visible = false;
            }
            else if (gameDetails.IsPurchased && gameDetails.IsInstalled)
            {
                btnPurchase.Visible = false;
                btnInstall.Visible = false;
                btnPlay.Visible = true;
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa game này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                string gameDirectoryPath = Path.Combine(installationPath, gameName);

                try
                {
                    if (Directory.Exists(gameDirectoryPath))
                    {
                        DeleteDirectoryContents(gameDirectoryPath);
                        Directory.Delete(gameDirectoryPath, true);

                        var userGameDetails = await _userGameDetailsService.GetUserGameDetailsAsync(userId, gameId);
                        if (userGameDetails != null)
                        {
                            userGameDetails.IsInstalled = false;
                            userGameDetails.InstallationPath = null;
                            await _userGameDetailsService.UpdateUserGameDetailsAsync(userGameDetails);
                        }

                        UpdatePlayButtonToInstall();
                        MessageBox.Show("Game đã được xóa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thư mục game không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi khi xóa game: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DeleteDirectoryContents(string directoryPath)
        {
            try
            {
                foreach (var file in Directory.GetFiles(directoryPath))
                {
                    File.SetAttributes(file, FileAttributes.Normal);
                    File.Delete(file);
                }

                foreach (var subDirectory in Directory.GetDirectories(directoryPath))
                {
                    DeleteDirectoryContents(subDirectory);
                    Directory.Delete(subDirectory);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa nội dung thư mục: {directoryPath}\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdatePlayButtonToInstall()
        {
            btnInstall.Visible = true;
            btnPlay.Visible = false;
            btnInstall.Text = "Cài đặt";
            btnInstall.Click -= btnPlay_Click;
            btnInstall.Click += btnInstall_Click;
        }
    }
}