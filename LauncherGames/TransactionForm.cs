using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace LauncherGames
{
    public partial class TransactionForm : Form
    {   
        private string loggedInUsername;
        public TransactionForm(string username)
        {
            InitializeComponent();
            this.loggedInUsername = username;
            LoadTransactions(loggedInUsername);
        }
        

        private void LoadTransactions(string username)
        {
            string connectionString = "Server=DESKTOP-83LI0FP;Database=LauncherGames;Trusted_Connection=True;TrustServerCertificate=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = @"
                SELECT 
                    g.GameName AS [Tên trò chơi], 
                    t.Amount AS [Số tiền], 
                    t.TransactionDate AS [Ngày giao dịch]
                FROM Transactions t
                JOIN Games g ON t.GameId = g.GameId
                WHERE t.UserId = (SELECT UserId FROM Users WHERE Username = @Username)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable transactionsTable = new DataTable();
                        adapter.Fill(transactionsTable);

                        // Hiển thị dữ liệu trong DataGridView
                        dataGridViewTransactions.DataSource = transactionsTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi");
                }
            }
        }


    }
}
