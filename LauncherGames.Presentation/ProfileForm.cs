using System;
using System.Windows.Forms;
using LauncherGames.BLL;
using LauncherGames.DAL;

namespace LauncherGames.Presentation
{
    public partial class ProfileForm : Form
    {
        private UserBLL userBLL;
        private string username;
        private User currentUser;

        public ProfileForm(string username, int userId)
        {
            InitializeComponent();
            this.username = username;
            userBLL = new UserBLL();
        }

        private void LoadUserProfile()
        {
            currentUser = userBLL.GetUserByUsername(username);
            if (currentUser != null)
            {
                // Hiển thị thông tin người dùng lên các TextBox
                txtFullName.Text = currentUser.FullName;
                txtSDT.Text = currentUser.PhoneNumber;
                txtEmail.Text = currentUser.Email;
                lblUsername.Text = $"Chào mừng, {currentUser.FullName}";
            }
            else
            {
                lblUsername.Text = "Không tìm thấy thông tin người dùng.";
            }
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {
            LoadUserProfile();
        }

        private void btnCapNhatMK_Click(object sender, EventArgs e)
        {
            if (currentUser == null)
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

            if (currentPassword != currentUser.Password)
            {
                MessageBox.Show("Mật khẩu hiện tại không đúng.", "Lỗi");
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu không khớp.", "Lỗi");
                return;
            }

            userBLL.ChangePassword(username, newPassword);
            MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo");
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            if (currentUser == null)
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

            currentUser.FullName = fullName;
            currentUser.PhoneNumber = phoneNumber;
            currentUser.Email = email;

            // Ghi log: Hiển thị thông tin trước khi cập nhật
            LogToFile($"Updating user: {currentUser.UserId}, {currentUser.FullName}, {currentUser.PhoneNumber}, {currentUser.Email}");
            // Cập nhật thông tin người dùng
            userBLL.UpdateUser(currentUser);
            MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo");
            lblUsername.Text = $"Chào mừng, {currentUser.FullName}";
        }

        private void LogToFile(string message)
        {
            string filePath = "debug_log.txt";
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"{DateTime.Now}: {message}");
            }
        }
    }
}