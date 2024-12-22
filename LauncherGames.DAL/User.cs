using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauncherGames.DAL
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public decimal Balance { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsBanned { get; set; }
        public string Avatar { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
