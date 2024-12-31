using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LauncherGames.DAL.Models;

namespace LauncherGames.DAL.Models
{
    public class Game
    {
        public int GameId { get; set; }
        public string GameName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public bool IsExclusive { get; set; }
        public string? GameImage { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? DownloadPath { get; set; }
        public string? RunPath { get; set; }
        public string ReleaseStatus { get; set; } = string.Empty;

        // Navigation properties
        public virtual ICollection<UserGameDetail> UserGameDetails { get; set; } = new List<UserGameDetail>();
        public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
    }
}