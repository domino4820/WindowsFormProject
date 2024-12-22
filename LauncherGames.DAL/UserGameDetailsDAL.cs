using Microsoft.Data.SqlClient;

namespace LauncherGames.DAL
{
    public class UserGameDetailsDAL
    {
        private string connectionString = "Data Source=DESKTOP-83LI0FP;Initial Catalog=LauncherGamesDB;Integrated Security=True;Encrypt=False;Trust Server Certificate=True";

        public bool IsGamePurchasedByUser(int userId, int gameId)
        {
            string query = "SELECT IsPurchased FROM UserGameDetails WHERE UserId = @UserId AND GameId = @GameId";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@GameId", gameId);
                conn.Open();

                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    return (bool)result;
                }
                return false;
            }
        }

        public bool IsGameInstalledByUser(int userId, int gameId)
        {
            string query = "SELECT IsInstalled FROM UserGameDetails WHERE UserId = @UserId AND GameId = @GameId";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@GameId", gameId);
                conn.Open();

                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    return (bool)result;
                }
                return false;
            }
        }

        public void MarkGameAsPurchased(int userId, int gameId)
        {
            string query = "UPDATE UserGameDetails SET IsPurchased = 1 WHERE UserId = @UserId AND GameId = @GameId";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@GameId", gameId);
                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public void MarkGameAsInstalled(int userId, int gameId)
        {
            string query = "UPDATE UserGameDetails SET IsInstalled = 1 WHERE UserId = @UserId AND GameId = @GameId";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@GameId", gameId);
                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}