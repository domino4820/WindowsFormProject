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

        public void AddOrUpdateUserGameDetails(UserGameDetails userGameDetails)
        {
            string query = "IF EXISTS (SELECT 1 FROM UserGameDetails WHERE UserId = @UserId AND GameId = @GameId) " +
                           "UPDATE UserGameDetails SET IsPurchased = @IsPurchased, IsInstalled = @IsInstalled, PurchaseDate = @PurchaseDate WHERE UserId = @UserId AND GameId = @GameId " +
                           "ELSE " +
                           "INSERT INTO UserGameDetails (UserId, GameId, IsPurchased, IsInstalled, PurchaseDate) VALUES (@UserId, @GameId, @IsPurchased, @IsInstalled, @PurchaseDate)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserId", userGameDetails.UserId);
                cmd.Parameters.AddWithValue("@GameId", userGameDetails.GameId);
                cmd.Parameters.AddWithValue("@IsPurchased", userGameDetails.IsPurchased);
                cmd.Parameters.AddWithValue("@IsInstalled", userGameDetails.IsInstalled);
                cmd.Parameters.AddWithValue("@PurchaseDate", userGameDetails.PurchaseDate);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public UserGameDetails GetUserGameDetails(int userId, int gameId)
        {
            UserGameDetails userGameDetails = null;
            string query = "SELECT UserId, GameId, IsPurchased, IsInstalled, PurchaseDate FROM UserGameDetails WHERE UserId = @UserId AND GameId = @GameId";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@GameId", gameId);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    userGameDetails = new UserGameDetails
                    {
                        UserId = (int)reader["UserId"],
                        GameId = (int)reader["GameId"],
                        IsPurchased = (bool)reader["IsPurchased"],
                        IsInstalled = (bool)reader["IsInstalled"],
                        PurchaseDate = (DateTime)reader["PurchaseDate"]
                    };
                }
            }

            return userGameDetails;
        }

        public void UpdateInstallationPath(int userId, int gameId, string installationPath, bool isInstalled)
        {
            string query = "UPDATE UserGameDetails SET InstallationPath = @InstallationPath, IsInstalled = @IsInstalled WHERE UserId = @UserId AND GameId = @GameId";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@GameId", gameId);
                cmd.Parameters.AddWithValue("@InstallationPath", installationPath);
                cmd.Parameters.AddWithValue("@IsInstalled", isInstalled);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}