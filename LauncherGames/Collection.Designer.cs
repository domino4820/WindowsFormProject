namespace LauncherGames
{
    partial class Collection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Collection));
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
            groupBox1 = new GroupBox();
            flpGameLib = new FlowLayoutPanel();
            btnDeleteGame = new Button();
            lblGameName = new Label();
            picBoxGame = new PictureBox();
            btnInstall = new Button();
            btnPlay = new Button();
            btngotopagegame = new Button();
            lstSearchResults = new ListBox();
            pictureBox1 = new PictureBox();
            toolStrip1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picBoxGame).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = Color.Black;
            toolStrip1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            toolStrip1.ImageScalingSize = new Size(64, 64);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton1, toolStripSeparator2, btnSearch, txtSearch, toolStripButton2, toolStripSeparator1, btnHome });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1135, 71);
            toolStrip1.TabIndex = 1;
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
            // groupBox1
            // 
            groupBox1.Controls.Add(flpGameLib);
            groupBox1.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(0, 74);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(250, 654);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Sản phẩm đã sở hữu";
            // 
            // flpGameLib
            // 
            flpGameLib.AllowDrop = true;
            flpGameLib.Location = new Point(6, 16);
            flpGameLib.Name = "flpGameLib";
            flpGameLib.Size = new Size(238, 632);
            flpGameLib.TabIndex = 0;
            // 
            // btnDeleteGame
            // 
            btnDeleteGame.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDeleteGame.Location = new Point(844, 352);
            btnDeleteGame.Name = "btnDeleteGame";
            btnDeleteGame.Size = new Size(119, 41);
            btnDeleteGame.TabIndex = 15;
            btnDeleteGame.Text = "Xóa game";
            btnDeleteGame.UseVisualStyleBackColor = true;
            btnDeleteGame.Click += btnDeleteGame_Click;
            // 
            // lblGameName
            // 
            lblGameName.AutoSize = true;
            lblGameName.BackColor = Color.SkyBlue;
            lblGameName.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblGameName.ForeColor = Color.BlueViolet;
            lblGameName.Location = new Point(844, 178);
            lblGameName.Name = "lblGameName";
            lblGameName.Size = new Size(0, 31);
            lblGameName.TabIndex = 11;
            // 
            // picBoxGame
            // 
            picBoxGame.BackColor = Color.SkyBlue;
            picBoxGame.Location = new Point(384, 178);
            picBoxGame.Name = "picBoxGame";
            picBoxGame.Size = new Size(409, 226);
            picBoxGame.SizeMode = PictureBoxSizeMode.StretchImage;
            picBoxGame.TabIndex = 10;
            picBoxGame.TabStop = false;
            // 
            // btnInstall
            // 
            btnInstall.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnInstall.Location = new Point(844, 282);
            btnInstall.Name = "btnInstall";
            btnInstall.Size = new Size(119, 41);
            btnInstall.TabIndex = 13;
            btnInstall.Text = "Cài đặt";
            btnInstall.UseVisualStyleBackColor = true;
            btnInstall.Click += btnInstall_Click;
            // 
            // btnPlay
            // 
            btnPlay.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPlay.Location = new Point(844, 282);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(119, 41);
            btnPlay.TabIndex = 14;
            btnPlay.Text = "Chơi game";
            btnPlay.UseVisualStyleBackColor = true;
            btnPlay.Click += btnPlay_Click;
            // 
            // btngotopagegame
            // 
            btngotopagegame.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btngotopagegame.Location = new Point(799, 423);
            btngotopagegame.Name = "btngotopagegame";
            btngotopagegame.Size = new Size(207, 33);
            btngotopagegame.TabIndex = 17;
            btngotopagegame.Text = "Trang Chủ Nhà Phát Hành";
            btngotopagegame.UseVisualStyleBackColor = true;
            btngotopagegame.Click += btngotopagegame_Click;
            // 
            // lstSearchResults
            // 
            lstSearchResults.Font = new Font("Arial", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lstSearchResults.FormattingEnabled = true;
            lstSearchResults.ItemHeight = 19;
            lstSearchResults.Location = new Point(638, 54);
            lstSearchResults.Name = "lstSearchResults";
            lstSearchResults.Size = new Size(300, 118);
            lstSearchResults.TabIndex = 18;
            lstSearchResults.Visible = false;
            lstSearchResults.Click += lstSearchResults_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-9, 74);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1153, 654);
            pictureBox1.TabIndex = 19;
            pictureBox1.TabStop = false;
            // 
            // Collection
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1135, 725);
            Controls.Add(lstSearchResults);
            Controls.Add(btngotopagegame);
            Controls.Add(btnDeleteGame);
            Controls.Add(lblGameName);
            Controls.Add(picBoxGame);
            Controls.Add(btnInstall);
            Controls.Add(btnPlay);
            Controls.Add(groupBox1);
            Controls.Add(toolStrip1);
            Controls.Add(pictureBox1);
            Name = "Collection";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Collection";
            Load += Collection_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picBoxGame).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

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
        private GroupBox groupBox1;
        private FlowLayoutPanel flpGameLib;
        private Button btnDeleteGame;
        private Label lblGameName;
        private PictureBox picBoxGame;
        private Button btnInstall;
        private Button btnPlay;
        private Button btngotopagegame;
        private ListBox lstSearchResults;
        private PictureBox pictureBox1;
    }
}