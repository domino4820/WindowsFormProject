using LauncherGames.DAL;

namespace LauncherGames.BLL
{
    public class PurchaseBLL
    {
        private UserDAL userDAL;
        private GameDAL gameDAL;
        private TransactionDAL transactionDAL;
        private UserGameDetailsDAL userGameDetailsDAL;

        public PurchaseBLL()
        {
            userDAL = new UserDAL();
            gameDAL = new GameDAL();
            transactionDAL = new TransactionDAL();
            userGameDetailsDAL = new UserGameDetailsDAL();
        }

        public bool BuyGame(int userId, int gameId)
        {
            // Lấy thông tin người dùng và game
            User user = userDAL.GetUserById(userId);
            Game game = gameDAL.GetGameById(gameId);

            if (user == null || game == null)
            {
                throw new Exception("Người dùng hoặc game không tồn tại.");
            }

            // Kiểm tra số dư
            if (user.Balance < game.Price)
            {
                return false; // Không đủ tiền mua game
            }

            // Trừ tiền và cập nhật số dư
            user.Balance -= game.Price;
            userDAL.UpdateUserBalance(user.UserId, user.Balance);

            // Lưu thông tin giao dịch
            Transaction transaction = new Transaction
            {
                UserId = user.UserId,
                GameId = game.GameId,
                PaymentMethod = "Credit Card", // Ví dụ: phương thức thanh toán
                Amount = game.Price,
                AmountInVND = game.Price * 23000, // Ví dụ: tỷ giá hối đoái
                Status = "Completed",
                TransactionDate = DateTime.Now
            };
            transactionDAL.AddTransaction(transaction);

            // Cập nhật thông tin vào UserGameDetails
            UserGameDetails userGameDetails = new UserGameDetails
            {
                UserId = user.UserId,
                GameId = game.GameId,
                IsPurchased = true,
                IsInstalled = false,
                PurchaseDate = DateTime.Now
            };
            userGameDetailsDAL.AddOrUpdateUserGameDetails(userGameDetails);

            return true;
        }

        public List<Transaction> GetTransactionHistory(int userId)
        {
            return transactionDAL.GetTransactionsByUserId(userId);
        }

        public bool IsGamePurchased(int userId, int gameId)
        {
            UserGameDetails userGameDetails = userGameDetailsDAL.GetUserGameDetails(userId, gameId);
            return userGameDetails != null && userGameDetails.IsPurchased;
        }
    }
}