using System;
using System.Diagnostics;
using System.Windows.Forms;
using LauncherGames.DAL;
using Microsoft.Data.SqlClient;

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
        private readonly int gameId; // Added gameId field
        private int currentUserId = 1; // Giả sử đây là ID của người dùng hiện tại
        private readonly string Decription;
        private UserDAL userDAL;

        public GameForm(string gameName, string gameImage, decimal gamePrice, string downloadPath, string runPath, string description, bool isPurchased, bool isInstalled, int gameId, string Decription) // Added gameId parameter
        {
            InitializeComponent();
            this.gameName = gameName;
            this.gameImage = gameImage;
            this.gamePrice = gamePrice;
            this.downloadPath = downloadPath;
            this.runPath = runPath;
            this.isPurchased = isPurchased;
            this.isInstalled = isInstalled;
            this.gameId = gameId; // Initialize gameId
            this.Decription = Decription;
            userDAL = new UserDAL();
            
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            // Initialize the form with game details
            lblGameName.Text = gameName;
            picBoxGame.ImageLocation = gameImage;
            lblPrice.Text = gamePrice == 0 ? "Free" : $"{gamePrice:C}";
            txtGameDescription.Text = Decription;

            // Update button visibility based on game status
            btnPurchase.Visible = !isPurchased;
            btnInstall.Visible = isPurchased && !isInstalled;
            btnPlay.Visible = isInstalled;
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            // Implement purchase logic
            if (UserHasSufficientBalance(gamePrice))
            {
                DeductBalance(gamePrice);
                // Mark the game as purchased in the database
                UserGameDetailsDAL userGameDetailsDAL = new UserGameDetailsDAL();
                userGameDetailsDAL.IsGamePurchasedByUser(currentUserId, gameId);
                btnPurchase.Visible = false;
                btnInstall.Visible = true;
                MessageBox.Show("Purchase successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Insufficient balance.", "Purchase Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            // Implement installation logic
            InstallGame();
            // Mark the game as installed in the database
            UserGameDetailsDAL userGameDetailsDAL = new UserGameDetailsDAL();
            userGameDetailsDAL.IsGameInstalledByUser(currentUserId, gameId);
            btnInstall.Visible = false;
            btnPlay.Visible = true;
            MessageBox.Show("Installation successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            // Implement play game logic
            if (File.Exists(runPath))
            {
                Process.Start(runPath);
            }
            else
            {
                MessageBox.Show("Game not found. Please reinstall.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnPlay.Visible = false;
                btnInstall.Visible = true;
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
    }
}
