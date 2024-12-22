using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LauncherGames.DAL;

namespace LauncherGames.BLL
{
    public class UserBLL
    {
        private UserDAL userDAL;

        public UserBLL()
        {
            userDAL = new UserDAL();
        }

        public bool RegisterUser(User user)
        {
            // Logic to register user
            userDAL.AddUser(user);
            return true;
        }

        public bool LoginUser(string username, string password)
        {
            // Logic to login user
            var user = userDAL.GetAllUsers().FirstOrDefault(u => u.Username == username && u.Password == password);
            return user != null;
        }

        public User GetUserById(int id)
        {
            return userDAL.GetUserById(id);
        }

        public void UpdateUser(User user)
        {
            userDAL.UpdateUser(user);
        }

        public List<User> GetAllUsers()
        {
            return userDAL.GetAllUsers();
        }

        public User GetUserByUsername(string username)
        {
            return userDAL.GetUserByUsername(username);
        }

        public void ChangePassword(string username, string newPassword)
        {
            userDAL.ChangePassword(username, newPassword);
        }


    }
}