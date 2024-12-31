using System.Threading.Tasks;

namespace LauncherGames.BLL.Services.Interface
{
    public interface IPurchaseService
    {
        Task<bool> BuyGameAsync(int userId, int gameId);
    }
}