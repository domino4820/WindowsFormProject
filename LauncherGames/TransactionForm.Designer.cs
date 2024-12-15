namespace LauncherGames
{
    partial class TransactionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridViewTransactions = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTransactions).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewTransactions
            // 
            dataGridViewTransactions.AllowUserToAddRows = false;
            dataGridViewTransactions.AllowUserToDeleteRows = false;
            dataGridViewTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewTransactions.BackgroundColor = Color.White;
            dataGridViewTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTransactions.Location = new Point(-1, 486);
            dataGridViewTransactions.Name = "dataGridViewTransactions";
            dataGridViewTransactions.ReadOnly = true;
            dataGridViewTransactions.RowHeadersWidth = 51;
            dataGridViewTransactions.Size = new Size(966, 259);
            dataGridViewTransactions.TabIndex = 0;
            // 
            // TransactionForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(964, 744);
            Controls.Add(dataGridViewTransactions);
            Name = "TransactionForm";
            Text = "TransactionForm";
            ((System.ComponentModel.ISupportInitialize)dataGridViewTransactions).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewTransactions;
    }
}