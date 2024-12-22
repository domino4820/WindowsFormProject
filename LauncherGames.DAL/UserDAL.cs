using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient; // Ensure this using directive is present
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauncherGames.DAL
{
    public class UserDAL
    {
        private string connectionString = "Data Source=DESKTOP-83LI0FP;Initial Catalog=LauncherGamesDB;Integrated Security=True;Encrypt=False;Trust Server Certificate=True";
        public User GetUserById(int id)
        {
            User user = null;
            string query = "SELECT * FROM Users WHERE UserId = @UserId";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserId", id);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    user = new User
                    {
                        UserId = (int)reader["UserId"],
                        Username = (string)reader["Username"],
                        Password = (string)reader["Password"],
                        FullName = (string)reader["FullName"],
                        PhoneNumber = reader["PhoneNumber"] as string,
                        Email = reader["Email"] as string,
                        Balance = (decimal)reader["Balance"],
                        IsAdmin = (bool)reader["IsAdmin"],
                        IsBanned = (bool)reader["IsBanned"],
                        Avatar = reader["Avatar"] as string,
                        CreatedAt = (DateTime)reader["CreatedAt"]
                    };
                }
            }

            return user;
        }

        public void AddUser(User user)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Users (Username, Password, FullName, Avatar) VALUES (@Username, @Password, @FullName, @Avatar)", conn);
                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@FullName", user.FullName);
                cmd.Parameters.AddWithValue("@Avatar", (object)user.Avatar ?? DBNull.Value); // Handle null Avatar
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateUser(User user)
        {
            string query = "UPDATE Users SET Username = @Username, Password = @Password, FullName = @FullName, PhoneNumber = @PhoneNumber, " +
                           "Email = @Email, Balance = @Balance, IsAdmin = @IsAdmin, IsBanned = @IsBanned, Avatar = @Avatar, CreatedAt = @CreatedAt " +
                           "WHERE UserId = @UserId";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserId", user.UserId);
                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@FullName", user.FullName);
                cmd.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Balance", user.Balance);
                cmd.Parameters.AddWithValue("@IsAdmin", user.IsAdmin);
                cmd.Parameters.AddWithValue("@IsBanned", user.IsBanned);
                cmd.Parameters.AddWithValue("@Avatar", user.Avatar);
                cmd.Parameters.AddWithValue("@CreatedAt", user.CreatedAt);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            string query = "SELECT * FROM Users";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    User user = new User
                    {
                        UserId = (int)reader["UserId"],
                        Username = (string)reader["Username"],
                        Password = (string)reader["Password"],
                        FullName = (string)reader["FullName"],
                        PhoneNumber = reader["PhoneNumber"] as string,
                        Email = reader["Email"] as string,
                        Balance = (decimal)reader["Balance"],
                        IsAdmin = (bool)reader["IsAdmin"],
                        IsBanned = (bool)reader["IsBanned"],
                        Avatar = reader["Avatar"] as string,
                        CreatedAt = (DateTime)reader["CreatedAt"]
                    };
                    users.Add(user);
                }
            }

            return users;
        }

        public decimal GetUserBalance(int userId)
        {
            string query = "SELECT Balance FROM Users WHERE UserId = @UserId";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserId", userId);
                conn.Open();

                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    return (decimal)result;
                }
                return 0;
            }
        }

        public void UpdateUserBalance(int userId, decimal newBalance)
        {
            string query = "UPDATE Users SET Balance = @Balance WHERE UserId = @UserId";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Balance", newBalance);
                cmd.Parameters.AddWithValue("@UserId", userId);
                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}
