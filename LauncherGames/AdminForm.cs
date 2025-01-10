using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using LauncherGames.BLL.Services.Interface;
using LauncherGames.DAL.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LauncherGames
{
    public partial class AdminForm : Form
    {
        private readonly IGameService _gameService;
        private readonly IUserService _userService;
        private readonly IUserGameDetailsService _userGameDetailsService;
        private readonly IServiceProvider _serviceProvider;
        private int userId;
        private readonly string _currentUsername;
        private readonly int _currentUserId;

        public AdminForm(IServiceProvider serviceProvider, string currentUsername, int currentUserId)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _gameService = serviceProvider.GetRequiredService<IGameService>();
            _userService = serviceProvider.GetRequiredService<IUserService>();
            _userGameDetailsService = serviceProvider.GetRequiredService<IUserGameDetailsService>();
            cmbReleaseStatus.Items.AddRange(new object[] { "newReleases", "releasedGames", "upcomingGames" });
            cmbNewReleaseStatus.Items.AddRange(new object[] { "newReleases", "releasedGames", "upcomingGames" });
            _currentUsername = currentUsername;
            _currentUserId = currentUserId;
        }

        private async void AdminForm_Load_1(object sender, EventArgs e)
        {
            await LoadGames();
            await LoadUsers();
        }

        private async Task LoadGames()
        {
            var games = await _gameService.GetAllGamesAsync();
            DisplayGames(games);
        }

        private void DisplayGames(IEnumerable<Game> games)
        {
            flpGames.Controls.Clear();
            foreach (var game in games)
            {
                Button gameButton = new Button
                {
                    Text = game.GameName,
                    Size = new Size(150, 50),
                    BackColor = Color.DarkTurquoise,
                    ForeColor = Color.BlueViolet,
                    Tag = game
                };
                gameButton.Click += GameButton_Click;
                flpGames.Controls.Add(gameButton);
            }
        }

        private void GameButton_Click(object sender, EventArgs e)
        {
            Button gameButton = sender as Button;
            var game = gameButton.Tag as Game;

            txtGameId.Text = game.GameId.ToString();
            txtGameName.Text = game.GameName;
            txtDescription.Text = game.Description;
            txtPrice.Text = game.Price.ToString();
            picImages.ImageLocation = game.GameImage;
            txtDownloadPath.Text = game.DownloadPath;
            txtDateAt.Text = game.CreatedAt?.ToString("dd/MM/yyyy");
            cmbReleaseStatus.SelectedItem = game.ReleaseStatus;
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtGameId.Text, out int gameId))
            {
                MessageBox.Show("Vui lòng chọn game để cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var game = await _gameService.GetGameByIdAsync(gameId);

            if (game == null)
            {
                MessageBox.Show("Không tìm thấy game để cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var propertiesToUpdate = new List<Expression<Func<Game, object>>>();

            if (txtGameName.Text != game.GameName)
            {
                game.GameName = txtGameName.Text;
                propertiesToUpdate.Add(g => g.GameName);
            }

            if (txtDescription.Text != game.Description)
            {
                game.Description = txtDescription.Text;
                propertiesToUpdate.Add(g => g.Description);
            }

            if (decimal.TryParse(txtPrice.Text, out decimal price) && price != game.Price)
            {
                game.Price = price;
                propertiesToUpdate.Add(g => g.Price);
            }

            if (cmbReleaseStatus.SelectedItem?.ToString() != game.ReleaseStatus)
            {
                game.ReleaseStatus = cmbReleaseStatus.SelectedItem.ToString();
                propertiesToUpdate.Add(g => g.ReleaseStatus);
            }

            if (txtDownloadPath.Text != game.DownloadPath)
            {
                game.DownloadPath = txtDownloadPath.Text;
                propertiesToUpdate.Add(g => g.DownloadPath);
            }

            if (propertiesToUpdate.Any())
            {
                await _gameService.UpdateGamePartialAsync(game, propertiesToUpdate.ToArray());
                MessageBox.Show("Cập nhật game thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadGames();
            }
            else
            {
                MessageBox.Show("Không có thay đổi nào để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewGameName.Text) ||
                string.IsNullOrEmpty(txtNewDescription.Text) ||
                string.IsNullOrEmpty(txtNewPrice.Text) ||
                string.IsNullOrEmpty(txtNewDownloadPath.Text) ||
                cmbNewReleaseStatus.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin và chọn trạng thái phát hành.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(txtNewPrice.Text, out decimal price))
            {
                MessageBox.Show("Giá không hợp lệ. Vui lòng nhập một số hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selectedStatus = cmbNewReleaseStatus.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedStatus))
            {
                MessageBox.Show("Vui lòng chọn trạng thái phát hành.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var game = new Game
            {
                GameName = txtNewGameName.Text,
                Description = txtNewDescription.Text,
                Price = price,
                GameImage = picNewgameImages.ImageLocation,
                DownloadPath = txtNewDownloadPath.Text,
                ReleaseStatus = selectedStatus,
                IsExclusive = chkIsExclusive.Checked
            };

            try
            {
                await _gameService.AddGameAsync(game);
                MessageBox.Show("Thêm game mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFormFields();
                await LoadGames();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi thêm game: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            DisplayUsers(users);
        }

        private void DisplayUsers(IEnumerable<User> users)
        {
            flpUsers.Controls.Clear();
            foreach (var user in users)
            {
                Button userButton = new Button
                {
                    Text = user.Username,
                    Size = new Size(150, 50),
                    BackColor = user.IsBanned ? Color.Red : Color.DarkTurquoise,
                    ForeColor = Color.BlueViolet,
                    Tag = user
                };
                userButton.Click += UserButton_Click;
                flpUsers.Controls.Add(userButton);
            }
        }

        private void UserButton_Click(object sender, EventArgs e)
        {
            Button userButton = sender as Button;
            var user = userButton.Tag as User;

            userId = user.UserId; // Update the current userId
            txtUsername.Text = user.Username;
            txtEmail.Text = user.Email;
            txtPhoneNumber.Text = user.PhoneNumber;
            txtBalance.Text = user.Balance.ToString();
            txtFullname.Text = user.FullName;
        }

        private async void btnBanUser_Click(object sender, EventArgs e)
        {
            await _userService.BanUserAsync(userId);
            MessageBox.Show("Tài khoản người dùng đã bị cấm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            UpdateUserButtonColor(userId, Color.Red);
        }

        private async void btnUnbanUser_Click(object sender, EventArgs e)
        {
            await _userService.UnbanUserAsync(userId);
            MessageBox.Show("Tài khoản người dùng đã được mở cấm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            UpdateUserButtonColor(userId, Color.DarkTurquoise);
        }

        private void UpdateUserButtonColor(int userId, Color color)
        {
            foreach (Button userButton in flpUsers.Controls)
            {
                var user = userButton.Tag as User;
                if (user != null && user.UserId == userId)
                {
                    userButton.BackColor = color;
                    break;
                }
            }
        }

        private async void btnAddBalance_Click(object sender, EventArgs e)
        {
            var amount = decimal.Parse(txtAddBalanceAmount.Text);
            await _userService.AddBalanceAsync(userId, amount);
            MessageBox.Show("Đã thêm tiền vào tài khoản người dùng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await LoadUsers();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtGameId.Text, out int gameId))
            {
                MessageBox.Show("Vui lòng chọn game để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var result = MessageBox.Show("Bạn có chắc chắn muốn xóa game này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                await _gameService.DeleteGameAsync(gameId);
                MessageBox.Show("Xóa game thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadGames();
            }
        }

        private async void btnUpdatePic_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                openFileDialog.Title = "Select a Game Image";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    picNewgameImages.ImageLocation = openFileDialog.FileName;

                    string sourceFilePath = openFileDialog.FileName;
                    string fileName = Path.GetFileName(sourceFilePath);
                    string targetDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "GameImages");
                    string targetFilePath = Path.Combine(targetDir, fileName);

                    if (!Directory.Exists(targetDir))
                    {
                        Directory.CreateDirectory(targetDir);
                    }

                    File.Copy(sourceFilePath, targetFilePath, true);

                    string gameImagePath = Path.Combine("Images", "GameImages", fileName);

                    picNewgameImages.ImageLocation = gameImagePath;

                    MessageBox.Show("Image selected successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private async void btnPicGameRL_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                openFileDialog.Title = "Select a Game Image";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    picNewgameImages.ImageLocation = openFileDialog.FileName;

                    string sourceFilePath = openFileDialog.FileName;
                    string fileName = Path.GetFileName(sourceFilePath);
                    string targetDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "GameImages");
                    string targetFilePath = Path.Combine(targetDir, fileName);

                    if (!Directory.Exists(targetDir))
                    {
                        Directory.CreateDirectory(targetDir);
                    }

                    File.Copy(sourceFilePath, targetFilePath, true);

                    string gameImagePath = Path.Combine("Images", "GameImages", fileName);

                    if (int.TryParse(txtGameId.Text, out int gameId))
                    {
                        var game = await _gameService.GetGameByIdAsync(gameId);
                        if (game != null)
                        {
                            game.GameImage = gameImagePath;
                            await _gameService.UpdateGameAsync(game);
                            MessageBox.Show("Cập nhật ảnh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearFormFields();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy game để cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập ID hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ClearFormFields()
        {
            txtGameId.Clear();
            txtGameName.Clear();
            txtDescription.Clear();
            txtPrice.Clear();
            picImages.ImageLocation = null;
            txtDownloadPath.Clear();
            txtDateAt.Clear();
            cmbReleaseStatus.SelectedIndex = -1;
            txtNewGameName.Clear();
            txtNewDescription.Clear();
            txtNewPrice.Clear();
            picNewgameImages.ImageLocation = null;
            txtNewDownloadPath.Clear();
            cmbNewReleaseStatus.SelectedIndex = -1;
        }

        private void tsProfile_HoSo_Click(object sender, EventArgs e)
        {
            ProfileForm profileForm = new ProfileForm(_currentUsername, _currentUserId);
            this.Close();
            profileForm.ShowDialog();
        }

        private void tsProfile_SoDu_Click(object sender, EventArgs e)
        {
            TransactionForm transactionForm = new TransactionForm(_currentUsername, _currentUserId);
            this.Close();
            transactionForm.ShowDialog();
        }

        private async void tsProfile_ThuVien_Click(object sender, EventArgs e)
        {
            try
            {
                var userGames = await _userGameDetailsService.GetPurchasedGamesAsync(_currentUserId);
                Collection collectionForm = new Collection(_currentUsername, _currentUserId, userGames, _serviceProvider);
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
            var userService = _userService;
            var logger = _serviceProvider.GetRequiredService<ILogger<LoginForm>>();
            LoginForm loginForm = new LoginForm(userService, logger);
            loginForm.Show();
        }

        private async void txtGameName_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtGameName.Text;

            if (string.IsNullOrEmpty(searchText))
            {
                await LoadGames();
                return;
            }

            var games = await _gameService.SearchGamesByNameAsync(searchText);
            DisplayGames(games);
        }

        private async void txtUsername_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtUsername.Text;

            if (string.IsNullOrEmpty(searchText))
            {
                await LoadUsers();
                return;
            }

            var users = await _userService.SearchUsersByUsernameAsync(searchText);
            DisplayUsers(users);
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
                    _currentUsername
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
            LauncherForm launcherForm = new LauncherForm(_currentUserId, _currentUsername, _serviceProvider);
            this.Close();
            launcherForm.ShowDialog();
        }

    }
}