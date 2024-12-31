using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauncherGames.DAL.Models
{
    public class Feedback
    {
        public int FeedbackId { get; set; }
        public int UserId { get; set; }
        public int GameId { get; set; }
        public string? FeedbackText { get; set; }
        public DateTime FeedbackDate { get; set; }

        // Navigation properties
        public virtual User User { get; set; } = null!;
        public virtual Game Game { get; set; } = null!;
    }
}
