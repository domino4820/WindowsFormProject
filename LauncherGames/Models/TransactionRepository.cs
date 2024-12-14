using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace LauncherGames.Models
{
    internal class TransactionRepository
    {
        private DatabaseHelper dbHelper = new DatabaseHelper();

        public bool AddTransaction(int userId, int gameId, decimal amount)
        {
            string query = "INSERT INTO Transactions (UserId, GameId, Amount, TransactionDate) VALUES (@UserId, @GameId, @Amount, GETDATE())";

            using (SqlConnection conn = dbHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@GameId", gameId);
                cmd.Parameters.AddWithValue("@Amount", amount);

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
    }
}
