using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LauncherGames.DAL;

namespace LauncherGames.Presentation
{
    public partial class AdminForm : Form
    {
        private int userId;
        public AdminForm()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void LoadGames()
        {
            var games = GameDAL.GetAllGames();
            foreach (var game in games)
            {
                Button gameButton = new Button
                {
                    Text = game.GameName,
                    Size = new Size(150, 50),
                    BackColor = Color.SkyBlue,
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

            txtGameName.Text = game.GameName;
            txtDescription.Text = game.Description;
            txtPrice.Text = game.Price.ToString();
            picImages.ImageLocation = game.GameImage;
            txtDownloadPath.Text = game.DownloadPath;
            cmbReleaseStatus.SelectedItem = game.ReleaseStatus;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var game = new Game
            {
                GameName = txtGameName.Text,
                Description = txtDescription.Text,
                Price = decimal.Parse(txtPrice.Text),
                GameImage = picImages.ImageLocation,
                DownloadPath = txtDownloadPath.Text,
                ReleaseStatus = cmbReleaseStatus.SelectedItem.ToString()
            };

            GameDAL.UpdateGame(game);
            MessageBox.Show("Cập nhật game thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            flpGames.Controls.Clear();
            LoadGames();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            var game = new Game
            {
                GameName = txtNewGameName.Text,
                Description = txtNewDescription.Text,
                Price = decimal.Parse(txtNewPrice.Text),
                GameImage = picNewgameImages.ImageLocation,
                DownloadPath = txtNewDownloadPath.Text,
                ReleaseStatus = cmbNewReleaseStatus.SelectedItem.ToString()
            };

            GameDAL.AddGame(game);
            MessageBox.Show("Thêm game mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            flpGames.Controls.Clear();
            LoadGames();

        }

        private void LoadUsers()
        {
            var userDAL = new UserDAL();
            var users = userDAL.GetAllUsers();
            foreach (var user in users)
            {
                Button userButton = new Button
                {
                    Text = user.Username,
                    Size = new Size(150, 50),
                    BackColor = Color.LightGray,
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

            txtUsername.Text = user.Username;
            txtEmail.Text = user.Email;
            txtPhoneNumber.Text = user.PhoneNumber;
            txtBalance.Text = user.Balance.ToString();
            txtFullname.Text = user.FullName;
            // Load transactions to dgvTransactions
        }

        private void btnBanUser_Click(object sender, EventArgs e)
        {
            UserDAL.BanUser(userId);
            MessageBox.Show("Tài khoản người dùng đã bị cấm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            flpUsers.Controls.Clear();
            LoadUsers();
        }

        private void btnAddBalance_Click(object sender, EventArgs e)
        {
            var amount = decimal.Parse(txtAddBalanceAmount.Text);
            UserDAL.AddBalance(userId, amount);
            MessageBox.Show("Đã thêm tiền vào tài khoản người dùng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            flpUsers.Controls.Clear();
            LoadUsers();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            LoadGames();
            LoadUsers();
        }
    }
}
