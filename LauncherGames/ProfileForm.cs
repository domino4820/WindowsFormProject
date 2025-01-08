using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using LauncherGames.BLL.Services;
using LauncherGames.BLL.Services.Interface;
using LauncherGames.DAL.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LauncherGames
{
    public partial class ProfileForm : Form
    {
        private readonly IUserService _userService;
        private readonly IUserGameDetailsService _userGameDetailsService;
        private string _username;
        private User _currentUser;
        private readonly int _currentUserId;
        private readonly IGameService _gameService;


        public ProfileForm(string username, int userId)
        {
            InitializeComponent();
            _username = username;
            _currentUserId = userId;
            _userService = Program.ServiceProvider.GetRequiredService<IUserService>();
            _userGameDetailsService = Program.ServiceProvider.GetRequiredService<IUserGameDetailsService>();
            _gameService = Program.ServiceProvider.GetRequiredService<IGameService>();
        }

        private async void LoadUserProfile()
        {
            _currentUser = await _userService.GetUserByUsernameAsync(_username);
            if (_currentUser != null)
            {
                txtFullName.Text = _currentUser.FullName;
                txtSDT.Text = _currentUser.PhoneNumber;
                txtEmail.Text = _currentUser.Email;
                lblUsername.Text = $"Chào mừng, {_currentUser.FullName}";
            }
            else
            {
                lblUsername.Text = "Không tìm thấy thông tin người dùng.";
            }
        }

        private async void ProfileForm_Load_1(object sender, EventArgs e)
        {
            LoadUserProfile();

            if (await _userService.IsUserAdminAsync(_currentUserId))
            {
                aministratorToolStripMenuItem.Visible = true;
            }
            else
            {
                aministratorToolStripMenuItem.Visible = false;
            }
        }


        private async void btnCapNhatMK_Click(object sender, EventArgs e)
        {
            if (_currentUser == null)
            {
                MessageBox.Show("Người dùng hiện tại không được khởi tạo.", "Lỗi");
                return;
            }

            string currentPassword = txtPassword.Text.Trim();
            string newPassword = txtNewPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(currentPassword) || string.IsNullOrWhiteSpace(newPassword) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo");
                return;
            }

            if (currentPassword != _currentUser.Password)
            {
                MessageBox.Show("Mật khẩu hiện tại không đúng.", "Lỗi");
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu không khớp.", "Lỗi");
                return;
            }

            await _userService.ChangePasswordAsync(_username, newPassword);
            MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo");

            if (await _userService.IsUserAdminAsync(_currentUserId))
            {
                aministratorToolStripMenuItem.Visible = true;
            }
            else
            {
                aministratorToolStripMenuItem.Visible = false;
            }
        }

        private async void btnCapnhat_Click(object sender, EventArgs e)
        {
            if (_currentUser == null)
            {
                MessageBox.Show("Người dùng hiện tại không được khởi tạo.", "Lỗi");
                return;
            }

            string fullName = txtFullName.Text.Trim();
            string phoneNumber = txtSDT.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(phoneNumber) || string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo");
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, @"^\d+$"))
            {
                MessageBox.Show("Số điện thoại chỉ chứa số.", "Lỗi");
                return;
            }

            _currentUser.FullName = fullName;
            _currentUser.PhoneNumber = phoneNumber;
            _currentUser.Email = email;

            LogToFile($"Updating user: {_currentUser.UserId}, {_currentUser.FullName}, {_currentUser.PhoneNumber}, {_currentUser.Email}");
            await _userService.UpdateUserAsync(_currentUser);
            MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo");
            lblUsername.Text = $"Chào mừng, {_currentUser.FullName}";
        }

        private void LogToFile(string message)
        {
            string filePath = "debug_log.txt";
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"{DateTime.Now}: {message}");
            }
        }

        private void tsProfile_SoDu_Click(object sender, EventArgs e)
        {
            TransactionForm transactionForm = new TransactionForm(_username, _currentUserId);
            this.Close();
            transactionForm.ShowDialog();
        }

        private async void tsProfile_ThuVien_Click(object sender, EventArgs e)
        {
            try
            {
                var userGames = await _userGameDetailsService.GetPurchasedGamesAsync(_currentUserId);
                Collection collectionForm = new Collection(_username,_currentUserId, userGames, Program.ServiceProvider);
                this.Close();
                collectionForm.Show();
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
            AdminForm adminForm = new AdminForm(Program.ServiceProvider,_username,_currentUserId);
            //adminForm.FormClosed += async (s, args) =>
            {
                this.Show();
            };
            adminForm.Show();
            this.Hide();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            LauncherForm launcherForm = new LauncherForm(_currentUserId, _username, Program.ServiceProvider);
            this.Close();
            launcherForm.ShowDialog();
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
                var userGameDetails = await _userGameDetailsService.GetUserGameDetailsAsync(_currentUserId, game.GameId);

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
    }
}