namespace LauncherGames
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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Arial", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsername.ForeColor = Color.White;
            lblUsername.Location = new Point(380, 279);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(124, 27);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Username";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(397, 73);
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
            txtFullName.TextChanged += txtFullName_TextChanged;
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
            txtSDT.TextChanged += txtSDT_TextChanged;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmail.Location = new Point(182, 247);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(329, 34);
            txtEmail.TabIndex = 7;
            txtEmail.TextChanged += txtEmail_TextChanged;
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
            groupBox1.Location = new Point(16, 330);
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
            groupBox2.Location = new Point(574, 330);
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
            // ProfileForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(964, 744);
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
    }
}