using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LauncherGames.DAL.Models;

namespace LauncherGames.BLL.Services.Interface
{
    public interface IGameService
    {
        Task<List<Game>> GetAllGamesAsync();
        Task<List<Game>> SearchGamesByNameAsync(string gameName);
        Task<Game> GetGameByIdAsync(int gameId);
        Task AddGameAsync(Game game);
        Task UpdateGameAsync(Game game);
        Task UpdateGamePartialAsync(Game game, params Expression<Func<Game, object>>[] updatedProperties);
        Task DeleteGameAsync(int gameId);
    }
}