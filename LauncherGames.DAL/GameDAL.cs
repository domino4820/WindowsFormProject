using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace LauncherGames.DAL
{
    public class GameDAL
    {
        private string connectionString = "Data Source=DESKTOP-83LI0FP;Initial Catalog=LauncherGamesDB;Integrated Security=True;Encrypt=False;Trust Server Certificate=True";

        public List<Game> GetGamesByStatus(string status)
        {
            List<Game> games = new List<Game>();
            string query = "SELECT * FROM Games WHERE ReleaseStatus = @Status";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Status", status);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Game game = new Game
                    {
                        GameId = (int)reader["GameId"],
                        GameName = (string)reader["GameName"],
                        Description = reader["Description"] as string,
                        Price = (decimal)reader["Price"],
                        IsExclusive = (bool)reader["IsExclusive"],
                        GameImage = reader["GameImage"] as string,
                        CreatedAt = (DateTime)reader["CreatedAt"],
                        DownloadPath = reader["DownloadPath"] as string,
                        RunPath = reader["RunPath"] as string,
                        ReleaseStatus = (string)reader["ReleaseStatus"]
                    };
                    games.Add(game);
                }
            }

            return games;
        }

        public List<Game> GetAllGames()
        {
            List<Game> games = new List<Game>();
            string query = "SELECT * FROM Games";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Game game = new Game
                    {
                        GameId = (int)reader["GameId"],
                        GameName = (string)reader["GameName"],
                        Description = reader["Description"] as string,
                        Price = (decimal)reader["Price"],
                        IsExclusive = (bool)reader["IsExclusive"],
                        GameImage = reader["GameImage"] as string,
                        CreatedAt = (DateTime)reader["CreatedAt"],
                        DownloadPath = reader["DownloadPath"] as string,
                        RunPath = reader["RunPath"] as string,
                        ReleaseStatus = reader["ReleaseStatus"] as string
                    };
                    games.Add(game);
                }
            }

            return games;
        }
    }
}