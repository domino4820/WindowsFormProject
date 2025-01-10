using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using LauncherGames.BLL.Services;
using LauncherGames.BLL.Services.Interface;
using LauncherGames.DAL.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace LauncherGames
{
    public partial class Collection : Form
    {
        private readonly IUserService _userService;
        private readonly int userId;
        private readonly List<UserGameDetail> userGames;
        private readonly IServiceProvider _serviceProvider;
        private readonly IUserGameDetailsService _userGameDetailsService;
        private readonly IPurchaseService _purchaseService;
        private bool isDownloading = false;
        private string _username;
        private readonly int _currentUserId;
        private readonly IGameService _gameService;

        public Collection(string username, int userId, List<UserGameDetail> userGames, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _username = username;
            this.userId = userId;
            this._currentUserId = userId;
            this.userGames = userGames;
            _serviceProvider = serviceProvider;
            _userGameDetailsService = _serviceProvider.GetRequiredService<IUserGameDetailsService>();
            _purchaseService = _serviceProvider.GetRequiredService<IPurchaseService>();
            _gameService = _serviceProvider.GetRequiredService<IGameService>();
            _userService = _serviceProvider.GetRequiredService<IUserService>();
        }

        private async void Collection_Load(object sender, EventArgs e)
        {
            foreach (var game in userGames)
            {
                Button gameButton = new Button
                {
                    Text = game.Game.GameName,
                    Size = new Size(150, 50),
                    BackColor = Color.SkyBlue,
                    Tag = game
                };
                gameButton.Click += GameButton_Click;
                flpGameLib.Controls.Add(gameButton);
            }


            if (await _userService.IsUserAdminAsync(_currentUserId))
            {
                aministratorToolStripMenuItem.Visible = true;
            }
            else
            {
                aministratorToolStripMenuItem.Visible = false;
            }
        }

        private void GameButton_Click(object sender, EventArgs e)
        {
            Button gameButton = sender as Button;
            var game = gameButton.Tag as UserGameDetail;

            if (game != null)
            {
                lblGameName.Text = game.Game.GameName ?? "Unknown";
                picBoxGame.ImageLocation = game.Game.GameImage;

                // Reset button visibility
                btnInstall.Visible = true;
                btnPlay.Visible = true;
                btnDeleteGame.Visible = true;

                if (game.Game.GameName == "Flappy-Bird")
                {
                    btnInstall.Visible = false;
                    btnDeleteGame.Visible = false;
                    btnPlay.Enabled = true; 
                }
                else
                {
                    btnInstall.Enabled = !game.IsInstalled;
                    btnPlay.Enabled = game.IsInstalled;
                    btnDeleteGame.Visible = game.IsInstalled;
                }

                btnInstall.Tag = game;
                btnPlay.Tag = game;
                btnDeleteGame.Tag = game;
                btngotopagegame.Tag = game;
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin game.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnInstall_Click(object sender, EventArgs e)
        {
            if (isDownloading)
            {
                MessageBox.Show("Đang tải xuống, vui lòng đợi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var game = btnInstall.Tag as UserGameDetail;
            if (game == null)
            {
                MessageBox.Show("Không tìm thấy thông tin game.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string downloadPath = game.DownloadPath;
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
                    string gameDirectory = folderDialog.SelectedPath;
                    isDownloading = true;

                    using (ProgressForm progressForm = new ProgressForm(downloadPath))
                    {
                        progressForm.SavePath = Path.Combine(gameDirectory, $"{game.GameId}.zip");
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
            var game = btnInstall.Tag as UserGameDetail;
            if (game == null)
            {
                MessageBox.Show("Không tìm thấy thông tin game.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string savePath = Path.Combine(saveDirectory, $"{game.GameId}.zip");

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

                            while ((bytesRead = await contentStream.ReadAsync(buffer.AsMemory(0, buffer.Length))) != 0)
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

                var userGameDetails = await _userGameDetailsService.GetUserGameDetailsAsync(userId, game.GameId);
                if (userGameDetails != null)
                {
                    userGameDetails.IsInstalled = true;
                    userGameDetails.InstallationPath = saveDirectory;
                    await _userGameDetailsService.UpdateUserGameDetailsAsync(userGameDetails);
                }

                string gameDirectory = saveDirectory;
                await UpdateButtonState(userId, game.GameId);
                MessageBox.Show("Tải xuống và cài đặt thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnInstall.Visible = false;
                btnPlay.Visible = true;
                btnDeleteGame.Visible = true;
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

        private async Task UpdateButtonState(int userId, int gameId)
        {
            var userGameDetails = await _userGameDetailsService.GetUserGameDetailsAsync(userId, gameId);
            if (userGameDetails != null)
            {
                btnInstall.Enabled = !userGameDetails.IsInstalled;
                btnPlay.Enabled = userGameDetails.IsInstalled;
                btnDeleteGame.Visible = userGameDetails.IsInstalled;
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            var game = btnPlay.Tag as UserGameDetail;

            if (game != null && game.Game.IsExclusive)
            {
                OpenExclusiveGame(game.Game.GameName);
            }
            else if (game != null)
            {
                PlayGame(game);
            }
        }

        private void OpenExclusiveGame(string gameName)
        {
            if (gameName == "Flappy-Bird")
            {
                var flappyBirdForm = new Flappy_Bird_Game.Form1();
                flappyBirdForm.Show();
            }
            else
            {
                MessageBox.Show("Game không hỗ trợ chế độ exclusive.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void PlayGame(UserGameDetail game)
        {
            if (game.InstallationPath == null || game.Game.GameName == null)
            {
                MessageBox.Show("Không tìm thấy file thực thi. Vui lòng kiểm tra lại cài đặt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string exePath = Path.Combine(game.InstallationPath, $"{game.Game.GameName}/{game.Game.GameName}.exe");

            if (File.Exists(exePath))
            {
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

        private async void btnDeleteGame_Click(object sender, EventArgs e)
        {
            var game = btnDeleteGame.Tag as UserGameDetail;
            if (game == null)
            {
                MessageBox.Show("Không tìm thấy thông tin game.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa game này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                if (game.InstallationPath == null || game.Game.GameName == null)
                {
                    MessageBox.Show("Thư mục game không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string gameDirectoryPath = Path.Combine(game.InstallationPath, game.Game.GameName);

                try
                {
                    if (Directory.Exists(gameDirectoryPath))
                    {
                        DeleteDirectoryContents(gameDirectoryPath);
                        Directory.Delete(gameDirectoryPath, true);

                        game.IsInstalled = false;
                        game.InstallationPath = null;
                        await _userGameDetailsService.UpdateUserGameDetailsAsync(game);

                        UpdatePlayButtonToInstall();
                        btnDeleteGame.Visible = false;
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
            btnInstall.Enabled = true;
            btnPlay.Visible = false;
            btnInstall.Text = "Cài đặt";
            btnInstall.Click -= btnPlay_Click;
            btnInstall.Click += btnInstall_Click;
        }

        private void tsProfile_HoSo_Click(object sender, EventArgs e)
        {
            ProfileForm profileForm = new ProfileForm(_username, userId);
            profileForm.Show();
            this.Close();
        }

        private async void tsProfile_SoDu_Click(object sender, EventArgs e)
        {
            TransactionForm transactionForm = new TransactionForm(_username, userId);
            this.Close();
            transactionForm.ShowDialog();
        }

        private void tsProfile_Logout_Click(object sender, EventArgs e)
        {
            this.Close();
            var userService = _serviceProvider.GetRequiredService<IUserService>();
            var logger = _serviceProvider.GetRequiredService<ILogger<LoginForm>>();
            LoginForm loginForm = new LoginForm(userService, logger);
            loginForm.Show();
        }

        private void aministratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminForm adminForm = new AdminForm(_serviceProvider, _username, userId);
            adminForm.Show();
            this.Hide();
        }

        private async void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text;

            if (string.IsNullOrEmpty(searchText))
            {
                lstSearchResults.Visible = false;
                return;
            }

            var games = await _gameService.SearchGamesByNameAsync(searchText);
            if (games.Any())
            {
                lstSearchResults.DataSource = games;
                lstSearchResults.DisplayMember = "GameName";
                lstSearchResults.ValueMember = "GameId";
                lstSearchResults.Visible = true;
            }
            else
            {
                lstSearchResults.Visible = false;
            }
        }

        private async void lstSearchResults_Click(object sender, EventArgs e)
        {
            if (lstSearchResults.SelectedItem == null)
                return;

            var selectedGame = (Game)lstSearchResults.SelectedItem;
            await OpenGameForm(selectedGame);
            lstSearchResults.Visible = false;
        }

        private async Task OpenGameForm(Game game)
        {
            try
            {
                var userGameDetails = await _userGameDetailsService.GetUserGameDetailsAsync(userId, game.GameId);

                if (userGameDetails == null)
                {
                    userGameDetails = new UserGameDetail
                    {
                        UserId = userId,
                        GameId = game.GameId,
                        IsPurchased = false,
                        IsInstalled = false,
                        InstallationPath = string.Empty,
                        DownloadPath = string.Empty
                    };
                }

                GameForm gameForm = new GameForm(
                    userId,
                    game.GameName,
                    game.GameImage,
                    game.Price,
                    game.DownloadPath,
                    game.RunPath,
                    game.Description,
                    userGameDetails.IsPurchased,
                    userGameDetails.IsInstalled,
                    game.IsExclusive,
                    game.GameId,
                    userGameDetails.InstallationPath,
                    Program.ServiceProvider,
                    _username
                );
                gameForm.Show();
                this.Hide();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi lấy thông tin game: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btngotopagegame_Click(object sender, EventArgs e)
        {
            var game = btngotopagegame.Tag as UserGameDetail;
            if (game == null)
            {
                MessageBox.Show("Không tìm thấy thông tin game.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var gameForm = new GameForm(
                userId,
                game.Game.GameName,
                game.Game.GameImage,
                game.Game.Price,
                game.DownloadPath,
                game.Game.RunPath,
                game.Game.Description,
                game.IsPurchased,
                game.IsInstalled,
                game.Game.IsExclusive,
                game.Game.GameId,
                game.InstallationPath,
                _serviceProvider,
                _username
            );
            gameForm.Show();
            this.Hide();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            LauncherForm launcherForm = new LauncherForm(_currentUserId, _username, _serviceProvider);
            this.Close();
            launcherForm.ShowDialog();
        }
    }
}