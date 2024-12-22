namespace LauncherGames.Presentation
{
    partial class ProfileForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfileForm));
            lblUsername = new Label();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            txtFullName = new TextBox();
            label2 = new Label();
            label3 = new Label();
            txtSDT = new TextBox();
            txtEmail = new TextBox();
            btnCapnhat = new Button();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            btnCapNhatMK = new Button();
            txtConfirmPassword = new TextBox();
            label6 = new Label();
            txtNewPassword = new TextBox();
            label5 = new Label();
            txtPassword = new TextBox();
            label4 = new Label();
            toolStrip1 = new ToolStrip();
            toolStripButton1 = new ToolStripDropDownButton();
            tsProfile_HoSo = new ToolStripMenuItem();
            tsProfile_SoDu = new ToolStripMenuItem();
            tsProfile_ThuVien = new ToolStripMenuItem();
            tsProfile_Logout = new ToolStripMenuItem();
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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Arial", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsername.ForeColor = Color.White;
            lblUsername.Location = new Point(478, 279);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(124, 27);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Username";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(484, 85);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(195, 191);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(41, 68);
            label1.Name = "label1";
            label1.Size = new Size(82, 31);
            label1.TabIndex = 2;
            label1.Text = "Họ tên";
            // 
            // txtFullName
            // 
            txtFullName.Font = new Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFullName.Location = new Point(182, 69);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(329, 34);
            txtFullName.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(10, 158);
            label2.Name = "label2";
            label2.Size = new Size(148, 31);
            label2.TabIndex = 4;
            label2.Text = "Số điện thoại";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(41, 246);
            label3.Name = "label3";
            label3.Size = new Size(70, 31);
            label3.TabIndex = 5;
            label3.Text = "Email";
            // 
            // txtSDT
            // 
            txtSDT.Font = new Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSDT.Location = new Point(182, 159);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(329, 34);
            txtSDT.TabIndex = 6;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmail.Location = new Point(182, 247);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(329, 34);
            txtEmail.TabIndex = 7;
            // 
            // btnCapnhat
            // 
            btnCapnhat.BackColor = Color.Black;
            btnCapnhat.Font = new Font("Arial", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCapnhat.ForeColor = Color.White;
            btnCapnhat.Location = new Point(290, 316);
            btnCapnhat.Name = "btnCapnhat";
            btnCapnhat.Size = new Size(134, 41);
            btnCapnhat.TabIndex = 8;
            btnCapnhat.Text = "Cập nhật";
            btnCapnhat.UseVisualStyleBackColor = false;
            btnCapnhat.Click += btnCapnhat_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(btnCapnhat);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtFullName);
            groupBox1.Controls.Add(txtEmail);
            groupBox1.Controls.Add(txtSDT);
            groupBox1.Font = new Font("Arial", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(91, 330);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(537, 388);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin người dùng";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnCapNhatMK);
            groupBox2.Controls.Add(txtConfirmPassword);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(txtNewPassword);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(txtPassword);
            groupBox2.Controls.Add(label4);
            groupBox2.Font = new Font("Arial", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.ForeColor = Color.White;
            groupBox2.Location = new Point(654, 330);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(378, 388);
            groupBox2.TabIndex = 10;
            groupBox2.TabStop = false;
            groupBox2.Text = "Bảo mật";
            // 
            // btnCapNhatMK
            // 
            btnCapNhatMK.BackColor = Color.Black;
            btnCapNhatMK.Font = new Font("Arial", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCapNhatMK.ForeColor = Color.White;
            btnCapNhatMK.Location = new Point(113, 316);
            btnCapNhatMK.Name = "btnCapNhatMK";
            btnCapNhatMK.Size = new Size(234, 41);
            btnCapNhatMK.TabIndex = 9;
            btnCapNhatMK.Text = "Cập nhật mật khẩu";
            btnCapNhatMK.UseVisualStyleBackColor = false;
            btnCapNhatMK.Click += btnCapNhatMK_Click;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Font = new Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtConfirmPassword.Location = new Point(18, 247);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(329, 34);
            txtConfirmPassword.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(18, 213);
            label6.Name = "label6";
            label6.Size = new Size(255, 31);
            label6.TabIndex = 7;
            label6.Text = "Xác nhận mật khẩu mới";
            // 
            // txtNewPassword
            // 
            txtNewPassword.Font = new Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNewPassword.Location = new Point(18, 158);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(329, 34);
            txtNewPassword.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(18, 124);
            label5.Name = "label5";
            label5.Size = new Size(217, 31);
            label5.TabIndex = 5;
            label5.Text = "Nhập mật khẩu mới";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(18, 69);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(329, 34);
            txtPassword.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(18, 35);
            label4.Name = "label4";
            label4.Size = new Size(253, 31);
            label4.TabIndex = 3;
            label4.Text = "Nhập mật khẩu hiện tại";
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
            toolStrip1.TabIndex = 11;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            toolStripButton1.Alignment = ToolStripItemAlignment.Right;
            toolStripButton1.BackColor = Color.Black;
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton1.DropDownItems.AddRange(new ToolStripItem[] { tsProfile_HoSo, tsProfile_SoDu, tsProfile_ThuVien, tsProfile_Logout });
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
            tsProfile_HoSo.Size = new Size(207, 36);
            tsProfile_HoSo.Text = "Hồ sơ";
            // 
            // tsProfile_SoDu
            // 
            tsProfile_SoDu.BackColor = Color.Black;
            tsProfile_SoDu.ForeColor = Color.White;
            tsProfile_SoDu.Name = "tsProfile_SoDu";
            tsProfile_SoDu.Size = new Size(207, 36);
            tsProfile_SoDu.Text = "Số dư";
            // 
            // tsProfile_ThuVien
            // 
            tsProfile_ThuVien.BackColor = Color.Black;
            tsProfile_ThuVien.ForeColor = Color.White;
            tsProfile_ThuVien.Name = "tsProfile_ThuVien";
            tsProfile_ThuVien.Size = new Size(207, 36);
            tsProfile_ThuVien.Text = "Thư viện";
            // 
            // tsProfile_Logout
            // 
            tsProfile_Logout.BackColor = Color.Black;
            tsProfile_Logout.ForeColor = Color.White;
            tsProfile_Logout.Name = "tsProfile_Logout";
            tsProfile_Logout.Size = new Size(207, 36);
            tsProfile_Logout.Text = "Đăng xuất";
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
            // ProfileForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1135, 725);
            Controls.Add(toolStrip1);
            Controls.Add(groupBox2);
            Controls.Add(pictureBox1);
            Controls.Add(lblUsername);
            Controls.Add(groupBox1);
            Name = "ProfileForm";
            Text = "ProfileForm";
            Load += ProfileForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUsername;
        private PictureBox pictureBox1;
        private Label label1;
        private TextBox txtFullName;
        private Label label2;
        private Label label3;
        private TextBox txtSDT;
        private TextBox txtEmail;
        private Button btnCapnhat;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private TextBox txtConfirmPassword;
        private Label label6;
        private TextBox txtNewPassword;
        private Label label5;
        private TextBox txtPassword;
        private Label label4;
        private Button btnCapNhatMK;
        private ToolStrip toolStrip1;
        private ToolStripDropDownButton toolStripButton1;
        private ToolStripMenuItem tsProfile_HoSo;
        private ToolStripMenuItem tsProfile_SoDu;
        private ToolStripMenuItem tsProfile_ThuVien;
        private ToolStripMenuItem tsProfile_Logout;
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
    }
}