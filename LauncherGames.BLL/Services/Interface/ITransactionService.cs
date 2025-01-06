using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LauncherGames.DAL.Models;

namespace LauncherGames.BLL.Services.Interface
{
    public interface ITransactionService
    {
        Task<List<TransactionViewModel>> GetTransactionsByUserIdAsync(int userId);
        Task AddTransactionAsync(Transaction transaction);
    }

}
