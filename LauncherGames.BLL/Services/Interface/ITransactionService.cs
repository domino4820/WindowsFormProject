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
        Task<List<Transaction>> GetTransactionsByUserIdAsync(int userId);
       
    }
}
