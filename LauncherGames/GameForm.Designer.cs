namespace LauncherGames
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            picBoxGame = new PictureBox();
            lblGameName = new Label();
            txtGameDescription = new TextBox();
            label1 = new Label();
            btnInstall = new Button();
            btnPlay = new Button();
            btnDeleteGame = new Button();
            lblPrice = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            btnPurchase = new Button();
            toolStrip1 = new ToolStrip();
            toolStripButton1 = new ToolStripDropDownButton();
            tsProfile_HoSo = new ToolStripMenuItem();
            tsProfile_SoDu = new ToolStripMenuItem();
            tsProfile_ThuVien = new ToolStripMenuItem();
            tsProfile_Logout = new ToolStripMenuItem();
            aministratorToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            btnSearch = new ToolStripButton();
            txtSearch = new ToolStripTextBox();
            toolStripButton2 = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            btnHome = new ToolStripButton();
            toolStripButton4 = new ToolStripButton();
            toolStripButton5 = new ToolStripSplitButton();
            giảiTríToolStripMenuItem = new ToolStripMenuItem();
            hànhĐộngToolStripMenuItem = new ToolStripMenuItem();
            phiêuLưuToolStripMenuItem = new ToolStripMenuItem();
            kinhDịToolStripMenuItem = new ToolStripMenuItem();
            tâmLýToolStripMenuItem = new ToolStripMenuItem();
            lstSearchResults = new ListBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picBoxGame).BeginInit();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
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
            lblGameName.BackColor = Color.FromArgb(192, 255, 255);
            lblGameName.Font = new Font("Cambria", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGameName.ForeColor = Color.Black;
            lblGameName.Location = new Point(530, 192);
            lblGameName.Name = "lblGameName";
            lblGameName.Size = new Size(131, 27);
            lblGameName.TabIndex = 1;
            lblGameName.Text = "NameGame";
            // 
            // txtGameDescription
            // 
            txtGameDescription.BackColor = Color.Black;
            txtGameDescription.Enabled = false;
            txtGameDescription.ForeColor = Color.White;
            txtGameDescription.Location = new Point(56, 475);
            txtGameDescription.Multiline = true;
            txtGameDescription.Name = "txtGameDescription";
            txtGameDescription.ReadOnly = true;
            txtGameDescription.Size = new Size(1008, 519);
            txtGameDescription.TabIndex = 2;
            txtGameDescription.Text = " ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(192, 255, 255);
            label1.Font = new Font("Cambria", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(504, 445);
            label1.Name = "label1";
            label1.Size = new Size(176, 27);
            label1.TabIndex = 3;
            label1.Text = "Mô tả sản phẩm";
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
            btnDeleteGame.Click += btnDelete_Click;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.BackColor = Color.FromArgb(192, 255, 255);
            lblPrice.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPrice.ForeColor = Color.BlueViolet;
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
            // toolStrip1
            // 
            toolStrip1.BackColor = Color.Black;
            toolStrip1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            toolStrip1.ImageScalingSize = new Size(64, 64);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton1, toolStripSeparator2, btnSearch, txtSearch, toolStripButton2, toolStripSeparator1, btnHome, toolStripButton4, toolStripButton5 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1145, 71);
            toolStrip1.TabIndex = 10;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            toolStripButton1.Alignment = ToolStripItemAlignment.Right;
            toolStripButton1.BackColor = Color.Black;
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton1.DropDownItems.AddRange(new ToolStripItem[] { tsProfile_HoSo, tsProfile_SoDu, tsProfile_ThuVien, tsProfile_Logout, aministratorToolStripMenuItem });
            toolStripButton1.ForeColor = Color.Black;
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(78, 68);
            toolStripButton1.Text = "toolStripButton1";
            // 
            // tsProfile_HoSo
            // 
            tsProfile_HoSo.BackColor = Color.Black;
            tsProfile_HoSo.ForeColor = Color.White;
            tsProfile_HoSo.Name = "tsProfile_HoSo";
            tsProfile_HoSo.Size = new Size(229, 36);
            tsProfile_HoSo.Text = "Hồ sơ";
            tsProfile_HoSo.Click += tsProfile_HoSo_Click;
            // 
            // tsProfile_SoDu
            // 
            tsProfile_SoDu.BackColor = Color.Black;
            tsProfile_SoDu.ForeColor = Color.White;
            tsProfile_SoDu.Name = "tsProfile_SoDu";
            tsProfile_SoDu.Size = new Size(229, 36);
            tsProfile_SoDu.Text = "Số dư";
            tsProfile_SoDu.Click += tsProfile_SoDu_Click;
            // 
            // tsProfile_ThuVien
            // 
            tsProfile_ThuVien.BackColor = Color.Black;
            tsProfile_ThuVien.ForeColor = Color.White;
            tsProfile_ThuVien.Name = "tsProfile_ThuVien";
            tsProfile_ThuVien.Size = new Size(229, 36);
            tsProfile_ThuVien.Text = "Thư viện";
            tsProfile_ThuVien.Click += tsProfile_ThuVien_Click;
            // 
            // tsProfile_Logout
            // 
            tsProfile_Logout.BackColor = Color.Black;
            tsProfile_Logout.ForeColor = Color.White;
            tsProfile_Logout.Name = "tsProfile_Logout";
            tsProfile_Logout.Size = new Size(229, 36);
            tsProfile_Logout.Text = "Đăng xuất";
            tsProfile_Logout.Click += tsProfile_Logout_Click;
            // 
            // aministratorToolStripMenuItem
            // 
            aministratorToolStripMenuItem.BackColor = SystemColors.ActiveCaptionText;
            aministratorToolStripMenuItem.ForeColor = Color.White;
            aministratorToolStripMenuItem.Name = "aministratorToolStripMenuItem";
            aministratorToolStripMenuItem.Size = new Size(229, 36);
            aministratorToolStripMenuItem.Text = "Aministrator";
            aministratorToolStripMenuItem.Visible = false;
            aministratorToolStripMenuItem.Click += aministratorToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Alignment = ToolStripItemAlignment.Right;
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 71);
            // 
            // btnSearch
            // 
            btnSearch.Alignment = ToolStripItemAlignment.Right;
            btnSearch.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnSearch.ForeColor = Color.White;
            btnSearch.Image = (Image)resources.GetObject("btnSearch.Image");
            btnSearch.ImageTransparentColor = Color.Magenta;
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(111, 68);
            btnSearch.Text = "Tìm kiếm";
            // 
            // txtSearch
            // 
            txtSearch.Alignment = ToolStripItemAlignment.Right;
            txtSearch.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(300, 71);
            txtSearch.ToolTipText = "Tìm kiếm";
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // toolStripButton2
            // 
            toolStripButton2.AutoSize = false;
            toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton2.Image = (Image)resources.GetObject("toolStripButton2.Image");
            toolStripButton2.ImageTransparentColor = Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(150, 68);
            toolStripButton2.Text = "toolStripButton2";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 71);
            // 
            // btnHome
            // 
            btnHome.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnHome.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnHome.ForeColor = Color.White;
            btnHome.Image = (Image)resources.GetObject("btnHome.Image");
            btnHome.ImageTransparentColor = Color.Magenta;
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(118, 68);
            btnHome.Text = "Trang chủ";
            btnHome.Click += btnHome_Click;
            // 
            // toolStripButton4
            // 
            toolStripButton4.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton4.ForeColor = Color.White;
            toolStripButton4.Image = (Image)resources.GetObject("toolStripButton4.Image");
            toolStripButton4.ImageTransparentColor = Color.Magenta;
            toolStripButton4.Name = "toolStripButton4";
            toolStripButton4.Size = new Size(98, 68);
            toolStripButton4.Text = "Thể loại";
            // 
            // toolStripButton5
            // 
            toolStripButton5.BackColor = Color.Black;
            toolStripButton5.DisplayStyle = ToolStripItemDisplayStyle.None;
            toolStripButton5.DropDownItems.AddRange(new ToolStripItem[] { giảiTríToolStripMenuItem, hànhĐộngToolStripMenuItem, phiêuLưuToolStripMenuItem, kinhDịToolStripMenuItem, tâmLýToolStripMenuItem });
            toolStripButton5.Image = (Image)resources.GetObject("toolStripButton5.Image");
            toolStripButton5.ImageTransparentColor = Color.Magenta;
            toolStripButton5.Name = "toolStripButton5";
            toolStripButton5.Size = new Size(19, 68);
            toolStripButton5.Text = "toolStripButton5";
            // 
            // giảiTríToolStripMenuItem
            // 
            giảiTríToolStripMenuItem.BackColor = Color.Black;
            giảiTríToolStripMenuItem.ForeColor = Color.White;
            giảiTríToolStripMenuItem.Name = "giảiTríToolStripMenuItem";
            giảiTríToolStripMenuItem.Size = new Size(216, 36);
            giảiTríToolStripMenuItem.Text = "Giải trí";
            // 
            // hànhĐộngToolStripMenuItem
            // 
            hànhĐộngToolStripMenuItem.BackColor = Color.Black;
            hànhĐộngToolStripMenuItem.ForeColor = Color.White;
            hànhĐộngToolStripMenuItem.Name = "hànhĐộngToolStripMenuItem";
            hànhĐộngToolStripMenuItem.Size = new Size(216, 36);
            hànhĐộngToolStripMenuItem.Text = "Hành động";
            // 
            // phiêuLưuToolStripMenuItem
            // 
            phiêuLưuToolStripMenuItem.BackColor = Color.Black;
            phiêuLưuToolStripMenuItem.ForeColor = Color.White;
            phiêuLưuToolStripMenuItem.Name = "phiêuLưuToolStripMenuItem";
            phiêuLưuToolStripMenuItem.Size = new Size(216, 36);
            phiêuLưuToolStripMenuItem.Text = "Phiêu lưu";
            // 
            // kinhDịToolStripMenuItem
            // 
            kinhDịToolStripMenuItem.BackColor = Color.Black;
            kinhDịToolStripMenuItem.ForeColor = Color.White;
            kinhDịToolStripMenuItem.Name = "kinhDịToolStripMenuItem";
            kinhDịToolStripMenuItem.Size = new Size(216, 36);
            kinhDịToolStripMenuItem.Text = "Kinh dị";
            // 
            // tâmLýToolStripMenuItem
            // 
            tâmLýToolStripMenuItem.BackColor = Color.Black;
            tâmLýToolStripMenuItem.ForeColor = Color.White;
            tâmLýToolStripMenuItem.Name = "tâmLýToolStripMenuItem";
            tâmLýToolStripMenuItem.Size = new Size(216, 36);
            tâmLýToolStripMenuItem.Text = "Tâm lý";
            // 
            // lstSearchResults
            // 
            lstSearchResults.Font = new Font("Arial", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lstSearchResults.FormattingEnabled = true;
            lstSearchResults.ItemHeight = 19;
            lstSearchResults.Location = new Point(648, 54);
            lstSearchResults.Name = "lstSearchResults";
            lstSearchResults.Size = new Size(300, 118);
            lstSearchResults.TabIndex = 11;
            lstSearchResults.Visible = false;
            lstSearchResults.Click += lstSearchResults_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 76);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1145, 918);
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.Black;
            ClientSize = new Size(1135, 725);
            Controls.Add(lstSearchResults);
            Controls.Add(toolStrip1);
            Controls.Add(lblPrice);
            Controls.Add(btnDeleteGame);
            Controls.Add(btnPurchase);
            Controls.Add(label1);
            Controls.Add(txtGameDescription);
            Controls.Add(lblGameName);
            Controls.Add(picBoxGame);
            Controls.Add(btnInstall);
            Controls.Add(btnPlay);
            Controls.Add(pictureBox1);
            Name = "GameForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GameForm";
            Load += GameForm_Load_1;
            ((System.ComponentModel.ISupportInitialize)picBoxGame).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picBoxGame;
        private Label lblGameName;
        private TextBox txtGameDescription;
        private Label label1;
        private Button btnInstall;
        private Button btnPlay;
        private Button btnDeleteGame;
        private Label lblPrice;
        private ContextMenuStrip contextMenuStrip1;
        private Button btnPurchase;
        private ToolStrip toolStrip1;
        private ToolStripDropDownButton toolStripButton1;
        private ToolStripMenuItem tsProfile_HoSo;
        private ToolStripMenuItem tsProfile_SoDu;
        private ToolStripMenuItem tsProfile_ThuVien;
        private ToolStripMenuItem tsProfile_Logout;
        private ToolStripMenuItem aministratorToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton btnSearch;
        private ToolStripTextBox txtSearch;
        private ToolStripButton toolStripButton2;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btnHome;
        private ToolStripButton toolStripButton4;
        private ToolStripSplitButton toolStripButton5;
        private ToolStripMenuItem giảiTríToolStripMenuItem;
        private ToolStripMenuItem hànhĐộngToolStripMenuItem;
        private ToolStripMenuItem phiêuLưuToolStripMenuItem;
        private ToolStripMenuItem kinhDịToolStripMenuItem;
        private ToolStripMenuItem tâmLýToolStripMenuItem;
        private ListBox lstSearchResults;
        private PictureBox pictureBox1;
    }
}