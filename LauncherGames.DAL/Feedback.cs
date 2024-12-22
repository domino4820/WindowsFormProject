using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauncherGames.DAL
{
    public class Feedback
    {
        public int FeedbackId { get; set; }
        public int UserId { get; set; }
        public int GameId { get; set; }
        public string FeedbackText { get; set; }
        public DateTime FeedbackDate { get; set; }
    }
}
