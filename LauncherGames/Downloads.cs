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

        }

        public void UpdateProgress(int progress)
        {
            progressBar.Value = progress;
            lblStatus.Text = $"Đang tải xuống... {progress}%";
        }

    }
}