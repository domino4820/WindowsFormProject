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
            pnlLauncher = new Panel();
            label1 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            flpReleasedGames = new FlowLayoutPanel();
            label2 = new Label();
            flpNewReleases = new FlowLayoutPanel();
            flpUpcomingGames = new FlowLayoutPanel();
            lstSearchResults = new ListBox();
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
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton1, toolStripSeparator2, btnSearch, txtSearch, toolStripButton2, toolStripSeparator1, btnHome });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1148, 71);
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
            // pnlLauncher
            // 
            pnlLauncher.AutoScroll = true;
            pnlLauncher.Controls.Add(label1);
            pnlLauncher.Controls.Add(tableLayoutPanel1);
            pnlLauncher.Location = new Point(0, 103);
            pnlLauncher.Name = "pnlLauncher";
            pnlLauncher.Size = new Size(1148, 622);
            pnlLauncher.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Cambria", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(3, 43);
            label1.Name = "label1";
            label1.Size = new Size(233, 27);
            label1.TabIndex = 2;
            label1.Text = "Game Mới Phát Hành";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(flpReleasedGames, 0, 2);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(flpNewReleases, 0, 0);
            tableLayoutPanel1.Controls.Add(flpUpcomingGames, 0, 3);
            tableLayoutPanel1.Location = new Point(0, 73);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 17.0266838F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 1.69419742F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 60.5675545F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20.7115631F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(1124, 2291);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // flpReleasedGames
            // 
            flpReleasedGames.AutoScroll = true;
            flpReleasedGames.Location = new Point(3, 431);
            flpReleasedGames.Name = "flpReleasedGames";
            flpReleasedGames.Size = new Size(1118, 1335);
            flpReleasedGames.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Cambria", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(3, 390);
            label2.Name = "label2";
            label2.Size = new Size(202, 27);
            label2.TabIndex = 4;
            label2.Text = "Game Thịnh Hành";
            // 
            // flpNewReleases
            // 
            flpNewReleases.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            flpNewReleases.Location = new Point(3, 49);
            flpNewReleases.Name = "flpNewReleases";
            flpNewReleases.Size = new Size(1118, 291);
            flpNewReleases.TabIndex = 3;
            // 
            // flpUpcomingGames
            // 
            flpUpcomingGames.Location = new Point(3, 1818);
            flpUpcomingGames.Name = "flpUpcomingGames";
            flpUpcomingGames.Size = new Size(1118, 470);
            flpUpcomingGames.TabIndex = 2;
            // 
            // lstSearchResults
            // 
            lstSearchResults.Font = new Font("Arial", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lstSearchResults.FormattingEnabled = true;
            lstSearchResults.ItemHeight = 19;
            lstSearchResults.Location = new Point(651, 53);
            lstSearchResults.Name = "lstSearchResults";
            lstSearchResults.Size = new Size(300, 118);
            lstSearchResults.TabIndex = 3;
            lstSearchResults.Visible = false;
            lstSearchResults.Click += lstSearchResults_Click;
            // 
            // LauncherForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1148, 725);
            Controls.Add(lstSearchResults);
            Controls.Add(pnlLauncher);
            Controls.Add(toolStrip1);
            Name = "LauncherForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LauncherForm";
            Load += LauncherForm_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            pnlLauncher.ResumeLayout(false);
            pnlLauncher.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
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
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem aministratorToolStripMenuItem;
        private Panel pnlLauncher;
        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flpReleasedGames;
        private FlowLayoutPanel flpNewReleases;
        private Label label1;
        private Label label2;
        private FlowLayoutPanel flpUpcomingGames;
        private ListBox lstSearchResults;
    }
}