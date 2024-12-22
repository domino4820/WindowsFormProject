using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace LauncherGames.DAL
{
    public class UserGameDetails
    {
        public int UserGameId { get; set; }
        public int UserId { get; set; }
        public int GameId { get; set; }
        public bool IsPurchased { get; set; }
        public bool IsInstalled { get; set; }
        public string InstallationPath { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public string DownloadPath { get; set; }
    }
}
