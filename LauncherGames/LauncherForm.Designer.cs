namespace LauncherGames
{
    partial class LauncherForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LauncherForm));
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
            pnlLauncher = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            flpReleasedGames = new FlowLayoutPanel();
            flpUpcomingGames = new FlowLayoutPanel();
            flpNewReleases = new FlowLayoutPanel();
            label1 = new Label();
            toolStrip1.SuspendLayout();
            pnlLauncher.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = Color.Black;
            toolStrip1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            toolStrip1.ImageScalingSize = new Size(64, 64);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton1, toolStripSeparator2, btnSearch, txtSearch, toolStripButton2, toolStripSeparator1, btnHome, toolStripButton4, toolStripButton5 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1135, 71);
            toolStrip1.TabIndex = 0;
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
            // pnlLauncher
            // 
            pnlLauncher.AutoScroll = true;
            pnlLauncher.Controls.Add(tableLayoutPanel1);
            pnlLauncher.Location = new Point(0, 103);
            pnlLauncher.Name = "pnlLauncher";
            pnlLauncher.Size = new Size(1135, 622);
            pnlLauncher.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(flpReleasedGames, 0, 2);
            tableLayoutPanel1.Controls.Add(flpUpcomingGames, 0, 3);
            tableLayoutPanel1.Controls.Add(flpNewReleases, 0, 0);
            tableLayoutPanel1.Location = new Point(0, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 17.0266838F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 0.338839471F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 31.9779758F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50.6141472F));
            tableLayoutPanel1.Size = new Size(1111, 2361);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // flpReleasedGames
            // 
            flpReleasedGames.Location = new Point(3, 413);
            flpReleasedGames.Name = "flpReleasedGames";
            flpReleasedGames.Size = new Size(1105, 748);
            flpReleasedGames.TabIndex = 1;
            // 
            // flpUpcomingGames
            // 
            flpUpcomingGames.Location = new Point(3, 1168);
            flpUpcomingGames.Name = "flpUpcomingGames";
            flpUpcomingGames.Size = new Size(1105, 328);
            flpUpcomingGames.TabIndex = 2;
            // 
            // flpNewReleases
            // 
            flpNewReleases.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            flpNewReleases.Location = new Point(3, 54);
            flpNewReleases.Name = "flpNewReleases";
            flpNewReleases.Size = new Size(1105, 294);
            flpNewReleases.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Cambria", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(0, 103);
            label1.Name = "label1";
            label1.Size = new Size(233, 27);
            label1.TabIndex = 2;
            label1.Text = "Game Mới Phát Hành";
            // 
            // LauncherForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1135, 725);
            Controls.Add(label1);
            Controls.Add(pnlLauncher);
            Controls.Add(toolStrip1);
            Name = "LauncherForm";
            Text = "LauncherForm";
            Load += LauncherForm_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            pnlLauncher.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
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
        private ToolStripTextBox txtSearch;
        private ToolStripButton btnHome;
        private ToolStripButton btnSearch;
        private ToolStripButton toolStripButton2;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton toolStripButton4;
        private ToolStripSplitButton toolStripButton5;
        private ToolStripMenuItem giảiTríToolStripMenuItem;
        private ToolStripMenuItem hànhĐộngToolStripMenuItem;
        private ToolStripMenuItem phiêuLưuToolStripMenuItem;
        private ToolStripMenuItem kinhDịToolStripMenuItem;
        private ToolStripMenuItem tâmLýToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem aministratorToolStripMenuItem;
        private Panel pnlLauncher;
        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flpReleasedGames;
        private FlowLayoutPanel flpUpcomingGames;
        private FlowLayoutPanel flpNewReleases;
        private Label label1;
    }
}