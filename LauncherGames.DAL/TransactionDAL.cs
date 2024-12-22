using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace LauncherGames.DAL
{
    public class TransactionDAL
    {
        private string connectionString = "Data Source=DESKTOP-83LI0FP;Initial Catalog=LauncherGamesDB;Integrated Security=True;Encrypt=False;Trust Server Certificate=True";

        public List<Transaction> GetTransactionsByUserId(int userId)
        {
            List<Transaction> transactions = new List<Transaction>();
            string query = "SELECT TransactionId, UserId, GameId, PaymentMethod, Amount, AmountInVND, Status, TransactionDate FROM Transactions WHERE UserId = @UserId";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserId", userId);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Transaction transaction = new Transaction
                    {
                        TransactionId = (int)reader["TransactionId"],
                        UserId = (int)reader["UserId"],
                        GameId = (int)reader["GameId"],
                        PaymentMethod = reader["PaymentMethod"].ToString(),
                        Amount = (decimal)reader["Amount"],
                        AmountInVND = (decimal)reader["AmountInVND"],
                        Status = reader["Status"].ToString(),
                        TransactionDate = (DateTime)reader["TransactionDate"]
                    };
                    transactions.Add(transaction);
                }
            }

            return transactions;
        }

        public void AddTransaction(Transaction transaction)
        {
            string query = "INSERT INTO Transactions (UserId, GameId, PaymentMethod, Amount, AmountInVND, Status, TransactionDate) " +
                           "VALUES (@UserId, @GameId, @PaymentMethod, @Amount, @AmountInVND, @Status, @TransactionDate)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserId", transaction.UserId);
                cmd.Parameters.AddWithValue("@GameId", transaction.GameId);
                cmd.Parameters.AddWithValue("@PaymentMethod", transaction.PaymentMethod);
                cmd.Parameters.AddWithValue("@Amount", transaction.Amount);
                cmd.Parameters.AddWithValue("@AmountInVND", transaction.AmountInVND);
                cmd.Parameters.AddWithValue("@Status", transaction.Status);
                cmd.Parameters.AddWithValue("@TransactionDate", transaction.TransactionDate);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}