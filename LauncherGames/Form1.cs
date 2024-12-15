using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flappy_Bird_Game;
using LauncherGames.Helpers;


namespace LauncherGames
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool isUserLoggedIn = false;
        private string loggedInUsername = "";

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

            pictureProjectZomboid.MouseEnter += Picture_MouseEnter;
            pictureProjectZomboid.MouseLeave += Picture_MouseLeave;

            pictureTheHouseofTheDead.MouseEnter += Picture_MouseEnter;
            pictureTheHouseofTheDead.MouseLeave += Picture_MouseLeave;

            pictureLittleNightmares.MouseEnter += Picture_MouseEnter;
            pictureLittleNightmares.MouseLeave += Picture_MouseLeave;

            pictureLt1.MouseEnter += Picture_MouseEnter;
            pictureLt1.MouseLeave += Picture_MouseLeave;

            pictureLt2.MouseEnter += Picture_MouseEnter;
            pictureLt2.MouseLeave += Picture_MouseLeave;

            spaceshooter.MouseEnter += Picture_MouseEnter;
            spaceshooter.MouseLeave += Picture_MouseLeave;

            UpdateLoginMenu();
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

        private void pictureProjectZomboid_Click(object sender, EventArgs e)
        {
            ProjectZomboid projectZomboid = new ProjectZomboid();
            projectZomboid.Show();
        }

        private void pictureLittleNightmares_Click(object sender, EventArgs e)
        {
            LittleNightMares littleNightMares = new LittleNightMares();
            littleNightMares.Show();
        }

        private void spaceshooter_Click(object sender, EventArgs e)
        {
            SpaceShooter spaceshooter = new SpaceShooter();
            spaceshooter.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register registerForm = new Register();
            registerForm.ShowDialog();
            this.Show();
        }

        private void LoginToolStripenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (!isUserLoggedIn)
            {
                // Mở Form đăng nhập
                Register loginForm = new Register();
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // Nếu đăng nhập thành công, cập nhật trạng thái
                    isUserLoggedIn = true;
                    loggedInUsername = loginForm.LoggedInUsername; // Lấy tên người dùng từ LoginForm
                    UpdateLoginMenu();
                }
            }
            else
            {
                // Mở Form hồ sơ
                ProfileForm profileForm = new ProfileForm(loggedInUsername);
                profileForm.ShowDialog();
            }
            this.Show();
        }

        private void UpdateLoginMenu()
        {
            if (isUserLoggedIn)
            {
                LoginToolStripenuItem.Text = "Hồ sơ"; // Đổi tên thành "Hồ sơ"
                //LoginToolStripenuItem.Image = Properties.Resources.ProfileIcon; // Thay đổi icon (nếu cần)
            }
            else
            {
                LoginToolStripenuItem.Text = "Đăng nhập/Đăng ký";
                //LoginToolStripenuItem.Image = Properties.Resources.LoginIcon;
            }
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isUserLoggedIn = false;
            loggedInUsername = null;
            LoginToolStripenuItem.Text = "Đăng nhập/Đăng ký";
            // Hiển thị thông báo cho người dùng
            MessageBox.Show("Bạn đã đăng xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Đóng Form hiện tại 
            //this.Hide();
            //LoginForm loginForm = new LoginForm();
            //loginForm.ShowDialog();

            // Sau khi đóng Form đăng nhập, đóng luôn Form chính
            //this.Close();
        }

        private void sốDưToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TransactionForm transactionForm = new TransactionForm(loggedInUsername);
            transactionForm.ShowDialog();
        }
    }
}
