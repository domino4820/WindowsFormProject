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

        public static void AddOrUpdateUserGameDetails(UserGameDetails userGameDetails)
        {
            string connectionString = "Data Source=DESKTOP-83LI0FP;Initial Catalog=LauncherGamesDB;Integrated Security=True;Encrypt=False;Trust Server Certificate=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                IF EXISTS (SELECT 1 FROM UserGameDetails WHERE UserId = @UserId AND GameId = @GameId)
                BEGIN
                    UPDATE UserGameDetails
                    SET IsPurchased = @IsPurchased,
                        IsInstalled = @IsInstalled,
                        PurchaseDate = @PurchaseDate,
                        DownloadPath = @DownloadPath
                    WHERE UserId = @UserId AND GameId = @GameId
                END
                ELSE
                BEGIN
                    INSERT INTO UserGameDetails (UserId, GameId, IsPurchased, IsInstalled, PurchaseDate, DownloadPath)
                    VALUES (@UserId, @GameId, @IsPurchased, @IsInstalled, @PurchaseDate, @DownloadPath)
                END";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserId", userGameDetails.UserId);
                cmd.Parameters.AddWithValue("@GameId", userGameDetails.GameId);
                cmd.Parameters.AddWithValue("@IsPurchased", userGameDetails.IsPurchased);
                cmd.Parameters.AddWithValue("@IsInstalled", userGameDetails.IsInstalled);
                cmd.Parameters.AddWithValue("@PurchaseDate", userGameDetails.PurchaseDate);
                cmd.Parameters.AddWithValue("@DownloadPath", userGameDetails.DownloadPath);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public UserGameDetails GetUserGameDetails(int userId, int gameId)
        {
            UserGameDetails userGameDetails = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM UserGameDetails WHERE UserId = @UserId AND GameId = @GameId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@GameId", gameId);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            userGameDetails = new UserGameDetails
                            {
                                UserGameId = reader.GetInt32(reader.GetOrdinal("UserGameId")),
                                UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                                GameId = reader.GetInt32(reader.GetOrdinal("GameId")),
                                IsPurchased = reader.GetBoolean(reader.GetOrdinal("IsPurchased")),
                                IsInstalled = reader.GetBoolean(reader.GetOrdinal("IsInstalled")),
                                InstallationPath = reader.IsDBNull(reader.GetOrdinal("InstallationPath")) ? null : reader.GetString(reader.GetOrdinal("InstallationPath")),
                                PurchaseDate = reader.IsDBNull(reader.GetOrdinal("PurchaseDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("PurchaseDate")),
                                DownloadPath = reader.IsDBNull(reader.GetOrdinal("DownloadPath")) ? null : reader.GetString(reader.GetOrdinal("DownloadPath"))
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception and rethrow it
                Console.WriteLine($"An error occurred while fetching game details: {ex.Message}");
                throw;
            }

            // Trả về đối tượng mặc định nếu không tìm thấy thông tin
            if (userGameDetails == null)
            {
                userGameDetails = new UserGameDetails
                {
                    UserGameId = 0,
                    UserId = userId,
                    GameId = gameId,
                    IsPurchased = false,
                    IsInstalled = false,
                    InstallationPath = null,
                    PurchaseDate = null,
                    DownloadPath = null
                };
            }

            return userGameDetails;
        }


        public static void UpdateInstallationPath(int userId, int gameId, string installationPath)
        {
            string connectionString = "Data Source=DESKTOP-83LI0FP;Initial Catalog=LauncherGamesDB;Integrated Security=True;Encrypt=False;Trust Server Certificate=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE UserGameDetails SET InstallationPath = @InstallationPath WHERE UserId = @UserId AND GameId = @GameId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@InstallationPath", installationPath);
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@GameId", gameId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static string GetDownloadPath(int userId, int gameId)
        {
            string downloadPath = string.Empty;
            string connectionString = "Data Source=DESKTOP-83LI0FP;Initial Catalog=LauncherGamesDB;Integrated Security=True;Encrypt=False;Trust Server Certificate=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT DownloadPath FROM UserGameDetails WHERE UserId = @UserId AND GameId = @GameId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@GameId", gameId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    downloadPath = reader["DownloadPath"].ToString();
                }
            }

            return downloadPath;
        }

        public static void SetGameInstalled(int userId, int gameId, string installationPath, bool isInstalled)
        {
            string connectionString = "Data Source=DESKTOP-83LI0FP;Initial Catalog=LauncherGamesDB;Integrated Security=True;Encrypt=False;Trust Server Certificate=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE UserGameDetails SET InstallationPath = @InstallationPath, IsInstalled = @IsInstalled WHERE UserId = @UserId AND GameId = @GameId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@GameId", gameId);
                cmd.Parameters.AddWithValue("@InstallationPath", installationPath);
                cmd.Parameters.AddWithValue("@IsInstalled", isInstalled);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void DeleteGame(int userId, int gameId, string installationPath, bool isInstalled)
        {
            string connectionString = "Data Source=DESKTOP-83LI0FP;Initial Catalog=LauncherGamesDB;Integrated Security=True;Encrypt=False;Trust Server Certificate=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE UserGameDetails SET InstallationPath = NULL, IsInstalled = 0 WHERE UserId = @UserId AND GameId = @GameId;";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@GameId", gameId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }


    }
}