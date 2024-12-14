using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace LauncherGames.Helpers
{
    public static class GameStateManager
    {
        private static readonly string StateFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "GameStates.json");

        public static Dictionary<string, (bool IsInstalled, string GameDirectory)> GameStates = new Dictionary<string, (bool, string)>();

        static GameStateManager()
        {
            LoadStates();
        }

        public static void SetGameInstalled(string gameName, bool isInstalled, string gameDirectory)
        {
            GameStates[gameName] = (isInstalled, gameDirectory);
            SaveStates();
        }



        public static bool IsGameInstalled(string gameName)
        {
            return GameStates.ContainsKey(gameName) && GameStates[gameName].IsInstalled;
        }

        public static (bool IsInstalled, string GameDirectory) GetGameState(string gameName)
        {
            if (GameStates.ContainsKey(gameName))
            {
                return GameStates[gameName];
            }
            return (false, null);
        }


        private static void SaveStates()
        {
            File.WriteAllText(StateFilePath, JsonConvert.SerializeObject(GameStates, Formatting.Indented));
        }

        private static void LoadStates()
        {
            if (File.Exists(StateFilePath))
            {
                try
                {
                    GameStates = JsonConvert.DeserializeObject<Dictionary<string, (bool IsInstalled, string GameDirectory)>>(File.ReadAllText(StateFilePath));
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tải trạng thái game: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    GameStates = new Dictionary<string, (bool, string)>(); 
                }
            }
            else
            {
                GameStates = new Dictionary<string, (bool, string)>(); 
            }
        }

    }
}
