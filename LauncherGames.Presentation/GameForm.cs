using System;
using System.Diagnostics;
using System.Windows.Forms;
using LauncherGames.BLL;
using LauncherGames.DAL;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;

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

        public GameForm(int userId, string gameName, string gameImage, decimal gamePrice, string downloadPath, string runPath, string description, bool isPurchased, bool isInstalled, int gameId)
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
            this.currentUserId = userId;
            userDAL = new UserDAL();
            gameManager = new GameManager();
            gameManager.DownloadCompleted += OnDownloadCompleted;
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            // Initialize the form with game details
            lblGameName.Text = gameName;
            picBoxGame.ImageLocation = gameImage;
            lblPrice.Text = gamePrice == 0 ? "Free" : $"{gamePrice:C}";
            txtGameDescription.Text = description;

            // Update button visibility based on game status
            btnPurchase.Visible = !isPurchased;
            btnInstall.Visible = isPurchased && !isInstalled;
            btnPlay.Visible = isInstalled;
            UpdateButtonState(currentUserId, gameId);
        }


        private void btnPurchase_Click(object sender, EventArgs e)
        {



            PurchaseBLL purchaseBLL = new PurchaseBLL();
            bool success = purchaseBLL.BuyGame(currentUserId, gameId);

            if (success)
            {
                MessageBox.Show("Mua game thành công!", "Thông báo");
                UpdateButtonState(currentUserId, gameId);
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

            var gameState = GameStateManager.GetGameState(gameId);
            if (gameState.IsInstalled)
            {
                MessageBox.Show("Game đã được cài đặt. Đang khởi động.");
                PlayGame();
                return;
            }

            string downloadUrl = gameState.DownloadPath;

            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Chọn thư mục để lưu game";
                folderDialog.ShowNewFolderButton = true;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    gameDirectory = folderDialog.SelectedPath;
                    isDownloading = true;

                    ProgressForm progressForm = new ProgressForm(downloadUrl)
                    {
                        GameName = gameName,
                        DownloadUrl = downloadUrl,
                        SavePath = Path.Combine(gameDirectory, $"{gameName}.zip")
                    };

                    progressForm.Show();

                    // Bắt đầu quá trình tải xuống và cài đặt
                    gameManager.ProgressChanged += progressForm.UpdateProgress;
                    await gameManager.DownloadAndInstallGameAsync(gameName, downloadUrl, gameDirectory);

                    // Đóng form tiến trình khi quá trình tải xuống hoàn tất
                    progressForm.Close();
                    gameManager.ProgressChanged -= progressForm.UpdateProgress;
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn thư mục lưu.");
                }
            }
        }


        private void OnDownloadCompleted()
        {
            isDownloading = false;
            UpdateButtonState(currentUserId, gameId);
            MessageBox.Show($"Tải xuống và giải nén thành công! Game đã được lưu tại: {gameDirectory}");
        }



        private void btnPlay_Click(object sender, EventArgs e)
        {
            PlayGame();
        }

        private void PlayGame()
        {
            if (string.IsNullOrEmpty(gameDirectory))
            {
                MessageBox.Show("Không tìm thấy thư mục game. Vui lòng cài đặt lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string exePath = Path.Combine(gameDirectory, $"{gameName}/{gameName}.exe");

            if (File.Exists(exePath))
            {
                System.Diagnostics.Process.Start(exePath);
            }
            else
            {
                MessageBox.Show("Không tìm thấy file thực thi. Vui lòng kiểm tra lại cài đặt.");
            }
        }

        private void InstallGame()
        {
            // Logic to install the game to DownloadPath
        }

        private void DeductBalance(decimal amount)
        {
            decimal currentBalance = userDAL.GetUserBalance(currentUserId);
            if (currentBalance >= amount)
            {
                userDAL.UpdateUserBalance(currentUserId, currentBalance - amount);
            }
            else
            {
                // Handle insufficient balance case
                MessageBox.Show("Insufficient balance to complete the purchase.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool UserHasSufficientBalance(decimal price)
        {
            decimal currentBalance = userDAL.GetUserBalance(currentUserId);
            return currentBalance >= price;
        }

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

        private void btnDeleteGame_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa game này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    gameManager.DeleteGame(gameName, gameDirectory);
                    UpdateButtonState(currentUserId, gameId);
                    MessageBox.Show("Game đã được xóa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi khi xóa game: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
