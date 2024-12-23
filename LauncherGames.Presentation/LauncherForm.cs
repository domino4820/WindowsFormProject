using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using LauncherGames.BLL;
using LauncherGames.DAL;
using System.Drawing;
using System.Drawing.Drawing2D;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace LauncherGames.Presentation
{

    public partial class LauncherForm : Form
    {
        private GameBLL gameBLL;
        private UserGameDetailsDAL userGameDetailsDAL;
        private UserDAL userDAL;
        private int currentUserId; // Giả sử đây là ID của người dùng hiện tại
        private string currentUsername;

        public LauncherForm(string username,int userId)
        {
            InitializeComponent();
            gameBLL = new GameBLL();
            userGameDetailsDAL = new UserGameDetailsDAL();
            userDAL = new UserDAL();
            currentUsername = username;
            currentUserId = userId;
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
                BorderStyle = BorderStyle.None,
                BackColor = Color.Black,
                ForeColor = Color.White
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

            //Label gameName = new Label
            //{
            //    Text = game.GameName,
            //    Dock = DockStyle.Top,
            //    TextAlign = ContentAlignment.MiddleCenter,
            //    Font = new Font("Arial", 10, FontStyle.Bold),
            //    ForeColor = Color.White
            //};

            Label gameName = new Label
            {
                Text = game.GameName,                // Hiển thị tên game
                ForeColor = Color.White,             // Màu chữ: Trắng
                BackColor = Color.Black, // Màu nền: Xám đậm
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 12, FontStyle.Regular),
                AutoSize = false,
                Dock = DockStyle.Bottom,             // Đặt DockStyle là Bottom (trên gamePrice)
                Height = 30                          // Chiều cao cố định
            };

            gameName.Click += (sender, e) => OpenGameForm(game);



            //Label gamePrice = new Label
            //{
            //    Text = game.Price == 0 ? "Free" : $"{game.Price:C}",
            //    Dock = DockStyle.Bottom,
            //    TextAlign = ContentAlignment.MiddleCenter,
            //    ForeColor = Color.Green
            //};

            Label gamePrice = new Label
            {
                Text = game.Price == 0 ? "Free" : $"{game.Price:C}", // Hiển thị giá hoặc Free
                ForeColor = Color.DarkGreen,        // Màu chữ: Xanh lá
                BackColor = Color.FromArgb(50, 255, 50), // Màu nền: Xám đậm
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 12, FontStyle.Bold),
                AutoSize = false,
                Dock = DockStyle.Bottom,            // Đặt DockStyle là Bottom
                Height = 30                         // Chiều cao cố định
            };

            gamePrice.Click += (sender, e) => OpenGameForm(game);

            gameImage.MouseEnter += GamePanel_MouseEnter;
            gameImage.MouseLeave += GamePanel_MouseLeave;

            gamePrice.MouseEnter += GamePanel_MouseEnter;
            gamePrice.MouseLeave += GamePanel_MouseLeave;

            gameName.MouseEnter += GamePanel_MouseEnter;
            gameName.MouseLeave += GamePanel_MouseLeave;

            //Label gameName = CreateRoundedLabel(game.GameName, Color.White, Color.FromArgb(50, 50, 50));
            //Label gamePrice = CreateRoundedLabel(game.Price == 0 ? "Free" : $"{game.Price:C}", Color.Green, Color.FromArgb(50, 50, 50));
            gamePanel.Controls.Add(gameName);
            gamePanel.Controls.Add(gamePrice);
            gamePanel.Controls.Add(gameImage);


            return gamePanel;
        }




        private void GamePanel_MouseEnter(object sender, EventArgs e)
        {
            Control control = sender as Control;
            if (control != null)
            {
                Panel parentPanel = control.Parent as Panel;
                if (parentPanel != null)
                {
                    parentPanel.BackColor = Color.FromArgb(50, 255, 50); 

                    parentPanel.CreateGraphics().DrawRectangle(
                        new Pen(Color.FromArgb(50, 255, 50), 2),
                        new Rectangle(1, 1, parentPanel.Width - 3, parentPanel.Height - 3)
                    );

                    parentPanel.Padding = new Padding(3);
                    parentPanel.BorderStyle = BorderStyle.Fixed3D;
                }
            }
        }

        private void GamePanel_MouseLeave(object sender, EventArgs e)
        {
            Control control = sender as Control;
            if (control != null)
            {
                Panel parentPanel = control.Parent as Panel;
                if (parentPanel != null)
                {
                    parentPanel.BackColor = Color.Black;
                    parentPanel.Padding = new Padding(0);
                    parentPanel.CreateGraphics().Clear(parentPanel.BackColor);
                    parentPanel.BorderStyle = BorderStyle.None;
                }
            }
        }


        private void OpenGameForm(Game game)
        {
            // Kiểm tra nếu gameName hoặc InstallationPath là null hoặc rỗng
            var userGameDetails = userGameDetailsDAL.GetUserGameDetails(currentUserId, game.GameId);

            GameForm gameForm = new GameForm(
                currentUserId,
                game.GameName,
                game.GameImage,
                game.Price,
                game.DownloadPath,
                game.RunPath,
                game.Description,
                CheckIfUserPurchasedGame(game.GameId),
                CheckIfGameIsInstalled(game.GameId),
                game.GameId
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

        private void tsProfile_HoSo_Click(object sender, EventArgs e)
        {
            ProfileForm profileForm = new ProfileForm(currentUsername, currentUserId);
            profileForm.Show();
        }

        private void tsProfile_SoDu_Click(object sender, EventArgs e)
        {

            TransactionForm transactionForm = new TransactionForm(currentUserId);
            transactionForm.Show();
        }
    }
}