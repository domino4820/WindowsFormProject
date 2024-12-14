namespace Flappy_Bird_Game
{
    public partial class FlappyBird_Project : Form
    {
        List<string> birds = new List<string>();
        List<string> pipe = new List<string>();
        int birdNum = 1;
        int pipeNum = 0;

        public FlappyBird_Project()
        {
            InitializeComponent();
            birds = Directory.GetFiles("tainguyen/birds", "*.gif").ToList();
            pipe = Directory.GetFiles("tainguyen/pipes", "*.png").ToList();

            picBird.Image = Image.FromFile(birds[birdNum]);
            picPipe.Image = Image.FromFile(pipe[pipeNum]);

            loadHighScore();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void SkinBird(object sender, EventArgs e)
        {
            birdNum += 2;
            if (birdNum > birds.Count)
            {
                birdNum = 1;
            }

            picBird.Image = Image.FromFile(birds[birdNum]);
        }

        private void SkinPipe(object sender, EventArgs e)
        {
            pipeNum += 1;
            if (pipeNum > pipe.Count - 1)
            {
                pipeNum = 0;
            }
            picPipe.Image = Image.FromFile(pipe[pipeNum]);
        }

        private void PlayButtonClick(object sender, EventArgs e)
        {
            GameScreen gameScreen = new GameScreen();
            gameScreen.loadImage(birdNum, pipeNum);
            gameScreen.Show();
        }

        private void HowPlayClick(object sender, EventArgs e)
        {
            HelpScreen howplayscreen = new HelpScreen();
            howplayscreen.Show();
        }

        private void loadHighScore()
        {
            string readScore = File.ReadAllText(@"tainguyen/score.txt");
            lblHightScore.Text = readScore;
        }

        private void loadUpDateHighScore(object sender, MouseEventArgs e)
        {
            loadHighScore();
        }
    }
}
