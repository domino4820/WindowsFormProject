using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauncherGames.DAL.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int UserId { get; set; }
        public int? GameId { get; set; }
        public string? PaymentMethod { get; set; }
        public decimal Amount { get; set; }
        public decimal? AmountInVND { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime TransactionDate { get; set; }

        // Navigation properties
        public virtual User User { get; set; } = null!;
        public virtual Game? Game { get; set; }
    }
}
