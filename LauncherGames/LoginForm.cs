using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using LauncherGames.BLL.Services.Interface;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using LauncherGames.DAL.Models;

namespace LauncherGames
{
    public partial class LoginForm : Form
    {
        private readonly IUserService _userService;
        private readonly ILogger<LoginForm> _logger;

        public LoginForm(IUserService userService, ILogger<LoginForm> logger)
        {
            InitializeComponent();
            _userService = userService;
            _logger = logger;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtLoginUsername.Text.Trim();
            string password = txtLoginPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Tên đăng nhập và mật khẩu không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _logger.LogWarning("Login attempt with empty username or password.");
                return;
            }

            var (success, user) = await _userService.AuthenticateAsync(username, password);

            if (success)
            {
                _logger.LogInformation("User '{Username}' logged in successfully", username);

                if (await _userService.IsBannedAsync(user.UserId))
                {
                    _logger.LogWarning("User '{Username}' is banned", username);
                    MessageBox.Show("Tài khoản của bạn đã bị khóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ClearTextBoxes(pnlLogin);
                var launcherForm = new LauncherForm(user.UserId, username, Program.ServiceProvider);
                this.Hide();
                launcherForm.Show();
                launcherForm.FormClosed += (s, args) => this.Close();
            }
            else
            {
                _logger.LogWarning("Failed login attempt for user '{Username}'", username);
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string fullName = txtFullName.Text;
            string email = txtEmail.Text;
            string phoneNumber = txtPhoneNumber.Text;

            try
            {
                if (txtPassword.Text != txtPassword2.Text)
                {
                    throw new Exception("Mật khẩu không khớp!");
                }

                var newUser = new User
                {
                    Username = username,
                    Password = password,
                    FullName = fullName,
                    PhoneNumber = phoneNumber,
                    Email = email,
                    Balance = 0,
                    IsAdmin = false,
                    IsBanned = false,
                    CreatedAt = DateTime.Now
                };

                try
                {
                    await _userService.RegisterAsync(newUser);
                    _logger.LogInformation("User '{Username}' registered successfully", username);
                    MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearTextBoxes(pnlRegister);
                    pnlRegister.Visible = false;
                    pnlLogin.Visible = true;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Failed to register user '{Username}'", username);
                    MessageBox.Show($"Đăng ký không thành công: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during registration for user '{Username}'", username);
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearTextBoxes(Panel panel)
        {
            foreach (Control control in panel.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Text = string.Empty;
                }
            }
        }

        private void lblBackToLogin_Click(object sender, EventArgs e)
        {
            pnlRegister.Visible = false;
            pnlLogin.Visible = true;
        }

        private void lblGoToRegister_Click(object sender, EventArgs e)
        {
            pnlLogin.Visible = false;
            pnlRegister.Visible = true;
        }
    }
}