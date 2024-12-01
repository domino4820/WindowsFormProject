using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LauncherGames.Helpers;


namespace LauncherGames
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureMouthwashing.MouseEnter += Picture_MouseEnter;
            pictureMouthwashing.MouseLeave += Picture_MouseLeave;

            pictureBlasphemous.MouseEnter += Picture_MouseEnter;
            pictureBlasphemous.MouseLeave += Picture_MouseLeave;

            pictureBloodyRoar2.MouseEnter += Picture_MouseEnter;
            pictureBloodyRoar2.MouseLeave += Picture_MouseLeave;

            pictureFlappyBird.MouseEnter += Picture_MouseEnter;
            pictureFlappyBird.MouseLeave += Picture_MouseLeave;

            pictureLittleNightMares.MouseEnter += Picture_MouseEnter;
            pictureLittleNightMares.MouseLeave += Picture_MouseLeave;

            pictureProjectZomboid.MouseEnter += Picture_MouseEnter;
            pictureProjectZomboid.MouseLeave += Picture_MouseLeave;

            pictureTheHouseofTheDead.MouseEnter += Picture_MouseEnter;
            pictureTheHouseofTheDead.MouseLeave += Picture_MouseLeave;




        }

        private void Picture_MouseEnter(object sender, EventArgs e)
        {
            if (sender is PictureBox pictureBox)
            {
                pictureBox.BorderStyle = BorderStyle.Fixed3D;
            }
        }

        private void Picture_MouseLeave(object sender, EventArgs e)
        {
            if (sender is PictureBox pictureBox)
            {
                pictureBox.BorderStyle = BorderStyle.None;
            }
        }

        private void pictureMouthwashing_Click(object sender, EventArgs e)
        {
            InfoMouthWashing infoMouthWashing = new InfoMouthWashing();
            infoMouthWashing.Show();
        }

        private void panelGameList_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBloodyRoar2_Click(object sender, EventArgs e)
        {
            BloodyRoar2 infoBloodyRoar2 = new BloodyRoar2();
            infoBloodyRoar2.Show();
        }

        private void pictureFlappyBird_Click(object sender, EventArgs e)
        {
            FlappyBird flappyBird = new FlappyBird();
            flappyBird.Show();
        }

        private void pictureBlasphemous_Click(object sender, EventArgs e)
        {
            Blasphemous blasphemous = new Blasphemous();
            blasphemous.Show();
        }
    }
}
