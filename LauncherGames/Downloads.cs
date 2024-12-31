using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LauncherGames
{
    public partial class ProgressForm : Form
    {
        public string GameName { get; set; }
        public string DownloadUrl { get; set; }
        public string SavePath { get; set; }

        public ProgressForm(string downloadUrl)
        {
            InitializeComponent();
        }

        private void ProgressForm_Load(object sender, EventArgs e)
        {
            // Implement the logic to start downloading the game
        }

        public void UpdateProgress(int progress)
        {
            progressBar.Value = progress;
            lblStatus.Text = $"Đang tải xuống... {progress}%";
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            // Implement pause download logic
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            // Implement resume download logic
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Implement cancel download logic
        }
    }
}