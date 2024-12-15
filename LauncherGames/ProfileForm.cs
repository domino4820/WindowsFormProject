using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Azure.Identity;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Microsoft.Data.SqlClient;

namespace LauncherGames
{
    public partial class ProfileForm : Form
    {
        private string username;

        public ProfileForm(string username)
        {
            InitializeComponent();
            this.username = username;
        }
        public ProfileForm()
        {
            InitializeComponent();
            this.username = username;
        }


        private void LoadUserProfile()
        {
            string connectionString = "Server=DESKTOP-83LI0FP;Database=LauncherGames;Trusted_Connection=True;TrustServerCertificate=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT FullName FROM Users WHERE Username = @Username";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);

                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            string fullName = result.ToString();
                            lblUsername.Text = $"Chào mừng, {fullName}";
                        }
                        else
                        {
                            lblUsername.Text = "Không tìm thấy thông tin người dùng.";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi");
                }
            }
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {
            LoadUserProfile();
        }
    }
}
