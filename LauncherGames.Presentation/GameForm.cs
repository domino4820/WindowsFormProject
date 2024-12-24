using System;
using System.Diagnostics;
using System.IO.Compression;
using System.Windows.Forms;
using LauncherGames.BLL;
using LauncherGames.DAL;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic.ApplicationServices;
using NLog;

namespace LauncherGames.Presentation
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
        private int currentUserId;
        private readonly string description;
        private UserDAL userDAL;
        private string gameDirectory;
        private bool isDownloading = false;
        private GameManager gameManager;
        private UserGameDetailsDAL userGameDetailsDAL;
        private int userId;
        private string InstallationPath;

        public GameForm(int userId, string gameName, string gameImage, decimal gamePrice, string downloadPath, string runPath, string description, bool isPurchased, bool isInstalled, int gameId, string installationPath)
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
            this.InstallationPath = installationPath;
            userDAL = new UserDAL();
            gameManager = new GameManager();
            userGameDetailsDAL = new UserGameDetailsDAL();
            //gameManager.DownloadCompleted += OnDownloadCompleted;
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            // Initialize the form with game details
            lblGameName.Text = gameName;
            picBoxGame.ImageLocation = gameImage;
            lblPrice.Text = gamePrice == 0 ? "Free" : $"{gamePrice:C}";
            txtGameDescription.Text = description;

            // Check if the game is purchased by the user
            var gameDetails = userGameDetailsDAL.GetUserGameDetails(userId, gameId);
            if (gameDetails != null)
            {
                // Use local variables instead of readonly fields
                bool isGamePurchased = gameDetails.IsPurchased;
                bool isGameInstalled = gameDetails.IsInstalled;

                // Update button visibility based on game status
                btnPurchase.Visible = !isGamePurchased;
                btnInstall.Visible = isGamePurchased && !isGameInstalled;
                btnPlay.Visible = isGameInstalled;
            }
            else
            {
                // Update button visibility based on game status
                btnPurchase.Visible = !isPurchased;
                btnInstall.Visible = isPurchased && !isInstalled;
                btnPlay.Visible = isInstalled;
            }

            UpdateButtonState(userId, gameId);
        }




        private void btnPurchase_Click(object sender, EventArgs e)
        {
            if (userId <= 0)
            {
                MessageBox.Show("Invalid user ID.", "Error");
                return;
            }

            PurchaseBLL purchaseBLL = new PurchaseBLL();
            bool success = purchaseBLL.BuyGame(userId, gameId);

            if (success)
            {
                // Mark the game as purchased for the user
                userGameDetailsDAL.MarkGameAsPurchased(userId, gameId);

                MessageBox.Show("Mua game thành công!", "Thông báo");
                UpdateButtonState(userId, gameId);
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

            string downloadPath = UserGameDetailsDAL.GetDownloadPath(userId, gameId);
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
                InstallationPath = saveDirectory;
                UserGameDetailsDAL.SetGameInstalled(userId, gameId, saveDirectory, true);

                UpdateButtonState(userId, gameId);
                MessageBox.Show("Tải xuống và cài đặt thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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



        //private void OnDownloadCompleted()
        //{
        //    isDownloading = false;
        //    InstallationPath = gameDirectory;
        //    UpdateButtonState(userId, gameId);
        //    MessageBox.Show($"Tải xuống và giải nén thành công! Game đã được lưu tại: {InstallationPath}");
        //}



        private void btnPlay_Click(object sender, EventArgs e)
        {
            PlayGame();
        }

        private void PlayGame()
        {
            string gameDirectoryPath = Path.Combine(InstallationPath);

            string exePath = Path.Combine(gameDirectoryPath, $"{gameName}/{gameName}.exe");

            if (File.Exists(exePath))
            {
                string logMessage = $"User {userId} play {gameName} (ID: {gameId}) from {exePath} at {DateTime.Now}";
                WriteLog(logMessage);

                try
                {
                    System.Diagnostics.Process.Start(exePath);
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


        //private void DeductBalance(decimal amount)
        //{
        //    decimal currentBalance = userDAL.GetUserBalance(currentUserId);
        //    if (currentBalance >= amount)
        //    {
        //        userDAL.UpdateUserBalance(currentUserId, currentBalance - amount);
        //    }
        //    else
        //    {
        //        // Handle insufficient balance case
        //        MessageBox.Show("Insufficient balance to complete the purchase.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private bool UserHasSufficientBalance(decimal price)
        //{
        //    decimal currentBalance = userDAL.GetUserBalance(currentUserId);
        //    return currentBalance >= price;
        //}

        private void UpdateButtonState(int userId, int gameId)
        {
            UserGameDetailsDAL userGameDetailsDAL = new UserGameDetailsDAL();
            var gameDetails = userGameDetailsDAL.GetUserGameDetails(userId, gameId);

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


        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa game này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                // Tạo đường dẫn đầy đủ bao gồm cả gameName
                string gameDirectoryPath = Path.Combine(InstallationPath, gameName);

                try
                {
                    if (Directory.Exists(gameDirectoryPath))
                    {
                        // Xóa nội dung thư mục game và thư mục game
                        DeleteDirectoryContents(gameDirectoryPath);
                        Directory.Delete(gameDirectoryPath, true);
                        UserGameDetailsDAL.DeleteGame(userId, gameId, InstallationPath, isInstalled);
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


