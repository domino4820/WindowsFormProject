using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace fighter_battle
{
    public partial class FormGame : Form
    {

        WindowsMediaPlayer gameMedia;
        WindowsMediaPlayer shootgMedia;
        WindowsMediaPlayer explosion;

        PictureBox[] stars;
        int backgroundspeed;
        int playerSpeed;

        PictureBox[] enemiesmunitions;
        int MenemiesmunitionsSpeed;

        PictureBox[] munitions;
        int MunitionSpeed;

        PictureBox[] enemies;
        int enemiSpeed;

        Random rnd;

        int score;
        int level;
        int dificulty;
        bool pause;
        bool gameIsover;


        public FormGame()
        {
            InitializeComponent();
        }

        private void FormGame_Load(object sender, EventArgs e)
        {
            pause = false;
            gameIsover = false;
            score = 0;
            level = 1;
            dificulty = 9;



            backgroundspeed = 4;
            playerSpeed = 4;
            MunitionSpeed = 20;
            enemiSpeed = 4;
            MenemiesmunitionsSpeed = 4;
            munitions = new PictureBox[3];
            //Image munition = Image.FromFile(@"asserts\munition.png");


            gameMedia = new WindowsMediaPlayer();
            shootgMedia = new WindowsMediaPlayer();
            explosion = new WindowsMediaPlayer();
            //Load all songs
            explosion.URL = "songs\\boom.mp3";
            gameMedia.URL = "songs\\GameSong.mp3";
            shootgMedia.URL = "songs\\shoot.mp3";
            //Setup Songs settings
            gameMedia.settings.setMode("loop", true);
            gameMedia.settings.volume = 5;
            shootgMedia.settings.volume = 1;
            explosion.settings.volume = 6;

            stars = new PictureBox[10];
            rnd = new Random();
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i] = new PictureBox();
                stars[i].BorderStyle = BorderStyle.None;
                stars[i].Location = new Point(rnd.Next(20, 580), rnd.Next(-10, 400));
                if (i % 2 == 1)
                {
                    stars[i].Size = new Size(2, 2);
                    stars[i].BackColor = Color.Wheat;
                }
                else
                {
                    stars[i].Size = new Size(3, 3);
                    stars[i].BackColor = Color.DarkGray;
                }
                this.Controls.Add(stars[i]);
            }



            //Load images
            Image munition = Image.FromFile(@"asserts\munition.png");
            Image enemi1 = Image.FromFile("asserts\\E1.png");
            Image enemi2 = Image.FromFile("asserts\\E2.png");
            Image enemi3 = Image.FromFile("asserts\\E3.png");
            Image boss1 = Image.FromFile("asserts\\Boss1.png");
            Image boss2 = Image.FromFile("asserts\\Boss2.png");
            enemies = new PictureBox[10];
            //Initialiase EnemisPictureBoxes
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i] = new PictureBox();
                enemies[i].Size = new Size(40, 40);
                enemies[i].SizeMode = PictureBoxSizeMode.Zoom;
                enemies[i].BorderStyle = BorderStyle.None;
                enemies[i].Visible = false;
                this.Controls.Add(enemies[i]);
                enemies[i].Location = new Point((i + 1) * 50, -50);
            }

            enemies[0].Image = boss1;
            enemies[1].Image = enemi2;
            enemies[2].Image = enemi3;
            enemies[3].Image = enemi3;
            enemies[4].Image = enemi1;
            enemies[5].Image = enemi3;
            enemies[6].Image = enemi2;
            enemies[7].Image = enemi3;
            enemies[8].Image = enemi2;
            enemies[9].Image = boss2;

            for (int i = 0; i < munitions.Length; i++)
            {
                munitions[i] = new PictureBox();
                munitions[i].Size = new Size(8, 8);
                munitions[i].Image = munition;
                munitions[i].SizeMode = PictureBoxSizeMode.Zoom;
                munitions[i].BorderStyle = BorderStyle.None;
                this.Controls.Add(munitions[i]);
            }
            enemiesmunitions = new PictureBox[10];
            for (int i = 0; i < enemiesmunitions.Length; i++)
            {
                enemiesmunitions[i] = new PictureBox();
                enemiesmunitions[i].Size = new Size(2, 25);
                enemiesmunitions[i].Visible = false;
                enemiesmunitions[i].BackColor = Color.Yellow;
                int x = rnd.Next(0, 10);
                enemiesmunitions[i].Location = new Point(enemies[x].Location.X, enemies[x].Location.Y - 20);
                this.Controls.Add(enemiesmunitions[i]);
            }

            gameMedia.controls.play();
        }

        private void MoveBgTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < stars.Length / 2; i++)
            {
                stars[i].Top += backgroundspeed;
                if (stars[i].Top >= this.Height)
                {
                    stars[i].Top = -stars[i].Height;

                }
            }
            for (int i = stars.Length / 2; i < stars.Length; i++)
            {
                stars[i].Top += backgroundspeed - 2;
                if (stars[i].Top >= this.Height)
                {
                    stars[i].Top = -stars[i].Height;
                }
            }
        }

        private void LeftMoveTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Left > 10)
            {
                Player.Left -= playerSpeed;
            }
        }

        private void RightMoveTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Right < 580)
            {
                Player.Left += playerSpeed;
            }
        }

        private void UpMoveTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Top > 10)
            {
                Player.Top -= playerSpeed;
            }
        }
        private void DownMoveTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Top < 400)
            {
                Player.Top += playerSpeed;
            }

        }

        private void FormGame_KeyDown(object sender, KeyEventArgs e)
        {
            if (!pause)
            {
                if (e.KeyCode == Keys.Right)
                {
                    RightMoveTimer.Start();
                }
                if (e.KeyCode == Keys.Left)
                {
                    LeftMoveTimer.Start();
                }
                if (e.KeyCode == Keys.Down)
                {
                    DownMoveTimer.Start();
                }
                if (e.KeyCode == Keys.Up)
                {
                    UpMoveTimer.Start();
                }
            }

        }

        private void FormGame_KeyUp(object sender, KeyEventArgs e)
        {
            RightMoveTimer.Stop();
            LeftMoveTimer.Stop();
            DownMoveTimer.Stop();
            UpMoveTimer.Stop();

            if (e.KeyCode == Keys.Space)
            {
                if (!gameIsover)
                {
                    if (pause)
                    {
                        StartTimers();
                        label1.Visible = false;
                        gameMedia.controls.play(); ;
                        pause = false;
                    }
                    else
                    {
                        label1.Location = new Point(this.Width / 2 - 120, 150);
                        label1.Text = "PAUSED";
                        label1.Visible = true;
                        gameMedia.controls.pause();
                        StopTimers();
                        pause = true;
                    }
                }
            }

        }

        private void MoveMinitionTimer_Tick(object sender, EventArgs e)
        {
            shootgMedia.controls.play();
            for (int i = 0; i < munitions.Length; i++)
                if (munitions[i].Top > 0)
                {
                    munitions[i].Visible = true;
                    munitions[i].Top -= MunitionSpeed;
                    Collision();
                }
                else
                {
                    munitions[i].Visible = false;
                    munitions[i].Location = new Point(Player.Location.X + 20, Player.Location.Y - i * 30);
                }

        }

        private void MoveEnemiesTImer_Tick(object sender, EventArgs e)
        {
            MoveEnemies(enemies, enemiSpeed);
        }

        private void MoveEnemies(PictureBox[] array, int speed)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i].Visible = true;
                array[i].Top += speed;
                if (array[i].Top > this.Height)
                {
                    array[i].Location = new Point((i + 1) * 50, -200);
                }
            }
        }
        private void Collision()
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                if (munitions[0].Bounds.IntersectsWith(enemies[i].Bounds)
                || munitions[1].Bounds.IntersectsWith(enemies[i].Bounds) || munitions[2].Bounds.IntersectsWith(enemies[i].Bounds))
                {
                    explosion.controls.play();

                    score += 5;
                    scorelbl.Text = (score < 10) ? "0" + score.ToString() : score.ToString();

                    if (score % 30 == 0)
                    {
                        level += 1;
                        levellbl.Text = (level < 10) ? "0" + level.ToString() : level.ToString();

                        if (enemiSpeed <= 10 && MenemiesmunitionsSpeed <= 10 && dificulty >= 0)
                        {
                            dificulty--;
                            enemiSpeed++;
                            MenemiesmunitionsSpeed++;

                        }
                        if (level == 10)
                        {
                            GameOver("NICE DONE");
                        }
                    }
                    enemies[i].Location = new Point((i + 1) * 50, -100);
                }
                if (Player.Bounds.IntersectsWith(enemies[i].Bounds))
                {
                    explosion.settings.volume = 30;
                    explosion.controls.play();
                    Player.Visible = false;
                    GameOver("Game Over");
                }


            }
        }
        private void GameOver(String str)
        {
            label1.Text = str;
            label1.Location = new Point(120, 120);
            label1.Visible = true;
            button1.Visible = true;
            button2.Visible = true;

            gameMedia.controls.stop();
            StopTimers();
        }
        //Stop Timers
        private void StopTimers()
        {
            MoveBgTimer.Stop();
            MoveEnemiesTImer.Stop();
            MoveMinitionTimer.Stop();
            enemiesMunitionTiimer.Stop();
        }
        //Start Timers
        private void StartTimers()
        {
            MoveBgTimer.Start();
            MoveEnemiesTImer.Start();
            MoveMinitionTimer.Start();
            enemiesMunitionTiimer.Start();
        }

        private void enemiesMunitionTiimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < enemiesmunitions.Length; i++)
                if (enemiesmunitions[i].Top < this.Height)
                {
                    enemiesmunitions[i].Visible = true;
                    enemiesmunitions[i].Top += MenemiesmunitionsSpeed;
                    CollisionWithEnemisMunition();
                }
                else
                {
                    enemiesmunitions[i].Visible = false;
                    int x = rnd.Next(0, 10);
                    enemiesmunitions[i].Location = new Point(enemies[x].Location.X + 20, enemies[x].Location.Y + 30);
                }
        }
        private void CollisionWithEnemisMunition()
        {
            for (int i = 0; i < enemiesmunitions.Length; i++)
            {
                if (enemiesmunitions[i].Bounds.IntersectsWith(Player.Bounds))
                {
                    enemiesmunitions[i].Visible = false;
                    explosion.settings.volume = 30;
                    explosion.controls.play();
                    Player.Visible = false;
                    GameOver("Game Over");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            InitializeComponent();
            FormGame_Load(e, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
