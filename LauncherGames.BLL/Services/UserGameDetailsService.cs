using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LauncherGames.DAL.Models;
using LauncherGames.DAL.Repository;
using LauncherGames.BLL.Services.Interface;
using Microsoft.EntityFrameworkCore;
using LauncherGames.DAL.Context;

namespace LauncherGames.BLL.Services
{
    public class UserGameDetailsService : IUserGameDetailsService
    {
        private readonly IGenericRepository<UserGameDetail> _userGameDetailsRepository;
        private readonly LauncherGamesContext _context;

        public UserGameDetailsService(IGenericRepository<UserGameDetail> userGameDetailsRepository, LauncherGamesContext context)
        {
            _userGameDetailsRepository = userGameDetailsRepository;
            _context = context;
        }

        public async Task<List<UserGameDetail>> GetPurchasedGamesAsync(int userId)
        {
            return await _context.UserGameDetails
                .Include(ugd => ugd.Game)
                .Where(ugd => ugd.UserId == userId && ugd.IsPurchased)
                .ToListAsync();
        }

        public async Task<UserGameDetail?> GetUserGameDetailsAsync(int userId, int gameId)
        {
            var userGameDetails = await _userGameDetailsRepository.FindAsync(ugd => ugd.UserId == userId && ugd.GameId == gameId);
            return userGameDetails.FirstOrDefault();
        }

        public async Task AddUserGameDetailsAsync(UserGameDetail userGameDetails)
        {
            await _userGameDetailsRepository.AddAsync(userGameDetails);
            await _userGameDetailsRepository.SaveChangesAsync();
        }

        public async Task UpdateUserGameDetailsAsync(UserGameDetail userGameDetails)
        {
            await _userGameDetailsRepository.UpdateAsync(userGameDetails);
            await _userGameDetailsRepository.SaveChangesAsync();
        }

        public async Task<bool> IsGamePurchasedByUserAsync(int userId, int gameId)
        {
            var userGameDetails = await GetUserGameDetailsAsync(userId, gameId);
            return userGameDetails?.IsPurchased ?? false;
        }

        public async Task<bool> IsGameInstalledByUserAsync(int userId, int gameId)
        {
            var userGameDetails = await GetUserGameDetailsAsync(userId, gameId);
            return userGameDetails?.IsInstalled ?? false;
        }
    }
}