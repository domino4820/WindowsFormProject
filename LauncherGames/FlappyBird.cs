using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Flappy_Bird_Game;


namespace LauncherGames
{
    public partial class FlappyBird : Form
    {
        private string gameExePath;

        public FlappyBird()
        {
            InitializeComponent();
        }

        private void btnPlay_Click_1(object sender, EventArgs e)
        {
            FlappyBird_Project flappyBird_Project = new FlappyBird_Project();
            flappyBird_Project.Show();
        }

        private void FlappyBird_Load(object sender, EventArgs e)
        {
        }
    }
}
