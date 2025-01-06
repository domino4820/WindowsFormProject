namespace LauncherGames
{
    partial class PaypalForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaypalForm));
            groupBox2 = new GroupBox();
            button1 = new Button();
            btnThanhtoan = new Button();
            cmbMenhgia = new ComboBox();
            lblnhap = new Label();
            btnPaypal = new Button();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button1);
            groupBox2.Controls.Add(btnThanhtoan);
            groupBox2.Controls.Add(cmbMenhgia);
            groupBox2.Controls.Add(lblnhap);
            groupBox2.Controls.Add(btnPaypal);
            groupBox2.Font = new Font("Arial Narrow", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.ForeColor = Color.White;
            groupBox2.Location = new Point(74, 102);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(985, 559);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thanh toán";
            // 
            // button1
            // 
            button1.BackColor = Color.DarkTurquoise;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Cambria", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.BlueViolet;
            button1.Location = new Point(277, 434);
            button1.Name = "button1";
            button1.Size = new Size(400, 60);
            button1.TabIndex = 4;
            button1.Text = "Cập nhật sau thanh toán";
            button1.UseVisualStyleBackColor = false;
            button1.Click += btnCheckPayment_Click;
            // 
            // btnThanhtoan
            // 
            btnThanhtoan.BackColor = Color.DarkTurquoise;
            btnThanhtoan.FlatStyle = FlatStyle.Flat;
            btnThanhtoan.Font = new Font("Cambria", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThanhtoan.ForeColor = Color.BlueViolet;
            btnThanhtoan.Location = new Point(414, 321);
            btnThanhtoan.Name = "btnThanhtoan";
            btnThanhtoan.Size = new Size(288, 60);
            btnThanhtoan.TabIndex = 3;
            btnThanhtoan.Text = "Tiến hành thanh toán";
            btnThanhtoan.UseVisualStyleBackColor = false;
            btnThanhtoan.Click += btnThanhtoan_Click;
            // 
            // cmbMenhgia
            // 
            cmbMenhgia.FormattingEnabled = true;
            cmbMenhgia.Items.AddRange(new object[] { "10", "20", "50", "100" });
            cmbMenhgia.Location = new Point(380, 226);
            cmbMenhgia.Name = "cmbMenhgia";
            cmbMenhgia.Size = new Size(360, 35);
            cmbMenhgia.TabIndex = 2;
            // 
            // lblnhap
            // 
            lblnhap.AutoSize = true;
            lblnhap.Font = new Font("Cambria", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblnhap.Location = new Point(36, 224);
            lblnhap.Name = "lblnhap";
            lblnhap.Size = new Size(309, 33);
            lblnhap.TabIndex = 1;
            lblnhap.Text = "Chọn số tiền muốn nạp";
            // 
            // btnPaypal
            // 
            btnPaypal.Image = (Image)resources.GetObject("btnPaypal.Image");
            btnPaypal.Location = new Point(277, 44);
            btnPaypal.Name = "btnPaypal";
            btnPaypal.Size = new Size(443, 99);
            btnPaypal.TabIndex = 0;
            btnPaypal.UseVisualStyleBackColor = true;
            // 
            // PaypalForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1135, 725);
            Controls.Add(groupBox2);
            Name = "PaypalForm";
            Text = "PaypalForm";
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox2;
        private Button btnThanhtoan;
        private ComboBox cmbMenhgia;
        private Label lblnhap;
        private Button btnPaypal;
        private Button button1;
    }
}