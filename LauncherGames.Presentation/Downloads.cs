using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LauncherGames.Presentation
{
    public partial class ProgressForm : Form
    {
        public string GameName { get; set; }
        public string DownloadUrl { get; set; }
        public string SavePath { get; set; }


        public ProgressForm(string downloadUrl)
        {
            InitializeComponent();
            DownloadUrl = downloadUrl;

        }

        private async void ProgressForm_Load(object sender, EventArgs e)
        {

        }

        public void UpdateProgress(int progress)
        {
            progressBar.Value = progress;
            lblStatus.Text = $"Đang tải xuống... {progress}%";
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            //isPaused = true;
            //lblStatus.Text = "Download paused.";
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            //isPaused = false;
            //lblStatus.Text = "Resuming download...";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //cancellationTokenSource.Cancel();
            //lblStatus.Text = "Canceling download...";
        }

    }
}