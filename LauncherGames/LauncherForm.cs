using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using LauncherGames.BLL.Services.Interface;
using LauncherGames.DAL.Models;
using Microsoft.Extensions.DependencyInjection;

namespace LauncherGames
{
    public partial class LauncherForm : Form
    {
        private readonly IGameService _gameService;
        private readonly IUserGameDetailsService _userGameDetailsService;
        private readonly IServiceProvider _serviceProvider;
        private readonly IUserService _userService;
        private readonly int _currentUserId;
        private readonly string _currentUsername;

        public LauncherForm(int userId, string username, IServiceProvider serviceProvider)
        {
            InitializeComponent();

            _gameService = Program.ServiceProvider.GetRequiredService<IGameService>();
            _userGameDetailsService = Program.ServiceProvider.GetRequiredService<IUserGameDetailsService>();
            _serviceProvider = serviceProvider;
            _userService = serviceProvider.GetRequiredService<IUserService>();

            _currentUsername = username;
            _currentUserId = userId;
        }

        private async void LauncherForm_Load(object sender, EventArgs e)
        {
            await LoadGames();
            if (await _userService.IsUserAdminAsync(_currentUserId))
            {
                aministratorToolStripMenuItem.Visible = true;
            }
            else
            {
                aministratorToolStripMenuItem.Visible = false;
            }
        }

        private async Task LoadGames()
        {
            var games = await _gameService.GetAllGamesAsync();

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
                        newReleases.Add(game);
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
                Height = 265,
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

            Label gameName = new Label
            {
                Text = game.GameName,
                ForeColor = Color.White,
                BackColor = Color.Black,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 12, FontStyle.Regular),
                AutoSize = false,
                Dock = DockStyle.Bottom,
                Height = 30
            };

            gameName.Click += (sender, e) => OpenGameForm(game);

            Label gamePrice = new Label
            {
                Text = game.Price == 0 ? "Free" : $"{game.Price:C}",
                ForeColor = Color.DarkGreen,
                BackColor = Color.FromArgb(50, 50, 50),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 12, FontStyle.Bold),
                AutoSize = false,
                Dock = DockStyle.Bottom,
                Height = 30
            };

            gamePrice.Click += (sender, e) => OpenGameForm(game);

            gameImage.MouseEnter += GamePanel_MouseEnter;
            gameImage.MouseLeave += GamePanel_MouseLeave;

            gamePrice.MouseEnter += GamePanel_MouseEnter;
            gamePrice.MouseLeave += GamePanel_MouseLeave;

            gameName.MouseEnter += GamePanel_MouseEnter;
            gameName.MouseLeave += GamePanel_MouseLeave;

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

        private async void OpenGameForm(Game game)
        {
            try
            {
                // Attempt to get user game details
                var userGameDetails = await _userGameDetailsService.GetUserGameDetailsAsync(_currentUserId, game.GameId);

                // If userGameDetails is null, initialize with default values
                if (userGameDetails == null)
                {
                    userGameDetails = new UserGameDetail
                    {
                        UserId = _currentUserId,
                        GameId = game.GameId,
                        IsPurchased = false,
                        IsInstalled = false,
                        InstallationPath = string.Empty,
                        DownloadPath = string.Empty
                    };
                }

                // Create and show the GameForm
                GameForm gameForm = new GameForm(
                    _currentUserId,
                    game.GameName,
                    game.GameImage,
                    game.Price,
                    game.DownloadPath,
                    game.RunPath,
                    game.Description,
                    userGameDetails.IsPurchased,
                    userGameDetails.IsInstalled,
                    game.GameId,
                    userGameDetails.InstallationPath,
                    Program.ServiceProvider
                );
                gameForm.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi lấy thông tin game: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsProfile_HoSo_Click(object sender, EventArgs e)
        {
            ProfileForm profileForm = new ProfileForm(_currentUsername);
            profileForm.Show();
        }

        private void tsProfile_SoDu_Click(object sender, EventArgs e)
        {
            TransactionForm transactionForm = new TransactionForm(_currentUserId);
            transactionForm.Show();
        }

        private async void aministratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminForm adminForm = new AdminForm(_serviceProvider);
            adminForm.Show();
        }

    }
}