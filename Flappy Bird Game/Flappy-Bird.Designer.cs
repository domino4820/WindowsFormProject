namespace Flappy_Bird_Game
{
    partial class FlappyBird_Project
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FlappyBird_Project));
            pictureBox1 = new PictureBox();
            picBird = new PictureBox();
            picPipe = new PictureBox();
            label2 = new Label();
            lblHightScore = new Label();
            btnPlay = new Button();
            btnHowPlay = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picBird).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picPipe).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.title_text;
            pictureBox1.Location = new Point(-2, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(584, 74);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // picBird
            // 
            picBird.Image = Properties.Resources.FlappyBird_Face_Up;
            picBird.Location = new Point(240, 101);
            picBird.Name = "picBird";
            picBird.Size = new Size(110, 100);
            picBird.SizeMode = PictureBoxSizeMode.StretchImage;
            picBird.TabIndex = 1;
            picBird.TabStop = false;
            picBird.Click += SkinBird;
            // 
            // picPipe
            // 
            picPipe.Image = Properties.Resources.green_pipe;
            picPipe.Location = new Point(240, 348);
            picPipe.Name = "picPipe";
            picPipe.Size = new Size(110, 420);
            picPipe.SizeMode = PictureBoxSizeMode.StretchImage;
            picPipe.TabIndex = 2;
            picPipe.TabStop = false;
            picPipe.Click += SkinPipe;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(168, 221);
            label2.Name = "label2";
            label2.Size = new Size(257, 50);
            label2.TabIndex = 4;
            label2.Text = "Hight Score : ";
            // 
            // lblHightScore
            // 
            lblHightScore.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHightScore.Location = new Point(168, 271);
            lblHightScore.Name = "lblHightScore";
            lblHightScore.Size = new Size(257, 50);
            lblHightScore.TabIndex = 5;
            lblHightScore.Text = "00";
            lblHightScore.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnPlay
            // 
            btnPlay.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPlay.Location = new Point(12, 212);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(130, 145);
            btnPlay.TabIndex = 6;
            btnPlay.Text = "PLAY";
            btnPlay.UseVisualStyleBackColor = true;
            btnPlay.Click += PlayButtonClick;
            // 
            // btnHowPlay
            // 
            btnHowPlay.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHowPlay.Location = new Point(440, 212);
            btnHowPlay.Name = "btnHowPlay";
            btnHowPlay.Size = new Size(130, 145);
            btnHowPlay.TabIndex = 7;
            btnHowPlay.Text = "HOW TO PLAY";
            btnHowPlay.UseVisualStyleBackColor = true;
            btnHowPlay.Click += HowPlayClick;
            // 
            // FlappyBird_Project
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SkyBlue;
            ClientSize = new Size(582, 613);
            Controls.Add(btnHowPlay);
            Controls.Add(btnPlay);
            Controls.Add(lblHightScore);
            Controls.Add(label2);
            Controls.Add(picPipe);
            Controls.Add(picBird);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FlappyBird_Project";
            Text = "Flappy Bird";
            Load += Form1_Load;
            MouseMove += loadUpDateHighScore;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)picBird).EndInit();
            ((System.ComponentModel.ISupportInitialize)picPipe).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox picBird;
        private PictureBox picPipe;
        private Label label2;
        private Label lblHightScore;
        private Button btnPlay;
        private Button btnHowPlay;
    }
}
