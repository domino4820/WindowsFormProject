using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LauncherGames.DAL.Models;

namespace LauncherGames.BLL.Services.Interface
{
    public interface IUserGameDetailsService
    {
        Task<List<UserGameDetail>> GetPurchasedGamesAsync(int userId);
        Task<UserGameDetail> GetUserGameDetailsAsync(int userId, int gameId);
        Task AddUserGameDetailsAsync(UserGameDetail userGameDetails);
        Task UpdateUserGameDetailsAsync(UserGameDetail userGameDetails);
        Task<bool> IsGamePurchasedByUserAsync(int userId, int gameId);
        Task<bool> IsGameInstalledByUserAsync(int userId, int gameId);
    }
}
