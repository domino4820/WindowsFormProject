using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LauncherGames.DAL.Models;
using LauncherGames.DAL.Repository;
using LauncherGames.BLL.Services.Interface;

namespace LauncherGames.BLL.Services
{
    public class GameService : IGameService
    {
        private readonly IGenericRepository<Game> _gameRepository;

        public GameService(IGenericRepository<Game> gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<List<Game>> GetAllGamesAsync()
        {
            return (await _gameRepository.GetAllAsync()).ToList();
        }

        public async Task<Game> GetGameByIdAsync(int gameId)
        {
            return await _gameRepository.GetByIdAsync(gameId);
        }

        public async Task AddGameAsync(Game game)
        {
            await _gameRepository.AddAsync(game);
            await _gameRepository.SaveChangesAsync();
        }

        public async Task UpdateGameAsync(Game game)
        {
            await _gameRepository.UpdateAsync(game);
            await _gameRepository.SaveChangesAsync();
        }

        public async Task DeleteGameAsync(int gameId)
        {
            var game = await _gameRepository.GetByIdAsync(gameId);
            if (game != null)
            {
                await _gameRepository.DeleteAsync(game);
                await _gameRepository.SaveChangesAsync();
            }
        }
    }
}