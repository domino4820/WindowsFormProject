using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LauncherGames.BLL.Services;
using LauncherGames.BLL.Services.Interface;
using LauncherGames.DAL.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LauncherGames
{
    public partial class TransactionForm : Form
    {
        private readonly IUserService _userService;
        private readonly ITransactionService _transactionService;
        private readonly IGameService _gameService;
        private readonly IUserGameDetailsService _userGameDetailsService;
        private readonly int _userId;
        private string _username;

        public TransactionForm(string username, int userId)
        {
            InitializeComponent();
            _username = username;
            _userId = userId;
            _userService = Program.ServiceProvider.GetRequiredService<IUserService>();
            _transactionService = Program.ServiceProvider.GetRequiredService<ITransactionService>();
            _gameService = Program.ServiceProvider.GetRequiredService<IGameService>();
            _userGameDetailsService = Program.ServiceProvider.GetRequiredService<IUserGameDetailsService>();


        }

        private async void LoadTransactionList()
        {
            var transactions = await _transactionService.GetTransactionsByUserIdAsync(_userId);
            dataGridViewTransactions.DataSource = transactions;

            if (dataGridViewTransactions.Columns["TransactionId"] != null)
            {
                dataGridViewTransactions.Columns["TransactionId"].Visible = false;
            }

        }

        private async void UpdateUserBalance()
        {
            var user = await _userService.GetUserByIdAsync(_userId);
            if (user != null)
            {
                lblSoDu.Text = $"{user.Balance:C}";
            }
        }

        private async void TransactionForm_Load_1(object sender, EventArgs e)
        {
            LoadTransactionList();
            UpdateUserBalance();
            SetGridViewStyle(dataGridViewTransactions);


            if (await _userService.IsUserAdminAsync(_userId))
            {
                aministratorToolStripMenuItem.Visible = true;
            }
            else
            {
                aministratorToolStripMenuItem.Visible = false;
            }


        }



        public static void SetGridViewStyle(DataGridView dgview)
        {
            dgview.BorderStyle = BorderStyle.None;
            dgview.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dgview.DefaultCellStyle.SelectionForeColor = Color.BlueViolet;
            dgview.DefaultCellStyle.Font = new Font(dgview.DefaultCellStyle.Font.FontFamily, 10);
            dgview.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgview.BackgroundColor = Color.White;
            dgview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnPaypal_Click(object sender, EventArgs e)
        {
            PaypalForm paypalform = new PaypalForm(_userService, _userId, this);
            this.Hide();
            paypalform.ShowDialog();

        }

        public async void ReloadTransaction()
        {
            UpdateUserBalance();
            this.Show();
        }


        private void tsProfile_HoSo_Click(object sender, EventArgs e)
        {
            ProfileForm profileForm = new ProfileForm(_username, _userId);
            this.Close();
            profileForm.Show();
        }


        private async void tsProfile_ThuVien_Click(object sender, EventArgs e)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(_userId);
                if (user != null)
                {
                    var userGames = user.UserGameDetails;
                    Collection collectionForm = new Collection(_username, _userId, userGames.ToList(), Program.ServiceProvider);
                    this.Close();
                    collectionForm.Show();
                }
                else
                {
                    MessageBox.Show("User not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi lấy thông tin game: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsProfile_Logout_Click(object sender, EventArgs e)
        {
            this.Close();
            var userService = Program.ServiceProvider.GetRequiredService<IUserService>();
            var logger = Program.ServiceProvider.GetRequiredService<ILogger<LoginForm>>();
            LoginForm loginForm = new LoginForm(userService, logger);
            loginForm.Show();
        }

        private void aministratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminForm adminForm = new AdminForm(Program.ServiceProvider, _username, _userId);
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
                var userGameDetails = await _userGameDetailsService.GetUserGameDetailsAsync(_userId, game.GameId);

                if (userGameDetails == null)
                {
                    userGameDetails = new UserGameDetail
                    {
                        UserId = _userId,
                        GameId = game.GameId,
                        IsPurchased = false,
                        IsInstalled = false,
                        InstallationPath = string.Empty,
                        DownloadPath = string.Empty
                    };
                }

                GameForm gameForm = new GameForm(
                    _userId,
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

        private void btnHome_Click(object sender, EventArgs e)
        {
            LauncherForm launcherForm = new LauncherForm(_userId, _username, Program.ServiceProvider);
            this.Close();
            launcherForm.ShowDialog();
        }


    }
}