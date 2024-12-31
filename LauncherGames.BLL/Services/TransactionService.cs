using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LauncherGames.BLL.Services.Interface;
using LauncherGames.DAL.Models;
using LauncherGames.DAL.Repository;

namespace LauncherGames.BLL.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IGenericRepository<Transaction> _transactionRepository;

        public TransactionService(IGenericRepository<Transaction> transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<List<Transaction>> GetTransactionsByUserIdAsync(int userId)
        {
            var transactions = await _transactionRepository.FindAsync(t => t.UserId == userId);
            return transactions.ToList();
        }
    }
}