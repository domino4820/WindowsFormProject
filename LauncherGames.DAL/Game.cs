using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauncherGames.DAL
{
    public class Game
    {
        public int GameId { get; set; }
        public string GameName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsExclusive { get; set; }
        public string GameImage { get; set; }
        public DateTime CreatedAt { get; set; }
        public string DownloadPath { get; set; }
        public string RunPath { get; set; }
        public string ReleaseStatus { get; set; }
    }
}
