using System.Windows.Forms;

namespace LauncherGames
{
    partial class Form1
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
            panelGameList = new Panel();
            CreateTableLayoutMenu = new TableLayoutPanel();
            textBox2 = new TextBox();
            btnlogin = new Button();
            button1 = new Button();
            button2 = new Button();
            pictureBox1 = new PictureBox();
            label26 = new Label();
            panel3 = new Panel();
            label25 = new Label();
            panel2 = new Panel();
            pictureLt1 = new PictureBox();
            pictureLt2 = new PictureBox();
            pictureLittleNightmares = new PictureBox();
            label16 = new Label();
            label15 = new Label();
            label13 = new Label();
            label12 = new Label();
            label14 = new Label();
            spaceshooter = new PictureBox();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            panel1 = new Panel();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            label2 = new Label();
            pictureMouthwashing = new PictureBox();
            pictureProjectZomboid = new PictureBox();
            pictureBloodyRoar2 = new PictureBox();
            pictureTheHouseofTheDead = new PictureBox();
            pictureFlappyBird = new PictureBox();
            pictureBlasphemous = new PictureBox();
            panelGameList.SuspendLayout();
            CreateTableLayoutMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureLt1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureLt2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureLittleNightmares).BeginInit();
            ((System.ComponentModel.ISupportInitialize)spaceshooter).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureMouthwashing).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureProjectZomboid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBloodyRoar2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureTheHouseofTheDead).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureFlappyBird).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBlasphemous).BeginInit();
            SuspendLayout();
            // 
            // panelGameList
            // 
            panelGameList.AutoScroll = true;
            panelGameList.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelGameList.Controls.Add(CreateTableLayoutMenu);
            panelGameList.Controls.Add(label26);
            panelGameList.Controls.Add(panel3);
            panelGameList.Controls.Add(panel2);
            panelGameList.Controls.Add(label16);
            panelGameList.Controls.Add(label15);
            panelGameList.Controls.Add(label13);
            panelGameList.Controls.Add(label12);
            panelGameList.Controls.Add(label14);
            panelGameList.Controls.Add(spaceshooter);
            panelGameList.Controls.Add(label11);
            panelGameList.Controls.Add(label10);
            panelGameList.Controls.Add(label9);
            panelGameList.Controls.Add(panel1);
            panelGameList.Controls.Add(pictureProjectZomboid);
            panelGameList.Controls.Add(pictureBloodyRoar2);
            panelGameList.Controls.Add(pictureTheHouseofTheDead);
            panelGameList.Controls.Add(pictureFlappyBird);
            panelGameList.Controls.Add(pictureBlasphemous);
            panelGameList.Dock = DockStyle.Fill;
            panelGameList.Location = new Point(0, 0);
            panelGameList.Margin = new Padding(3, 4, 3, 4);
            panelGameList.Name = "panelGameList";
            panelGameList.Size = new Size(1224, 1055);
            panelGameList.TabIndex = 4;
            panelGameList.Paint += panelGameList_Paint;
            // 
            // CreateTableLayoutMenu
            // 
            CreateTableLayoutMenu.ColumnCount = 5;
            CreateTableLayoutMenu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.78162F));
            CreateTableLayoutMenu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 21.14065F));
            CreateTableLayoutMenu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 21.1406555F));
            CreateTableLayoutMenu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 39.9370766F));
            CreateTableLayoutMenu.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 260F));
            CreateTableLayoutMenu.Controls.Add(textBox2, 3, 0);
            CreateTableLayoutMenu.Controls.Add(btnlogin, 4, 0);
            CreateTableLayoutMenu.Controls.Add(button1, 1, 0);
            CreateTableLayoutMenu.Controls.Add(button2, 2, 0);
            CreateTableLayoutMenu.Controls.Add(pictureBox1, 0, 0);
            CreateTableLayoutMenu.Dock = DockStyle.Top;
            CreateTableLayoutMenu.Location = new Point(0, 0);
            CreateTableLayoutMenu.Name = "CreateTableLayoutMenu";
            CreateTableLayoutMenu.RowCount = 1;
            CreateTableLayoutMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            CreateTableLayoutMenu.Size = new Size(1212, 50);
            CreateTableLayoutMenu.TabIndex = 35;
            // 
            // textBox2
            // 
            textBox2.Dock = DockStyle.Fill;
            textBox2.Location = new Point(574, 3);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(374, 27);
            textBox2.TabIndex = 5;
            textBox2.Text = "Tìm kiếm";
            // 
            // btnlogin
            // 
            btnlogin.Dock = DockStyle.Fill;
            btnlogin.FlatStyle = FlatStyle.Flat;
            btnlogin.Font = new Font("Arial", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnlogin.ForeColor = Color.White;
            btnlogin.Location = new Point(954, 3);
            btnlogin.Name = "btnlogin";
            btnlogin.Size = new Size(255, 44);
            btnlogin.TabIndex = 4;
            btnlogin.Text = "Đăng nhập/Đăng ký";
            btnlogin.UseVisualStyleBackColor = true;
            btnlogin.Click += btnlogin_Click;
            // 
            // button1
            // 
            button1.Dock = DockStyle.Fill;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Arial", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(172, 3);
            button1.Name = "button1";
            button1.Size = new Size(195, 44);
            button1.TabIndex = 0;
            button1.Text = "Trang chủ";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Dock = DockStyle.Fill;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Arial", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.White;
            button2.Location = new Point(373, 3);
            button2.Name = "button2";
            button2.Size = new Size(195, 44);
            button2.TabIndex = 1;
            button2.Text = "Cửa hàng";
            button2.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(3, 4);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(163, 42);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Font = new Font("Constantia", 19.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label26.ForeColor = Color.White;
            label26.Location = new Point(3, 2320);
            label26.Name = "label26";
            label26.Size = new Size(210, 40);
            label26.TabIndex = 34;
            label26.Text = "SẮP RA MẮT";
            // 
            // panel3
            // 
            panel3.Controls.Add(label25);
            panel3.Location = new Point(0, 3122);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(1212, 588);
            panel3.TabIndex = 33;
            // 
            // label25
            // 
            label25.BackColor = Color.FromArgb(64, 64, 64);
            label25.ForeColor = Color.White;
            label25.Location = new Point(0, 0);
            label25.Name = "label25";
            label25.Size = new Size(1200, 579);
            label25.TabIndex = 32;
            // 
            // panel2
            // 
            panel2.AutoScroll = true;
            panel2.BackColor = Color.FromArgb(0, 0, 64);
            panel2.Controls.Add(pictureLt1);
            panel2.Controls.Add(pictureLt2);
            panel2.Controls.Add(pictureLittleNightmares);
            panel2.Location = new Point(3, 2374);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(1197, 509);
            panel2.TabIndex = 31;
            // 
            // pictureLt1
            // 
            pictureLt1.Image = Properties.Resources.R2;
            pictureLt1.Location = new Point(951, 15);
            pictureLt1.Margin = new Padding(3, 4, 3, 4);
            pictureLt1.Name = "pictureLt1";
            pictureLt1.Size = new Size(641, 462);
            pictureLt1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureLt1.TabIndex = 15;
            pictureLt1.TabStop = false;
            // 
            // pictureLt2
            // 
            pictureLt2.Image = Properties.Resources.lngamescomscreenshot03escapingthedarkcorridorjpg_7b17a9;
            pictureLt2.Location = new Point(1722, 16);
            pictureLt2.Margin = new Padding(3, 4, 3, 4);
            pictureLt2.Name = "pictureLt2";
            pictureLt2.Size = new Size(641, 462);
            pictureLt2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureLt2.TabIndex = 14;
            pictureLt2.TabStop = false;
            // 
            // pictureLittleNightmares
            // 
            pictureLittleNightmares.Image = Properties.Resources.ltn;
            pictureLittleNightmares.Location = new Point(190, 15);
            pictureLittleNightmares.Margin = new Padding(3, 4, 3, 4);
            pictureLittleNightmares.Name = "pictureLittleNightmares";
            pictureLittleNightmares.Size = new Size(641, 462);
            pictureLittleNightmares.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureLittleNightmares.TabIndex = 13;
            pictureLittleNightmares.TabStop = false;
            pictureLittleNightmares.Click += pictureLittleNightmares_Click;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Constantia", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label16.ForeColor = Color.White;
            label16.Location = new Point(6, 936);
            label16.Name = "label16";
            label16.Size = new Size(429, 37);
            label16.TabIndex = 30;
            label16.Text = "Game được bình chọn nhiều ";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Constantia", 19.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label15.ForeColor = Color.White;
            label15.Location = new Point(3, 289);
            label15.Name = "label15";
            label15.Size = new Size(370, 40);
            label15.TabIndex = 29;
            label15.Text = "GAME MỚI TUẦN NÀY";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Comic Sans MS", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.White;
            label13.Location = new Point(969, 1510);
            label13.Name = "label13";
            label13.Size = new Size(196, 32);
            label13.TabIndex = 28;
            label13.Text = "Project Zomboid";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Comic Sans MS", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.White;
            label12.Location = new Point(354, 2124);
            label12.Name = "label12";
            label12.Size = new Size(173, 32);
            label12.TabIndex = 27;
            label12.Text = "Fighter Battle";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Comic Sans MS", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.ForeColor = Color.White;
            label14.Location = new Point(30, 2124);
            label14.Name = "label14";
            label14.Size = new Size(222, 32);
            label14.TabIndex = 26;
            label14.Text = "Đấu Trường Thú 2";
            // 
            // spaceshooter
            // 
            spaceshooter.Image = Properties.Resources.com_resestudio_galaxy_striker_sc0_2023_07_29_04_49_57_2x;
            spaceshooter.Location = new Point(306, 1658);
            spaceshooter.Margin = new Padding(3, 4, 3, 4);
            spaceshooter.Name = "spaceshooter";
            spaceshooter.Size = new Size(284, 439);
            spaceshooter.SizeMode = PictureBoxSizeMode.StretchImage;
            spaceshooter.TabIndex = 25;
            spaceshooter.TabStop = false;
            spaceshooter.Click += spaceshooter_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Comic Sans MS", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.White;
            label11.Location = new Point(611, 1510);
            label11.Name = "label11";
            label11.Size = new Size(285, 32);
            label11.TabIndex = 24;
            label11.Text = "The House of The Dead";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Comic Sans MS", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.White;
            label10.Location = new Point(373, 1510);
            label10.Name = "label10";
            label10.Size = new Size(140, 32);
            label10.TabIndex = 23;
            label10.Text = "Flappy Bird";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Comic Sans MS", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.White;
            label9.Location = new Point(59, 1510);
            label9.Name = "label9";
            label9.Size = new Size(150, 32);
            label9.TabIndex = 22;
            label9.Text = "Blasphemous";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 0, 64);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(pictureMouthwashing);
            panel1.Location = new Point(-3, 344);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1206, 509);
            panel1.TabIndex = 14;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Comic Sans MS", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.White;
            label8.Location = new Point(983, 259);
            label8.Name = "label8";
            label8.Size = new Size(70, 32);
            label8.TabIndex = 22;
            label8.Text = "2024";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Comic Sans MS", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.White;
            label7.Location = new Point(942, 198);
            label7.Name = "label7";
            label7.Size = new Size(69, 32);
            label7.TabIndex = 21;
            label7.Text = "2 GB";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Comic Sans MS", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(908, 143);
            label6.Name = "label6";
            label6.Size = new Size(181, 32);
            label6.TabIndex = 20;
            label6.Text = "Kinh dị, tâm lý";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Comic Sans MS", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(924, 87);
            label5.Name = "label5";
            label5.Size = new Size(165, 32);
            label5.TabIndex = 19;
            label5.Text = "Mouthwashing";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Comic Sans MS", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(773, 259);
            label4.Name = "label4";
            label4.Size = new Size(204, 32);
            label4.TabIndex = 18;
            label4.Text = "Năm phát hành :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Comic Sans MS", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(773, 198);
            label3.Name = "label3";
            label3.Size = new Size(163, 32);
            label3.TabIndex = 17;
            label3.Text = "Dung Lượng :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(773, 143);
            label1.Name = "label1";
            label1.Size = new Size(126, 32);
            label1.TabIndex = 16;
            label1.Text = "Thể loại :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Comic Sans MS", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(773, 87);
            label2.Name = "label2";
            label2.Size = new Size(145, 32);
            label2.TabIndex = 15;
            label2.Text = "Tên Game :";
            // 
            // pictureMouthwashing
            // 
            pictureMouthwashing.Image = Properties.Resources.capsule_616x353;
            pictureMouthwashing.Location = new Point(9, 22);
            pictureMouthwashing.Margin = new Padding(3, 4, 3, 4);
            pictureMouthwashing.Name = "pictureMouthwashing";
            pictureMouthwashing.Size = new Size(641, 462);
            pictureMouthwashing.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureMouthwashing.TabIndex = 13;
            pictureMouthwashing.TabStop = false;
            pictureMouthwashing.Click += pictureMouthwashing_Click;
            // 
            // pictureProjectZomboid
            // 
            pictureProjectZomboid.Image = Properties.Resources.OIP;
            pictureProjectZomboid.Location = new Point(916, 1050);
            pictureProjectZomboid.Margin = new Padding(3, 4, 3, 4);
            pictureProjectZomboid.Name = "pictureProjectZomboid";
            pictureProjectZomboid.Size = new Size(284, 439);
            pictureProjectZomboid.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureProjectZomboid.TabIndex = 12;
            pictureProjectZomboid.TabStop = false;
            pictureProjectZomboid.Click += pictureProjectZomboid_Click;
            // 
            // pictureBloodyRoar2
            // 
            pictureBloodyRoar2.Image = Properties.Resources.OIP__1_;
            pictureBloodyRoar2.Location = new Point(6, 1658);
            pictureBloodyRoar2.Margin = new Padding(3, 4, 3, 4);
            pictureBloodyRoar2.Name = "pictureBloodyRoar2";
            pictureBloodyRoar2.Size = new Size(284, 439);
            pictureBloodyRoar2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBloodyRoar2.TabIndex = 10;
            pictureBloodyRoar2.TabStop = false;
            pictureBloodyRoar2.Click += pictureBloodyRoar2_Click;
            // 
            // pictureTheHouseofTheDead
            // 
            pictureTheHouseofTheDead.Image = Properties.Resources.OIP__2_;
            pictureTheHouseofTheDead.Location = new Point(611, 1050);
            pictureTheHouseofTheDead.Margin = new Padding(3, 4, 3, 4);
            pictureTheHouseofTheDead.Name = "pictureTheHouseofTheDead";
            pictureTheHouseofTheDead.Size = new Size(284, 439);
            pictureTheHouseofTheDead.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureTheHouseofTheDead.TabIndex = 9;
            pictureTheHouseofTheDead.TabStop = false;
            // 
            // pictureFlappyBird
            // 
            pictureFlappyBird.Image = Properties.Resources.R;
            pictureFlappyBird.Location = new Point(306, 1050);
            pictureFlappyBird.Margin = new Padding(3, 4, 3, 4);
            pictureFlappyBird.Name = "pictureFlappyBird";
            pictureFlappyBird.Size = new Size(284, 439);
            pictureFlappyBird.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureFlappyBird.TabIndex = 8;
            pictureFlappyBird.TabStop = false;
            pictureFlappyBird.Click += pictureFlappyBird_Click;
            // 
            // pictureBlasphemous
            // 
            pictureBlasphemous.Image = Properties.Resources.z6083747040980_d4b0a0ad0349f10a1d8de33286f14e33;
            pictureBlasphemous.Location = new Point(6, 1050);
            pictureBlasphemous.Margin = new Padding(3, 4, 3, 4);
            pictureBlasphemous.Name = "pictureBlasphemous";
            pictureBlasphemous.Size = new Size(284, 439);
            pictureBlasphemous.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBlasphemous.TabIndex = 7;
            pictureBlasphemous.TabStop = false;
            pictureBlasphemous.Click += pictureBlasphemous_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.Black;
            ClientSize = new Size(1224, 1055);
            Controls.Add(panelGameList);
            DoubleBuffered = true;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "LAUNCHER GAMES";
            Load += Form1_Load;
            panelGameList.ResumeLayout(false);
            panelGameList.PerformLayout();
            CreateTableLayoutMenu.ResumeLayout(false);
            CreateTableLayoutMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureLt1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureLt2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureLittleNightmares).EndInit();
            ((System.ComponentModel.ISupportInitialize)spaceshooter).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureMouthwashing).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureProjectZomboid).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBloodyRoar2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureTheHouseofTheDead).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureFlappyBird).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBlasphemous).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Panel panelGameList;
        private System.Windows.Forms.PictureBox pictureBlasphemous;
        private System.Windows.Forms.PictureBox pictureProjectZomboid;
        private System.Windows.Forms.PictureBox pictureBloodyRoar2;
        private System.Windows.Forms.PictureBox pictureTheHouseofTheDead;
        private System.Windows.Forms.PictureBox pictureFlappyBird;
        private System.Windows.Forms.PictureBox pictureMouthwashing;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.PictureBox spaceshooter;
        private Label label25;
        private Panel panel2;
        private PictureBox pictureLittleNightmares;
        private Panel panel3;
        private Label label26;
        private PictureBox pictureLt2;
        private PictureBox pictureLt1;
        private TableLayoutPanel CreateTableLayoutMenu;
        private TextBox textBox2;
        private Button button1;
        private Button button2;
        private PictureBox pictureBox1;
        private Button btnlogin;
    }
}

