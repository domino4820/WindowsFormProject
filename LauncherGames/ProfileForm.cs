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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
                    string query = "SELECT FullName, PhoneNumber, Email FROM Users WHERE Username = @Username";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtFullName.Text = reader["FullName"].ToString();
                                txtSDT.Text = reader["PhoneNumber"].ToString();
                                txtEmail.Text = reader["Email"].ToString();
                                lblUsername.Text = $"Chào mừng, {reader["FullName"]}";
                            }
                            else
                            {
                                lblUsername.Text = "Không tìm thấy thông tin người dùng.";
                            }
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

        private void txtFullName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCapNhatMK_Click(object sender, EventArgs e)
        {
            string currentPassword = txtPassword.Text.Trim();
            string newPassword = txtNewPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(currentPassword) || string.IsNullOrWhiteSpace(newPassword) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo");
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu không khớp.", "Lỗi");
                return;
            }

            string connectionString = "Server=DESKTOP-83LI0FP;Database=LauncherGames;Trusted_Connection=True;TrustServerCertificate=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT Password FROM Users WHERE Username = @Username";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);

                        object result = command.ExecuteScalar();
                        if (result != null && result.ToString() == currentPassword)
                        {
                            // Đổi mật khẩu
                            query = "UPDATE Users SET Password = @NewPassword WHERE Username = @Username";
                            using (SqlCommand updateCommand = new SqlCommand(query, connection))
                            {
                                updateCommand.Parameters.AddWithValue("@NewPassword", newPassword);
                                updateCommand.Parameters.AddWithValue("@Username", username);

                                int rowsAffected = updateCommand.ExecuteNonQuery(); 
                                if (rowsAffected > 0) 
                                { 
                                    MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo"); 
                                } 
                                else 
                                { 
                                    MessageBox.Show("Không thể đổi mật khẩu.", "Lỗi"); 
                                }
                            }
                        }
                        else { MessageBox.Show("Mật khẩu hiện tại không đúng.", "Lỗi"); }
                    }
                }
                catch (Exception ex) { MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi"); }
            }
        }


        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string phoneNumber = txtSDT.Text.Trim();
            string email = txtEmail.Text.Trim();

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(phoneNumber) || string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo");
                return;
            }

            // Chặn ký tự lạ ở số điện thoại
            if (!System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, @"^\d+$"))
            {
                MessageBox.Show("Số điện thoại chỉ chứa số.", "Lỗi");
                return;
            }

            // Chuỗi kết nối cơ sở dữ liệu
            string connectionString = "Server=DESKTOP-83LI0FP;Database=LauncherGames;Trusted_Connection=True;TrustServerCertificate=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE Users SET FullName = @FullName, PhoneNumber = @PhoneNumber, Email = @Email WHERE Username = @Username";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FullName", fullName);
                        command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Username", username);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo");
                            lblUsername.Text = $"Chào mừng, {fullName}"; // Cập nhật tên hiển thị
                        }
                        else
                        {
                            MessageBox.Show("Không thể cập nhật thông tin.", "Lỗi");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi");
                }
            }
        }


    }
}
