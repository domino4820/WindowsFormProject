namespace LauncherGames.Presentation
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransactionForm));
            dataGridViewTransactions = new DataGridView();
            groupBox1 = new GroupBox();
            lblSoDu = new Label();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            groupBox2 = new GroupBox();
            button1 = new Button();
            groupBox3 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTransactions).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewTransactions
            // 
            dataGridViewTransactions.AllowUserToAddRows = false;
            dataGridViewTransactions.AllowUserToDeleteRows = false;
            dataGridViewTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewTransactions.BackgroundColor = Color.Black;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.Black;
            dataGridViewCellStyle1.Font = new Font("Arial", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewTransactions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTransactions.Dock = DockStyle.Fill;
            dataGridViewTransactions.GridColor = Color.Black;
            dataGridViewTransactions.Location = new Point(3, 30);
            dataGridViewTransactions.Name = "dataGridViewTransactions";
            dataGridViewTransactions.ReadOnly = true;
            dataGridViewTransactions.RowHeadersWidth = 51;
            dataGridViewTransactions.Size = new Size(1129, 293);
            dataGridViewTransactions.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblSoDu);
            groupBox1.Controls.Add(pictureBox1);
            groupBox1.Controls.Add(label2);
            groupBox1.Font = new Font("Arial", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(125, 107);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(255, 209);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tổng quan";
            // 
            // lblSoDu
            // 
            lblSoDu.AutoSize = true;
            lblSoDu.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSoDu.ForeColor = Color.Lime;
            lblSoDu.Location = new Point(121, 112);
            lblSoDu.Name = "lblSoDu";
            lblSoDu.Size = new Size(40, 31);
            lblSoDu.TabIndex = 10;
            lblSoDu.Text = "0đ";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Black;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(67, 120);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(32, 23);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 66);
            label2.Name = "label2";
            label2.Size = new Size(78, 27);
            label2.TabIndex = 1;
            label2.Text = "Số dư";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button1);
            groupBox2.Font = new Font("Arial Narrow", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.ForeColor = Color.White;
            groupBox2.Location = new Point(469, 107);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(552, 309);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thanh toán";
            // 
            // button1
            // 
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(57, 81);
            button1.Name = "button1";
            button1.Size = new Size(443, 99);
            button1.TabIndex = 0;
            button1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.AutoSize = true;
            groupBox3.Controls.Add(dataGridViewTransactions);
            groupBox3.Font = new Font("Arial", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox3.ForeColor = Color.White;
            groupBox3.Location = new Point(0, 422);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1135, 326);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Lịch sử giao dịch";
            // 
            // TransactionForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1135, 725);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "TransactionForm";
            Text = "TransactionForm";
            Load += TransactionForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewTransactions).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewTransactions;
        private GroupBox groupBox1;
        private Label label2;
        private PictureBox pictureBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Button button1;
        private Label lblSoDu;
    }
}