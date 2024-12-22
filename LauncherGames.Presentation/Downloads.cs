using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LauncherGames.Presentation
{
    public partial class ProgressForm : Form
    {
        private readonly string downloadUrl;
        private readonly HttpClient httpClient;
        private CancellationTokenSource cancellationTokenSource;
        private bool isPaused;
        private long totalBytesRead;

        public ProgressForm(string downloadUrl)
        {
            InitializeComponent();
            this.downloadUrl = downloadUrl;
            httpClient = new HttpClient();
            cancellationTokenSource = new CancellationTokenSource();
            isPaused = false;
            totalBytesRead = 0;
        }

        private async void ProgressForm_Load(object sender, EventArgs e)
        {
            lblStatus.Text = "Starting download...";
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "All files (*.*)|*.*"; // Optional: Set the file filter
                saveFileDialog.Title = "Save Game File";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string savePath = saveFileDialog.FileName;
                    await DownloadFileAsync(downloadUrl, savePath, cancellationTokenSource.Token);
                }
                else
                {
                    MessageBox.Show("Download canceled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        private async Task DownloadFileAsync(string url, string savePath, CancellationToken cancellationToken)
        {
            try
            {
                using (HttpResponseMessage response = await httpClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    response.EnsureSuccessStatusCode();

                    long totalBytes = response.Content.Headers.ContentLength ?? -1L;
                    using (Stream contentStream = await response.Content.ReadAsStreamAsync(),
                           fileStream = new FileStream(savePath, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true))
                    {
                        var buffer = new byte[8192];
                        int bytesRead;

                        while ((bytesRead = await contentStream.ReadAsync(buffer, 0, buffer.Length, cancellationToken)) != 0)
                        {
                            await fileStream.WriteAsync(buffer, 0, bytesRead, cancellationToken);
                            totalBytesRead += bytesRead;
                            UpdateProgress(totalBytesRead, totalBytes);

                            // Check if download is paused
                            while (isPaused)
                            {
                                await Task.Delay(500); // Wait for 500 milliseconds before checking again
                            }
                        }
                    }
                }

                lblStatus.Text = "Download completed successfully!";
                MessageBox.Show("Download completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (OperationCanceledException)
            {
                lblStatus.Text = "Download canceled.";
                MessageBox.Show("Download canceled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during download: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateProgress(long bytesRead, long totalBytes)
        {
            if (totalBytes != -1)
            {
                double progressPercentage = (double)bytesRead / totalBytes * 100;
                progressBar.Value = (int)Math.Round(progressPercentage);
                lblStatus.Text = $"Downloaded {bytesRead} of {totalBytes} bytes ({progressPercentage:0.00}%).";
            }
            else
            {
                lblStatus.Text = $"Downloaded {bytesRead} bytes.";
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            isPaused = true;
            lblStatus.Text = "Download paused.";
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            isPaused = false;
            lblStatus.Text = "Resuming download...";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cancellationTokenSource.Cancel();
            lblStatus.Text = "Canceling download...";
        }

    }
}