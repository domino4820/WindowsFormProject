using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Diagnostics;
namespace Flappy_Bird_Game
{
    public partial class GameScreen : Form
    {   
        List<string> bird = new List<string>();
        List<string> pipes = new List<string>();

        int gravity = 10;
        int score = 0;
        int highscore = 0;
        int pipeSpeed = 10;
        int birdUpNum = 0;
        int birdDownNum = 0;

        Random random = new Random();
        SoundPlayer soundPlayer = new SoundPlayer();

        bool gameOver = false;
        bool playJumpSound = false;


        public GameScreen()
        {
            InitializeComponent();
            setUpGame();
            vitriPipes();

            bird = Directory.GetFiles("tainguyen/birds", "*.gif").ToList();
            pipes = Directory.GetFiles("tainguyen/pipes", "*.png").ToList();

        }

        private void KeyisDown(object sender, KeyEventArgs e)
        {
            if (gameOver)
            {
                return;
            }

            if (e.KeyCode == Keys.Space)
            {
                picBird.Image = Image.FromFile(bird[birdUpNum]);
                gravity = - 10;
            }

            if(playJumpSound == false)
            {
                soundPlayer.SoundLocation = @"tainguyen/sound/jumping.wav";
                soundPlayer.Play();
                playJumpSound = true;
            }
        }

        private void KeyisUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                picBird.Image = Image.FromFile(bird[birdDownNum]);
                gravity = 10;
                playJumpSound = false;
            }

            if(e.KeyCode == Keys.R && gameOver)
            {
                setUpGame();
            }
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            picBird.Top += gravity;
            picPipeTop.Left -= pipeSpeed;
            picPipeBot.Left -= pipeSpeed;
            lblScore.Text = "Score: " + score;

            if(picPipeTop.Left < -150)
            {
                picPipeTop.Left = 750;
                picPipeBot.Left = 750;
                score += 1;
                vitriPipes();
            }

            if(score > 5)
            {
                pipeSpeed = 16;
            }

            if (score > 10)
            {
                pipeSpeed = 20;
            }

            if (picBird.Bounds.IntersectsWith(picPipeTop.Bounds)
                || picBird.Bounds.IntersectsWith(picPipeBot.Bounds)
                || picBird.Top < -100 || picBird.Top > gameScreenPanel.Height
                )
            {
                endGame();
            }

        }

        private void setUpGame()
        {
            picBird.Top = 175;
            picPipeTop.Left = 750;
            picPipeBot.Left = 750;
            score = 0;
            pipeSpeed = 10;
            gameOver = false;
            lblScore.Text = "Score: " + score;
            lblhighScore.Text = "High score: " + highscore;
            GameTimer.Start();
        }

        public void loadImage(int birdNum, int pipeNum)
        {
            birdUpNum = birdNum;
            birdDownNum = birdNum - 1;

            picBird.Image = Image.FromFile(bird[birdDownNum]);
            picPipeTop.Image = Image.FromFile(pipes[pipeNum]);
            picPipeTop.Image.RotateFlip(RotateFlipType.RotateNoneFlipY);
            picPipeBot.Image = Image.FromFile(pipes[pipeNum]);
        }

        private void vitriPipes()
        {
            int i = random.Next(1, 5);

            switch (i)
            {
                case 1:
                    picPipeTop.Top = -75;
                    picPipeBot.Top = 513;
                break;

                case 2:
                    picPipeTop.Top = -364;
                    picPipeBot.Top = 224;
                    break; 

                case 3:
                    picPipeTop.Top = -166;
                    picPipeBot.Top = 422;
                break;

                case 4:
                    picPipeTop.Top = -312;
                    picPipeBot.Top = 276;
                break;
            }
        }

        private void loadHighScore()
        {
            string readscore = File.ReadAllText(@"tainguyen/score.txt");
            highscore = int.Parse(readscore);
        }

        private void endGame()
        {
            GameTimer.Stop();
            gameOver = true;
            lblScore.Text += " - Press R to Restart!";
            soundPlayer.SoundLocation = @"tainguyen/sound/hit.wav";
            soundPlayer.Play();

            if(score > highscore)
            {
                highscore = score;
                string newScore = highscore.ToString();
                File.WriteAllText(@"tainguyen/score.txt", newScore);
            }
        }

        

    }
}
