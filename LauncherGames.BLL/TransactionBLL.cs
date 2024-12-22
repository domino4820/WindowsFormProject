using System.Collections.Generic;
using LauncherGames.DAL;

namespace LauncherGames.BLL
{
    public class TransactionBLL
    {
        private TransactionDAL transactionDAL;

        public TransactionBLL()
        {
            transactionDAL = new TransactionDAL();
        }

        public List<Transaction> GetTransactionsByUserId(int userId)
        {
            return transactionDAL.GetTransactionsByUserId(userId);
        }
    }
}