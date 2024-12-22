using LauncherGames.DAL;
using System.Collections.Generic;

namespace LauncherGames.BLL
{
    public class GameBLL
    {
        private GameDAL gameDAL;

        public GameBLL()
        {
            gameDAL = new GameDAL();
        }

        public List<Game> GetGamesByStatus(string status)
        {
            return gameDAL.GetGamesByStatus(status);
        }

        public List<Game> GetAllGames()
        {
            return gameDAL.GetAllGames();
        }

        
    }
}