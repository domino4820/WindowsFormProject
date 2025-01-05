using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LauncherGames.DAL.Models;
using LauncherGames.DAL.Repository;
using LauncherGames.BLL.Services.Interface;
using Microsoft.EntityFrameworkCore;
using LauncherGames.DAL.Context;

namespace LauncherGames.BLL.Services
{
    public class GameService : IGameService
    {
        private readonly IGenericRepository<Game> _gameRepository;
        private readonly LauncherGamesContext _context;
        private readonly DbSet<UserGameDetail> _userGameDetails;

        public GameService(IGenericRepository<Game> gameRepository, LauncherGamesContext context)
        {
            _gameRepository = gameRepository;
            _context = context;
            _userGameDetails = _context.Set<UserGameDetail>();
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

        public async Task UpdateGamePartialAsync(Game game, params Expression<Func<Game, object>>[] updatedProperties)
        {
            await _gameRepository.UpdatePartialAsync(game, updatedProperties);
            await _gameRepository.SaveChangesAsync();
        }

        public async Task DeleteGameAsync(int gameId)
        {
            var userGameDetails = await _userGameDetails.Where(ugd => ugd.GameId == gameId).ToListAsync();
            _userGameDetails.RemoveRange(userGameDetails);

            // Delete game
            var game = await _gameRepository.GetByIdAsync(gameId);
            if (game != null)
            {
                await _gameRepository.DeleteAsync(game);
                await _gameRepository.SaveChangesAsync();
            }
        }


    }
}