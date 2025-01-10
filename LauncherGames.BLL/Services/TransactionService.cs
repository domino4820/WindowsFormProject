using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LauncherGames.BLL.Services.Interface;
using LauncherGames.DAL.Models;
using LauncherGames.DAL.Repository;
using Microsoft.EntityFrameworkCore;

namespace LauncherGames.BLL.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IGenericRepository<Transaction> _transactionRepository;
        private readonly IGenericRepository<User> _userRepository;
        private readonly IGenericRepository<Game> _gameRepository;

        public TransactionService(IGenericRepository<Transaction> transactionRepository, IGenericRepository<User> userRepository, IGenericRepository<Game> gameRepository)
        {
            _transactionRepository = transactionRepository;
            _userRepository = userRepository;
            _gameRepository = gameRepository;
        }


            public async Task<List<TransactionViewModel>> GetTransactionsByUserIdAsync(int userId)
            {
                var transactions = await _transactionRepository.FindAsync(t => t.UserId == userId);
                var users = await _userRepository.GetAllAsync();
                var games = await _gameRepository.GetAllAsync();

                var result = from t in transactions
                             join u in users on t.UserId equals u.UserId
                             join g in games on t.GameId equals g.GameId into gj
                             from subG in gj.DefaultIfEmpty()
                             select new TransactionViewModel
                             {
                                 Username = u.Username,
                                 GameName = subG != null ? subG.GameName : "No Game",
                                 Amount = t.Amount,
                                 AmountInVND = t.Amount * 23000,
                                 Status = UpdateTransactionStatus(t.Status), 
                                 TransactionDate = t.TransactionDate
                             };

                return result.ToList();
            }

        private string UpdateTransactionStatus(string status)
        {
            switch (status)
            {
                case "PENDING":
                    return "Đang chờ xử lý";
                case "COMPLETED":
                    return "Hoàn thành";
                case "FAILED":
                    return "Thất bại";
                default:
                    return "Không xác định";
            }
        }

        public async Task AddTransactionAsync(Transaction transaction)
        {
            await _transactionRepository.AddAsync(transaction);
            await _transactionRepository.SaveChangesAsync();
        }
    }
}