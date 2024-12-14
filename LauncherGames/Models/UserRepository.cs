using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace LauncherGames.Models
{
    internal class UserRepository
    {
        private string connectionString = "Server=YOUR_SERVER;Database=Games;Trusted_Connection=True;";

        public bool RegisterUser(string username, string password, string fullName, string phoneNumber, string email)
        {
            string query = "INSERT INTO Users (Username, Password, FullName, PhoneNumber, Email, Balance, CreatedAt) " +
                           "VALUES (@Username, @Password, @FullName, @PhoneNumber, @Email, 0, GETDATE())";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@FullName", fullName);
                    cmd.Parameters.AddWithValue("@PhoneNumber", string.IsNullOrEmpty(phoneNumber) ? DBNull.Value : phoneNumber);
                    cmd.Parameters.AddWithValue("@Email", email);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL Error: {ex.Message}");
                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    return false;
                }
            }
        }
    }
}
