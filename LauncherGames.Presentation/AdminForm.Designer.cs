namespace LauncherGames.Presentation
{
    partial class AdminForm
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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            flpGames = new FlowLayoutPanel();
            groupBox2 = new GroupBox();
            button1 = new Button();
            cbIsExclusive = new CheckBox();
            button3 = new Button();
            btnUpdate = new Button();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            cmbReleaseStatus = new ComboBox();
            txtDownloadPath = new TextBox();
            textBox4 = new TextBox();
            picImages = new PictureBox();
            txtPrice = new TextBox();
            txtDescription = new TextBox();
            txtGameName = new TextBox();
            groupBox1 = new GroupBox();
            tabPage2 = new TabPage();
            groupBox4 = new GroupBox();
            txtNewDescription = new RichTextBox();
            groupBox3 = new GroupBox();
            button4 = new Button();
            panel1 = new Panel();
            btnAdd = new Button();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            checkBox1 = new CheckBox();
            picNewgameImages = new PictureBox();
            cmbNewReleaseStatus = new ComboBox();
            txtNewDownloadPath = new TextBox();
            txtNewPrice = new TextBox();
            txtNewGameName = new TextBox();
            tabPage3 = new TabPage();
            groupBox6 = new GroupBox();
            btnBanUser = new Button();
            btnAddBalance = new Button();
            txtAddBalanceAmount = new TextBox();
            txtBalance = new TextBox();
            txtPhoneNumber = new TextBox();
            txtEmail = new TextBox();
            txtFullname = new TextBox();
            txtUsername = new TextBox();
            groupBox5 = new GroupBox();
            flpUsers = new FlowLayoutPanel();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picImages).BeginInit();
            tabPage2.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picNewgameImages).BeginInit();
            tabPage3.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox5.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(0, 86);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1134, 647);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.Black;
            tabPage1.Controls.Add(flpGames);
            tabPage1.Controls.Add(groupBox2);
            tabPage1.Controls.Add(groupBox1);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1126, 614);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.Click += tabPage1_Click;
            // 
            // flpGames
            // 
            flpGames.AutoScroll = true;
            flpGames.Location = new Point(3, 32);
            flpGames.Name = "flpGames";
            flpGames.Size = new Size(596, 579);
            flpGames.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button1);
            groupBox2.Controls.Add(cbIsExclusive);
            groupBox2.Controls.Add(button3);
            groupBox2.Controls.Add(btnUpdate);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(cmbReleaseStatus);
            groupBox2.Controls.Add(txtDownloadPath);
            groupBox2.Controls.Add(textBox4);
            groupBox2.Controls.Add(picImages);
            groupBox2.Controls.Add(txtPrice);
            groupBox2.Controls.Add(txtDescription);
            groupBox2.Controls.Add(txtGameName);
            groupBox2.ForeColor = Color.White;
            groupBox2.Location = new Point(616, 6);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(514, 605);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Information";
            // 
            // button1
            // 
            button1.BackColor = Color.Black;
            button1.ForeColor = SystemColors.Window;
            button1.Location = new Point(196, 570);
            button1.Name = "button1";
            button1.Size = new Size(46, 29);
            button1.TabIndex = 7;
            button1.Text = "...";
            button1.UseVisualStyleBackColor = false;
            // 
            // cbIsExclusive
            // 
            cbIsExclusive.AutoSize = true;
            cbIsExclusive.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cbIsExclusive.Location = new Point(257, 448);
            cbIsExclusive.Name = "cbIsExclusive";
            cbIsExclusive.Size = new Size(103, 27);
            cbIsExclusive.TabIndex = 14;
            cbIsExclusive.Text = "Exclusive";
            cbIsExclusive.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.BackColor = Color.SkyBlue;
            button3.BackgroundImageLayout = ImageLayout.Center;
            button3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.Black;
            button3.Location = new Point(381, 520);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 13;
            button3.Text = "Delete";
            button3.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.SkyBlue;
            btnUpdate.BackgroundImageLayout = ImageLayout.Center;
            btnUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdate.ForeColor = Color.Black;
            btnUpdate.Location = new Point(253, 520);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 12;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(253, 358);
            label6.Name = "label6";
            label6.Size = new Size(124, 23);
            label6.TabIndex = 11;
            label6.Text = "Release Status";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(29, 279);
            label5.Name = "label5";
            label5.Size = new Size(133, 23);
            label5.TabIndex = 10;
            label5.Text = " DownloadPath";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(236, 197);
            label4.Name = "label4";
            label4.Size = new Size(110, 23);
            label4.TabIndex = 9;
            label4.Text = " Date Create";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(29, 197);
            label3.Name = "label3";
            label3.Size = new Size(49, 23);
            label3.TabIndex = 9;
            label3.Text = "Price";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(29, 117);
            label2.Name = "label2";
            label2.Size = new Size(95, 23);
            label2.TabIndex = 9;
            label2.Text = "Decription";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(29, 31);
            label1.Name = "label1";
            label1.Size = new Size(108, 23);
            label1.TabIndex = 8;
            label1.Text = "Game Name";
            // 
            // cmbReleaseStatus
            // 
            cmbReleaseStatus.FormattingEnabled = true;
            cmbReleaseStatus.Location = new Point(253, 384);
            cmbReleaseStatus.Name = "cmbReleaseStatus";
            cmbReleaseStatus.Size = new Size(234, 28);
            cmbReleaseStatus.TabIndex = 6;
            // 
            // txtDownloadPath
            // 
            txtDownloadPath.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDownloadPath.Location = new Point(29, 305);
            txtDownloadPath.Name = "txtDownloadPath";
            txtDownloadPath.Size = new Size(458, 30);
            txtDownloadPath.TabIndex = 5;
            // 
            // textBox4
            // 
            textBox4.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox4.Location = new Point(236, 223);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(168, 30);
            textBox4.TabIndex = 4;
            // 
            // picImages
            // 
            picImages.Location = new Point(29, 369);
            picImages.Name = "picImages";
            picImages.Size = new Size(196, 223);
            picImages.TabIndex = 3;
            picImages.TabStop = false;
            // 
            // txtPrice
            // 
            txtPrice.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPrice.Location = new Point(29, 223);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(148, 30);
            txtPrice.TabIndex = 2;
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDescription.Location = new Point(29, 143);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(458, 30);
            txtDescription.TabIndex = 1;
            // 
            // txtGameName
            // 
            txtGameName.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtGameName.Location = new Point(29, 57);
            txtGameName.Name = "txtGameName";
            txtGameName.Size = new Size(375, 30);
            txtGameName.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(3, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(596, 608);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Game";
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.Black;
            tabPage2.Controls.Add(groupBox4);
            tabPage2.Controls.Add(groupBox3);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1126, 614);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(txtNewDescription);
            groupBox4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox4.ForeColor = Color.White;
            groupBox4.Location = new Point(644, 26);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(475, 572);
            groupBox4.TabIndex = 1;
            groupBox4.TabStop = false;
            groupBox4.Text = "Decription";
            // 
            // txtNewDescription
            // 
            txtNewDescription.BackColor = Color.Black;
            txtNewDescription.ForeColor = Color.White;
            txtNewDescription.Location = new Point(0, 26);
            txtNewDescription.Name = "txtNewDescription";
            txtNewDescription.Size = new Size(475, 546);
            txtNewDescription.TabIndex = 0;
            txtNewDescription.Text = "";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(button4);
            groupBox3.Controls.Add(panel1);
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(checkBox1);
            groupBox3.Controls.Add(picNewgameImages);
            groupBox3.Controls.Add(cmbNewReleaseStatus);
            groupBox3.Controls.Add(txtNewDownloadPath);
            groupBox3.Controls.Add(txtNewPrice);
            groupBox3.Controls.Add(txtNewGameName);
            groupBox3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox3.ForeColor = Color.White;
            groupBox3.Location = new Point(8, 26);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(630, 572);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            groupBox3.Text = "Game Gathering";
            // 
            // button4
            // 
            button4.BackColor = Color.Black;
            button4.ForeColor = Color.White;
            button4.Location = new Point(224, 540);
            button4.Name = "button4";
            button4.Size = new Size(39, 26);
            button4.TabIndex = 10;
            button4.Text = "...";
            button4.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnAdd);
            panel1.Location = new Point(313, 385);
            panel1.Name = "panel1";
            panel1.Size = new Size(317, 187);
            panel1.TabIndex = 9;
            // 
            // btnAdd
            // 
            btnAdd.ForeColor = Color.Black;
            btnAdd.Location = new Point(70, 135);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 35);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "ADD";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += Add_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(28, 225);
            label9.Name = "label9";
            label9.Size = new Size(108, 23);
            label9.TabIndex = 8;
            label9.Text = "Game Name";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(28, 139);
            label8.Name = "label8";
            label8.Size = new Size(108, 23);
            label8.TabIndex = 7;
            label8.Text = "Game Name";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(28, 46);
            label7.Name = "label7";
            label7.Size = new Size(108, 23);
            label7.TabIndex = 6;
            label7.Text = "Game Name";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(313, 167);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(108, 27);
            checkBox1.TabIndex = 5;
            checkBox1.Text = " Exclusive";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // picNewgameImages
            // 
            picNewgameImages.Location = new Point(28, 301);
            picNewgameImages.Name = "picNewgameImages";
            picNewgameImages.Size = new Size(225, 254);
            picNewgameImages.TabIndex = 4;
            picNewgameImages.TabStop = false;
            // 
            // cmbNewReleaseStatus
            // 
            cmbNewReleaseStatus.FormattingEnabled = true;
            cmbNewReleaseStatus.Location = new Point(313, 301);
            cmbNewReleaseStatus.Name = "cmbNewReleaseStatus";
            cmbNewReleaseStatus.Size = new Size(290, 31);
            cmbNewReleaseStatus.TabIndex = 3;
            // 
            // txtNewDownloadPath
            // 
            txtNewDownloadPath.Location = new Point(28, 251);
            txtNewDownloadPath.Name = "txtNewDownloadPath";
            txtNewDownloadPath.Size = new Size(575, 30);
            txtNewDownloadPath.TabIndex = 2;
            // 
            // txtNewPrice
            // 
            txtNewPrice.Location = new Point(28, 165);
            txtNewPrice.Name = "txtNewPrice";
            txtNewPrice.Size = new Size(235, 30);
            txtNewPrice.TabIndex = 1;
            // 
            // txtNewGameName
            // 
            txtNewGameName.Location = new Point(28, 72);
            txtNewGameName.Name = "txtNewGameName";
            txtNewGameName.Size = new Size(330, 30);
            txtNewGameName.TabIndex = 0;
            // 
            // tabPage3
            // 
            tabPage3.BackColor = Color.Black;
            tabPage3.Controls.Add(groupBox6);
            tabPage3.Controls.Add(groupBox5);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1126, 614);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "tabPage3";
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(btnBanUser);
            groupBox6.Controls.Add(btnAddBalance);
            groupBox6.Controls.Add(txtAddBalanceAmount);
            groupBox6.Controls.Add(txtBalance);
            groupBox6.Controls.Add(txtPhoneNumber);
            groupBox6.Controls.Add(txtEmail);
            groupBox6.Controls.Add(txtFullname);
            groupBox6.Controls.Add(txtUsername);
            groupBox6.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox6.ForeColor = Color.White;
            groupBox6.Location = new Point(635, 6);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(484, 602);
            groupBox6.TabIndex = 1;
            groupBox6.TabStop = false;
            groupBox6.Text = "Information User";
            // 
            // btnBanUser
            // 
            btnBanUser.ForeColor = Color.Black;
            btnBanUser.Location = new Point(42, 546);
            btnBanUser.Name = "btnBanUser";
            btnBanUser.Size = new Size(94, 33);
            btnBanUser.TabIndex = 7;
            btnBanUser.Text = "Ban User";
            btnBanUser.UseVisualStyleBackColor = true;
            btnBanUser.Click += btnBanUser_Click;
            // 
            // btnAddBalance
            // 
            btnAddBalance.ForeColor = Color.Black;
            btnAddBalance.Location = new Point(313, 479);
            btnAddBalance.Name = "btnAddBalance";
            btnAddBalance.Size = new Size(103, 34);
            btnAddBalance.TabIndex = 6;
            btnAddBalance.Text = "Add Balance";
            btnAddBalance.UseVisualStyleBackColor = true;
            btnAddBalance.Click += btnAddBalance_Click;
            // 
            // txtAddBalanceAmount
            // 
            txtAddBalanceAmount.Location = new Point(42, 483);
            txtAddBalanceAmount.Name = "txtAddBalanceAmount";
            txtAddBalanceAmount.Size = new Size(265, 30);
            txtAddBalanceAmount.TabIndex = 5;
            // 
            // txtBalance
            // 
            txtBalance.Enabled = false;
            txtBalance.Location = new Point(42, 407);
            txtBalance.Name = "txtBalance";
            txtBalance.Size = new Size(265, 30);
            txtBalance.TabIndex = 4;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(42, 324);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(401, 30);
            txtPhoneNumber.TabIndex = 3;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(42, 232);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(401, 30);
            txtEmail.TabIndex = 2;
            // 
            // txtFullname
            // 
            txtFullname.Location = new Point(42, 146);
            txtFullname.Name = "txtFullname";
            txtFullname.Size = new Size(401, 30);
            txtFullname.TabIndex = 1;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(42, 63);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(401, 30);
            txtUsername.TabIndex = 0;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(flpUsers);
            groupBox5.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox5.ForeColor = Color.White;
            groupBox5.Location = new Point(3, 6);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(626, 602);
            groupBox5.TabIndex = 0;
            groupBox5.TabStop = false;
            groupBox5.Text = "User List";
            // 
            // flpUsers
            // 
            flpUsers.AutoScroll = true;
            flpUsers.Location = new Point(3, 29);
            flpUsers.Name = "flpUsers";
            flpUsers.Size = new Size(617, 567);
            flpUsers.TabIndex = 0;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1135, 725);
            Controls.Add(tabControl1);
            ForeColor = Color.White;
            Name = "AdminForm";
            Text = "Admin";
            Load += AdminForm_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picImages).EndInit();
            tabPage2.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picNewgameImages).EndInit();
            tabPage3.ResumeLayout(false);
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            groupBox5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private GroupBox groupBox1;
        private TabPage tabPage2;
        private GroupBox groupBox2;
        private PictureBox picImages;
        private TextBox txtPrice;
        private TextBox txtDescription;
        private TextBox txtGameName;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button button1;
        private ComboBox cmbReleaseStatus;
        private TextBox txtDownloadPath;
        private TextBox textBox4;
        private Button button3;
        private Button btnUpdate;
        private CheckBox cbIsExclusive;
        private FlowLayoutPanel flpGames;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private TextBox txtNewDownloadPath;
        private TextBox txtNewPrice;
        private TextBox txtNewGameName;
        private RichTextBox txtNewDescription;
        private CheckBox checkBox1;
        private PictureBox picNewgameImages;
        private ComboBox cmbNewReleaseStatus;
        private Label label7;
        private Label label9;
        private Label label8;
        private Button button4;
        private Panel panel1;
        private Button btnAdd;
        private TabPage tabPage3;
        private GroupBox groupBox5;
        private GroupBox groupBox6;
        private TextBox txtFullname;
        private TextBox txtUsername;
        private FlowLayoutPanel flpUsers;
        private Button btnBanUser;
        private Button btnAddBalance;
        private TextBox txtAddBalanceAmount;
        private TextBox txtBalance;
        private TextBox txtPhoneNumber;
        private TextBox txtEmail;
    }
}