using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace LauncherGames.Models
{
    internal class GameRepository
    {
        private DatabaseHelper dbHelper = new DatabaseHelper();

        public List<string> GetGames()
        {
            string query = "SELECT GameName FROM Games";
            List<string> games = new List<string>();

            using (SqlConnection conn = dbHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    games.Add(reader["GameName"].ToString());
                }
            }

            return games;
        }
    }
}
