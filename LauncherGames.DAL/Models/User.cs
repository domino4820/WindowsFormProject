using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauncherGames.DAL.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public decimal Balance { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsBanned { get; set; }
        public string? Avatar { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public virtual ICollection<UserGameDetail> UserGameDetails { get; set; } = new List<UserGameDetail>();
        public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
        public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
    }
}
