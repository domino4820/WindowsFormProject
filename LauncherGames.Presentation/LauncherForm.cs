using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using LauncherGames.BLL;
using LauncherGames.DAL;

namespace LauncherGames.Presentation
{
    public partial class LauncherForm : Form
    {
        private GameBLL gameBLL;
        private UserGameDetailsDAL userGameDetailsDAL;
        private UserDAL userDAL;
        private int currentUserId = 1; // Giả sử đây là ID của người dùng hiện tại

        public LauncherForm()
        {
            InitializeComponent();
            gameBLL = new GameBLL();
            userGameDetailsDAL = new UserGameDetailsDAL();
            userDAL = new UserDAL();
        }

        private void LauncherForm_Load(object sender, EventArgs e)
        {
            LoadGames();
        }

        private void LoadGames()
        {
            var games = gameBLL.GetAllGames();

            List<Game> newReleases = new List<Game>();
            List<Game> releasedGames = new List<Game>();
            List<Game> upcomingGames = new List<Game>();

            foreach (var game in games)
            {
                switch (game.ReleaseStatus)
                {
                    case "Mới phát hành":
                        newReleases.Add(game);
                        break;
                    case "Đã phát hành":
                        releasedGames.Add(game);
                        break;
                    case "Sắp phát hành":
                        upcomingGames.Add(game);
                        break;
                    default:
                        newReleases.Add(game); // Default to new releases if no status is set
                        break;
                }
            }

            AddGamesToPanel(flpNewReleases, newReleases);
            AddGamesToPanel(flpReleasedGames, releasedGames);
            AddGamesToPanel(flpUpcomingGames, upcomingGames);
        }

        private void AddGamesToPanel(FlowLayoutPanel panel, List<Game> games)
        {
            panel.Controls.Clear();
            foreach (var game in games)
            {
                Panel gamePanel = CreateGamePanel(game);
                panel.Controls.Add(gamePanel);
            }
        }

        private Panel CreateGamePanel(Game game)
        {
            Panel gamePanel = new Panel
            {
                Width = 200,
                Height = 300,
                BorderStyle = BorderStyle.FixedSingle
            };

            PictureBox gameImage = new PictureBox
            {
                ImageLocation = game.GameImage,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Dock = DockStyle.Top,
                Height = 200,
                Cursor = Cursors.Hand
            };

            gameImage.Click += (sender, e) => OpenGameForm(game);

            Label gameName = new Label
            {
                Text = game.GameName,
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.White
            };

            Label gamePrice = new Label
            {
                Text = game.Price == 0 ? "Free" : $"{game.Price:C}",
                Dock = DockStyle.Bottom,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Green
            };

            gamePanel.Controls.Add(gamePrice);
            gamePanel.Controls.Add(gameName);
            gamePanel.Controls.Add(gameImage);

            return gamePanel;
        }

        private void OpenGameForm(Game game)
        {
            GameForm gameForm = new GameForm(
                game.GameName,
                game.GameImage,
                game.Price,
                game.DownloadPath,
                game.RunPath,
                game.Description,
                CheckIfUserPurchasedGame(game.GameId),
                CheckIfGameIsInstalled(game.GameId),
                game.GameId,
                game.Description
            );
            gameForm.Show();
        }

        private bool CheckIfUserPurchasedGame(int gameId)
        {
            return userGameDetailsDAL.IsGamePurchasedByUser(currentUserId, gameId);
        }

        private bool CheckIfGameIsInstalled(int gameId)
        {
            return userGameDetailsDAL.IsGameInstalledByUser(currentUserId, gameId);
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
                MessageBox.Show("Insufficient balance to complete the purchase.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool UserHasSufficientBalance(decimal price)
        {
            decimal currentBalance = userDAL.GetUserBalance(currentUserId);
            return currentBalance >= price;
        }

        private void LauncherForm_Resize(object sender, EventArgs e)
        {
            int panelHeight = (pnlLauncher.Height - toolStrip1.Height) / 3;
            flpNewReleases.Height = panelHeight;
            flpReleasedGames.Height = panelHeight;
            flpUpcomingGames.Height = panelHeight;
        }
    }
}