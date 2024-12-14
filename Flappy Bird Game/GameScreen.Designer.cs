namespace Flappy_Bird_Game
{
    partial class GameScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameScreen));
            label1 = new Label();
            gameScreenPanel = new Panel();
            picPipeTop = new PictureBox();
            picPipeBot = new PictureBox();
            picBird = new PictureBox();
            lblScore = new Label();
            lblhighScore = new Label();
            GameTimer = new System.Windows.Forms.Timer(components);
            gameScreenPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picPipeTop).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picPipeBot).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picBird).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(94, 9);
            label1.Name = "label1";
            label1.Size = new Size(456, 38);
            label1.TabIndex = 0;
            label1.Text = "Flappy Bird Game Windows Form";
            // 
            // gameScreenPanel
            // 
            gameScreenPanel.BackColor = Color.SkyBlue;
            gameScreenPanel.Controls.Add(picPipeTop);
            gameScreenPanel.Controls.Add(picPipeBot);
            gameScreenPanel.Controls.Add(picBird);
            gameScreenPanel.Location = new Point(30, 50);
            gameScreenPanel.Name = "gameScreenPanel";
            gameScreenPanel.Size = new Size(590, 609);
            gameScreenPanel.TabIndex = 1;
            // 
            // picPipeTop
            // 
            picPipeTop.Image = Properties.Resources.green_pipe;
            picPipeTop.Location = new Point(420, -312);
            picPipeTop.Name = "picPipeTop";
            picPipeTop.Size = new Size(100, 430);
            picPipeTop.SizeMode = PictureBoxSizeMode.StretchImage;
            picPipeTop.TabIndex = 2;
            picPipeTop.TabStop = false;
            // 
            // picPipeBot
            // 
            picPipeBot.Image = Properties.Resources.green_pipe;
            picPipeBot.Location = new Point(420, 276);
            picPipeBot.Name = "picPipeBot";
            picPipeBot.Size = new Size(100, 430);
            picPipeBot.SizeMode = PictureBoxSizeMode.StretchImage;
            picPipeBot.TabIndex = 1;
            picPipeBot.TabStop = false;
            // 
            // picBird
            // 
            picBird.Image = Properties.Resources.FlappyBird_Face_Up;
            picBird.Location = new Point(46, 199);
            picBird.Name = "picBird";
            picBird.Size = new Size(75, 65);
            picBird.SizeMode = PictureBoxSizeMode.StretchImage;
            picBird.TabIndex = 0;
            picBird.TabStop = false;
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblScore.Location = new Point(30, 662);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(121, 38);
            lblScore.TabIndex = 2;
            lblScore.Text = "Score: 0";
            // 
            // lblhighScore
            // 
            lblhighScore.AutoSize = true;
            lblhighScore.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblhighScore.Location = new Point(403, 662);
            lblhighScore.Name = "lblhighScore";
            lblhighScore.Size = new Size(192, 38);
            lblhighScore.TabIndex = 3;
            lblhighScore.Text = "High Score: 0";
            lblhighScore.TextAlign = ContentAlignment.TopRight;
            // 
            // GameTimer
            // 
            GameTimer.Interval = 20;
            GameTimer.Tick += GameTimerEvent;
            // 
            // GameScreen
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.Black;
            ClientSize = new Size(632, 703);
            Controls.Add(lblhighScore);
            Controls.Add(lblScore);
            Controls.Add(gameScreenPanel);
            Controls.Add(label1);
            DoubleBuffered = true;
            ForeColor = Color.White;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "GameScreen";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Flappy Bird Windows Game";
            KeyDown += KeyisDown;
            KeyUp += KeyisUp;
            gameScreenPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picPipeTop).EndInit();
            ((System.ComponentModel.ISupportInitialize)picPipeBot).EndInit();
            ((System.ComponentModel.ISupportInitialize)picBird).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel gameScreenPanel;
        private PictureBox picPipeBot;
        private PictureBox picBird;
        private Label lblScore;
        private Label lblhighScore;
        private PictureBox picPipeTop;
        private System.Windows.Forms.Timer GameTimer;
    }
}