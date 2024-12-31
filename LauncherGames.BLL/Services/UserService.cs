using System.Linq.Expressions;
using LauncherGames.BLL.Services.Interface;
using LauncherGames.DAL.Models;
using LauncherGames.DAL.Repository;

public class UserService : IUserService
{
    private readonly IGenericRepository<User> _userRepository;

    public UserService(IGenericRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<(bool success, User? user)> AuthenticateAsync(string username, string password)
    {
        var user = (await _userRepository.FindAsync(u =>
            u.Username.ToLower() == username.ToLower() &&
            u.Password == password)).FirstOrDefault();

        return (user != null, user);
    }

    public async Task<bool> IsAdminAsync(int userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        return user?.IsAdmin ?? false;
    }

    public async Task<bool> IsBannedAsync(int userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        return user?.IsBanned ?? false;
    }

    public async Task RegisterAsync(User user)
    {
        var existingUser = (await _userRepository.FindAsync(u => u.Username.ToLower() == user.Username.ToLower())).FirstOrDefault();
        if (existingUser != null)
        {
            throw new Exception("Tên đăng nhập đã tồn tại.");
        }

        await _userRepository.AddAsync(user);
        await _userRepository.SaveChangesAsync();
    }

    public async Task UpdateUserAsync(User user)
    {
        await _userRepository.UpdateAsync(user);
        await _userRepository.SaveChangesAsync();
    }

    public async Task<User?> GetUserByIdAsync(int userId)
    {
        return await _userRepository.GetByIdAsync(userId);
    }

    public async Task<List<User>> GetAllUsersAsync()
    {
        return (await _userRepository.GetAllAsync()).ToList();
    }

    public async Task<bool> ValidateUser(string username, string password)
    {
        var user = (await _userRepository.FindAsync(u =>
            u.Username.ToLower() == username.ToLower() &&
            u.Password == password)).FirstOrDefault();

        return user != null;
    }

    public async Task<User> GetUserByUsernameAsync(string username)
    {
        return (await _userRepository.FindAsync(u => u.Username == username)).FirstOrDefault();
    }

    public async Task ChangePasswordAsync(string username, string newPassword)
    {
        var user = await GetUserByUsernameAsync(username);
        if (user != null)
        {
            user.Password = newPassword;
            await _userRepository.UpdateAsync(user);
            await _userRepository.SaveChangesAsync();
        }
    }

    public async Task BanUserAsync(int userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user != null)
        {
            user.IsBanned = true;
            await _userRepository.UpdateAsync(user);
            await _userRepository.SaveChangesAsync();
        }
    }

    public async Task AddBalanceAsync(int userId, decimal amount)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user != null)
        {
            user.Balance += amount;
            await _userRepository.UpdateAsync(user);
            await _userRepository.SaveChangesAsync();
        }
    }

    public async Task<bool> IsUserAdminAsync(int userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        return user != null && user.IsAdmin;
    }
}
