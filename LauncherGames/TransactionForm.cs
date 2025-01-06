using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LauncherGames.BLL.Services.Interface;
using LauncherGames.DAL.Models;
using Microsoft.Extensions.DependencyInjection;

namespace LauncherGames
{
    public partial class TransactionForm : Form
    {
        private readonly IUserService _userService;
        private readonly ITransactionService _transactionService;
        private readonly int _userId;

        public TransactionForm(int userId)
        {
            InitializeComponent();
            _userId = userId;

            _userService = Program.ServiceProvider.GetRequiredService<IUserService>();
            _transactionService = Program.ServiceProvider.GetRequiredService<ITransactionService>();
        }

        private async void LoadTransactionList()
        {
            var transactions = await _transactionService.GetTransactionsByUserIdAsync(_userId);
            dataGridViewTransactions.DataSource = transactions;

            if (dataGridViewTransactions.Columns["TransactionId"] != null)
            {
                dataGridViewTransactions.Columns["TransactionId"].Visible = false;
            }
        }

        private async void UpdateUserBalance()
        {
            var user = await _userService.GetUserByIdAsync(_userId);
            if (user != null)
            {
                lblSoDu.Text = $"{user.Balance:C}";
            }
        }

        private void TransactionForm_Load_1(object sender, EventArgs e)
        {
            LoadTransactionList();
            UpdateUserBalance();
            SetGridViewStyle(dataGridViewTransactions);
        }

        public static void SetGridViewStyle(DataGridView dgview)
        {
            dgview.BorderStyle = BorderStyle.None;
            dgview.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dgview.DefaultCellStyle.SelectionForeColor = Color.BlueViolet;
            dgview.DefaultCellStyle.Font = new Font(dgview.DefaultCellStyle.Font.FontFamily, 10);
            dgview.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgview.BackgroundColor = Color.White;
            dgview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnPaypal_Click(object sender, EventArgs e)
        {
            PaypalForm paypalform = new PaypalForm(_userService, _userId,this);
            this.Hide();
            paypalform.ShowDialog();

        }
    }
}