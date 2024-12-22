using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LauncherGames.BLL;
using Microsoft.Data.SqlClient;

namespace LauncherGames.Presentation
{
    public partial class TransactionForm : Form
    {
        private UserBLL userBLL;
        private TransactionBLL transactionBLL;
        private int userId;

        public TransactionForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            userBLL = new UserBLL();
            transactionBLL = new TransactionBLL();
        }

        private void LoadTransactionList()
        {
            var transactions = transactionBLL.GetTransactionsByUserId(userId);
            dataGridViewTransactions.DataSource = transactions;
        }

        private void UpdateUserBalance()
        {
            var user = userBLL.GetUserById(userId);
            if (user != null)
            {
                lblSoDu.Text = $"{user.Balance:C}";
            }
        }



        private void TransactionForm_Load(object sender, EventArgs e)
        {
            LoadTransactionList();
            UpdateUserBalance();
        }
    }
}