using System;
using Microsoft.Data.SqlClient;

namespace LauncherGames.DAL
{
    public static class GameStateManager
    {
        private static string connectionString = "Data Source=DESKTOP-83LI0FP;Initial Catalog=LauncherGamesDB;Integrated Security=True;Encrypt=False;Trust Server Certificate=True";

        public static GameState GetGameState(int gameId)
        {
            GameState gameState = new GameState();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT DownloadPath FROM UserGameDetails WHERE GameId= @GameId";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@GameId", gameId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    gameState.DownloadPath = reader["DownloadPath"].ToString();
                }
            }

            return gameState;
        }


        public static void SetGameInstalled(string gameName, bool isInstalled, string gameDirectory)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE UserGameDetails SET IsInstalled = @IsInstalled, GameDirectory = @GameDirectory WHERE GameName = @GameName";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IsInstalled", isInstalled);
                cmd.Parameters.AddWithValue("@GameDirectory", (object)gameDirectory ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@GameName", gameName);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }

    public class GameState
    {
        public bool IsInstalled { get; set; }
        public string GameDirectory { get; set; }
        public string DownloadPath { get; set; }
    }
}