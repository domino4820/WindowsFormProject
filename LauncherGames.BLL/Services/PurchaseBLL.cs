using System.Threading.Tasks;
using LauncherGames.BLL.Services.Interface;
using LauncherGames.DAL.Models;
using LauncherGames.DAL.Repository;

namespace LauncherGames.BLL.Services
{
    public class PurchaseBLL : IPurchaseService
    {
        private readonly IGenericRepository<User> _userRepository;
        private readonly IGenericRepository<UserGameDetail> _userGameDetailsRepository;
        private readonly IGenericRepository<Game> _gameRepository;

        public PurchaseBLL(IGenericRepository<User> userRepository, IGenericRepository<UserGameDetail> userGameDetailsRepository, IGenericRepository<Game> gameRepository)
        {
            _userRepository = userRepository;
            _userGameDetailsRepository = userGameDetailsRepository;
            _gameRepository = gameRepository;
        }

        public async Task<bool> BuyGameAsync(int userId, int gameId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                throw new Exception("User not found.");
            }

            var userGameDetails = await _userGameDetailsRepository.FindAsync(ugd => ugd.UserId == userId && ugd.GameId == gameId);
            if (userGameDetails.FirstOrDefault() != null)
            {
                return false; 
            }

            var game = await _gameRepository.GetByIdAsync(gameId);
            if (game == null)
            {
                throw new Exception("Game not found.");
            }

           
            decimal gamePrice = game.Price; 

            if (user.Balance < gamePrice)
            {
                return false; 
            }

            user.Balance -= gamePrice;
            await _userRepository.UpdateAsync(user);
            await _userRepository.SaveChangesAsync();

            var newUserGameDetail = new UserGameDetail
            {
                UserId = userId,
                GameId = gameId,
                IsPurchased = true,
                IsInstalled = false,
                DownloadPath = game.DownloadPath 
            };

            await _userGameDetailsRepository.AddAsync(newUserGameDetail);
            await _userGameDetailsRepository.SaveChangesAsync();

            return true; 
        }
    }
}