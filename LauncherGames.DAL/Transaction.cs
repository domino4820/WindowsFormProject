using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauncherGames.DAL
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int UserId { get; set; }
        public int? GameId { get; set; }
        public string PaymentMethod { get; set; }
        public decimal Amount { get; set; }
        public decimal? AmountInVND { get; set; }
        public string Status { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}