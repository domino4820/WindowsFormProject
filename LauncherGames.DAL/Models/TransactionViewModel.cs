namespace LauncherGames.DAL.Models
{
    public class TransactionViewModel
    {
        public int TransactionId { get; set; }
        public string Username { get; set; }
        public string GameName { get; set; }
        public decimal Amount { get; set; }
        public decimal? AmountInVND { get; set; }
        public string Status { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}