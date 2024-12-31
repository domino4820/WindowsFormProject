using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using LauncherGames.BLL.Services.Interface;
using LauncherGames.DAL.Models;
using Microsoft.Extensions.DependencyInjection;

namespace LauncherGames
{
    public partial class ProfileForm : Form
    {
        private readonly IUserService _userService;
        private string _username;
        private User _currentUser;

        public ProfileForm(string username)
        {
            InitializeComponent();
            _username = username;

            // Sử dụng Dependency Injection để lấy dịch vụ IUserService
            _userService = Program.ServiceProvider.GetRequiredService<IUserService>();
        }

        private async void LoadUserProfile()
        {
            _currentUser = await _userService.GetUserByUsernameAsync(_username);
            if (_currentUser != null)
            {
                // Hiển thị thông tin người dùng lên các TextBox
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

        private void ProfileForm_Load_1(object sender, EventArgs e)
        {
            LoadUserProfile();
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

            // Ghi log: Hiển thị thông tin trước khi cập nhật
            LogToFile($"Updating user: {_currentUser.UserId}, {_currentUser.FullName}, {_currentUser.PhoneNumber}, {_currentUser.Email}");
            // Cập nhật thông tin người dùng
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

        
    }
}