using LauncherGames.BLL;
using LauncherGames.DAL;
using LauncherGames.Presentation;

namespace WinForms_Subject
{
    public partial class LoginForm : Form
    {
        private UserBLL userBLL;
        public LoginForm()
        {
            InitializeComponent();
            userBLL = new UserBLL();
        }

        private void lblGoToRegister_Click(object sender, EventArgs e)
        {
            pnlLogin.Visible = false;
            pnlRegister.Visible = true;
        }

        private void lblBackToLogin_Click(object sender, EventArgs e)
        {
            pnlRegister.Visible = false;
            pnlLogin.Visible = true;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPassword.Text != txtPassword2.Text)
                {
                    throw new Exception("Passwords do not match.");
                }
                User user = new User
                {
                    Username = txtUsername.Text,
                    Password = txtPassword.Text,
                    FullName = txtFullName.Text,
                    PhoneNumber = txtPhoneNumber.Text,
                    Email = txtEmail.Text,
                    Balance = 0, // Initial balance
                    IsAdmin = false,
                    IsBanned = false,
                    Avatar = null, // Set Avatar to null if it is not provided
                    CreatedAt = DateTime.Now
                };

                bool isRegistered = userBLL.RegisterUser(user);

                if (isRegistered)
                {
                    MessageBox.Show("Registration successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearTextBoxes(pnlRegister);
                    // Navigate to LoginForm
                    LoginForm loginForm = new LoginForm();
                    loginForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Registration failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtLoginUsername.Text;
            string password = txtLoginPassword.Text;

            bool isAuthenticated = userBLL.LoginUser(username, password);

            if (isAuthenticated)
            {
                ClearTextBoxes(pnlLogin);
                LauncherForm launcherForm = new LauncherForm();
                launcherForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

    }
}