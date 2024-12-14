using System;
using System.IO;
using System.Windows.Forms;

namespace LauncherGames
{
    public partial class SpaceShooter : Form
    {
        private string gameExePath;

        public SpaceShooter()
        {
            InitializeComponent();
            // Đường dẫn đầy đủ đến file .appref-ms
            gameExePath = @"D:\WINFORM\fighter battle\fighter battle.appref-ms";
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            PlayGame();
        }

        private void PlayGame()
        {
            if (File.Exists(gameExePath))
            {
                try
                {
                    System.Diagnostics.Process.Start(gameExePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Không thể chạy file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy file thực thi. Vui lòng kiểm tra lại đường dẫn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
