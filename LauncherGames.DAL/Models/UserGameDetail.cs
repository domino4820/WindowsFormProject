using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauncherGames.DAL.Models
{
    public class UserGameDetail
    {
        public int UserGameId { get; set; }
        public int UserId { get; set; }
        public int GameId { get; set; }
        public bool IsPurchased { get; set; }
        public bool IsInstalled { get; set; }
        public string? InstallationPath { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public string? DownloadPath { get; set; }

        // Navigation properties
        public virtual User User { get; set; } = null!;
        public virtual Game Game { get; set; } = null!;
    }

}
