namespace LauncherGames.Presentation
{
    partial class GameForm
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
            components = new System.ComponentModel.Container();
            picBoxGame = new PictureBox();
            lblGameName = new Label();
            txtGameDescription = new TextBox();
            label1 = new Label();
            btnPurchase = new Button();
            btnInstall = new Button();
            btnPlay = new Button();
            btnDeleteGame = new Button();
            lstFeedback = new ListBox();
            lblPrice = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            ((System.ComponentModel.ISupportInitialize)picBoxGame).BeginInit();
            SuspendLayout();
            // 
            // picBoxGame
            // 
            picBoxGame.Location = new Point(70, 192);
            picBoxGame.Name = "picBoxGame";
            picBoxGame.Size = new Size(409, 226);
            picBoxGame.SizeMode = PictureBoxSizeMode.StretchImage;
            picBoxGame.TabIndex = 0;
            picBoxGame.TabStop = false;
            // 
            // lblGameName
            // 
            lblGameName.AutoSize = true;
            lblGameName.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblGameName.ForeColor = Color.White;
            lblGameName.Location = new Point(530, 192);
            lblGameName.Name = "lblGameName";
            lblGameName.Size = new Size(135, 31);
            lblGameName.TabIndex = 1;
            lblGameName.Text = "NameGame";
            // 
            // txtGameDescription
            // 
            txtGameDescription.BackColor = Color.Black;
            txtGameDescription.ForeColor = Color.White;
            txtGameDescription.Location = new Point(55, 585);
            txtGameDescription.Multiline = true;
            txtGameDescription.Name = "txtGameDescription";
            txtGameDescription.ReadOnly = true;
            txtGameDescription.Size = new Size(1008, 27);
            txtGameDescription.TabIndex = 2;
            txtGameDescription.Text = " ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(502, 519);
            label1.Name = "label1";
            label1.Size = new Size(180, 31);
            label1.TabIndex = 3;
            label1.Text = "Mô tả sản phẩm";
            // 
            // btnPurchase
            // 
            btnPurchase.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPurchase.Location = new Point(530, 296);
            btnPurchase.Name = "btnPurchase";
            btnPurchase.Size = new Size(119, 41);
            btnPurchase.TabIndex = 4;
            btnPurchase.Text = "Mua game";
            btnPurchase.UseVisualStyleBackColor = true;
            btnPurchase.Click += btnPurchase_Click;
            // 
            // btnInstall
            // 
            btnInstall.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnInstall.Location = new Point(530, 296);
            btnInstall.Name = "btnInstall";
            btnInstall.Size = new Size(119, 41);
            btnInstall.TabIndex = 5;
            btnInstall.Text = "Cài đặt";
            btnInstall.UseVisualStyleBackColor = true;
            btnInstall.Click += btnInstall_Click;
            // 
            // btnPlay
            // 
            btnPlay.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPlay.Location = new Point(530, 296);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(119, 41);
            btnPlay.TabIndex = 6;
            btnPlay.Text = "Chơi game";
            btnPlay.UseVisualStyleBackColor = true;
            btnPlay.Click += btnPlay_Click;
            // 
            // btnDeleteGame
            // 
            btnDeleteGame.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDeleteGame.Location = new Point(530, 366);
            btnDeleteGame.Name = "btnDeleteGame";
            btnDeleteGame.Size = new Size(119, 41);
            btnDeleteGame.TabIndex = 7;
            btnDeleteGame.Text = "Xóa game";
            btnDeleteGame.UseVisualStyleBackColor = true;
            // 
            // lstFeedback
            // 
            lstFeedback.BackColor = Color.Black;
            lstFeedback.ForeColor = Color.White;
            lstFeedback.FormattingEnabled = true;
            lstFeedback.Location = new Point(55, 972);
            lstFeedback.Name = "lstFeedback";
            lstFeedback.Size = new Size(1008, 104);
            lstFeedback.TabIndex = 8;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPrice.ForeColor = Color.Lime;
            lblPrice.Location = new Point(530, 247);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(40, 31);
            lblPrice.TabIndex = 9;
            lblPrice.Text = "0đ";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.Black;
            ClientSize = new Size(1135, 725);
            Controls.Add(lblPrice);
            Controls.Add(lstFeedback);
            Controls.Add(btnDeleteGame);
            Controls.Add(btnPurchase);
            Controls.Add(label1);
            Controls.Add(txtGameDescription);
            Controls.Add(lblGameName);
            Controls.Add(picBoxGame);
            Controls.Add(btnInstall);
            Controls.Add(btnPlay);
            Name = "GameForm";
            Text = "GameForm";
            Load += GameForm_Load;
            ((System.ComponentModel.ISupportInitialize)picBoxGame).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picBoxGame;
        private Label lblGameName;
        private TextBox txtGameDescription;
        private Label label1;
        private Button btnPurchase;
        private Button btnInstall;
        private Button btnPlay;
        private Button btnDeleteGame;
        private ListBox lstFeedback;
        private Label lblPrice;
        private ContextMenuStrip contextMenuStrip1;
    }
}