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

        public static List<Game> GetAllGames()
        {
            string connectionString = "Data Source=DESKTOP-83LI0FP;Initial Catalog=LauncherGamesDB;Integrated Security=True;Encrypt=False;Trust Server Certificate=True";
            List<Game> games = new List<Game>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Games";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Game game = new Game
                        {
                            GameId = reader.GetInt32(reader.GetOrdinal("GameId")),
                            GameName = reader.GetString(reader.GetOrdinal("GameName")),
                            Description = reader.GetString(reader.GetOrdinal("Description")),
                            Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                            GameImage = reader.GetString(reader.GetOrdinal("GameImage")),
                            DownloadPath = reader.GetString(reader.GetOrdinal("DownloadPath")),
                            ReleaseStatus = reader.GetString(reader.GetOrdinal("ReleaseStatus"))
                        };
                        games.Add(game);
                    }
                }
            }

            return games;
        }

        public static void AddGame(Game game)
        {
            string connectionString = "Data Source=DESKTOP-83LI0FP;Initial Catalog=LauncherGamesDB;Integrated Security=True;Encrypt=False;Trust Server Certificate=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Games (GameName, Description, Price, GameImage, DownloadPath, ReleaseStatus) VALUES (@GameName, @Description, @Price, @GameImage, @DownloadPath, @ReleaseStatus)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@GameName", game.GameName);
                cmd.Parameters.AddWithValue("@Description", game.Description);
                cmd.Parameters.AddWithValue("@Price", game.Price);
                cmd.Parameters.AddWithValue("@GameImage", game.GameImage);
                cmd.Parameters.AddWithValue("@DownloadPath", game.DownloadPath);
                cmd.Parameters.AddWithValue("@ReleaseStatus", game.ReleaseStatus);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void UpdateGame(Game game)
        {
            string connectionString = "Data Source=DESKTOP-83LI0FP;Initial Catalog=LauncherGamesDB;Integrated Security=True;Encrypt=False;Trust Server Certificate=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Games SET GameName = @GameName, Description = @Description, Price = @Price, GameImage = @GameImage, DownloadPath = @DownloadPath, ReleaseStatus = @ReleaseStatus WHERE GameId = @GameId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@GameId", game.GameId);
                cmd.Parameters.AddWithValue("@GameName", game.GameName);
                cmd.Parameters.AddWithValue("@Description", game.Description);
                cmd.Parameters.AddWithValue("@Price", game.Price);
                cmd.Parameters.AddWithValue("@GameImage", game.GameImage);
                cmd.Parameters.AddWithValue("@DownloadPath", game.DownloadPath);
                cmd.Parameters.AddWithValue("@ReleaseStatus", game.ReleaseStatus);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void DeleteGame(int gameId)
        {
            string connectionString = "Data Source=DESKTOP-83LI0FP;Initial Catalog=LauncherGamesDB;Integrated Security=True;Encrypt=False;Trust Server Certificate=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Games WHERE GameId = @GameId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@GameId", gameId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Game GetGameById(int gameId)
        {
            Game game = null;
            string query = "SELECT GameId, GameName, Description, Price, IsExclusive, GameImage, CreatedAt, DownloadPath, RunPath FROM Games WHERE GameId = @GameId";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@GameId", gameId);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    game = new Game
                    {
                        GameId = (int)reader["GameId"],
                        GameName = reader["GameName"].ToString(),
                        Description = reader["Description"].ToString(),
                        Price = (decimal)reader["Price"],
                        IsExclusive = (bool)reader["IsExclusive"],
                        GameImage = reader["GameImage"].ToString(),
                        CreatedAt = (DateTime)reader["CreatedAt"],
                        DownloadPath = reader["DownloadPath"].ToString(),
                        RunPath = reader["RunPath"].ToString()
                    };
                }
            }

            return game;
        }
    }
}