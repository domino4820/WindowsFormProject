using System.Collections.Generic;
using System.Threading.Tasks;
using LauncherGames.DAL.Models;

namespace LauncherGames.BLL.Services.Interface
{
    public interface IUserService
    {
        Task UnbanUserAsync(int userId);
        Task<List<User>> SearchUsersByUsernameAsync(string username);
        Task<(bool success, User? user)> AuthenticateAsync(string username, string password);
        Task<bool> IsAdminAsync(int userId);
        Task<bool> IsBannedAsync(int userId);
        Task<bool> ValidateUser(string username, string password);
        Task RegisterAsync(User user);
        Task UpdateUserAsync(User user);
        Task<User?> GetUserByIdAsync(int userId);
        Task<List<User>> GetAllUsersAsync();
        Task<User?> GetUserByUsernameAsync(string username);
        Task ChangePasswordAsync(string username, string newPassword);
        Task BanUserAsync(int userId);
        Task AddBalanceAsync(int userId, decimal amount);
        Task<bool> IsUserAdminAsync(int userId);
    }
}