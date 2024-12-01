using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LauncherGames
{
    public partial class ProgressForm : Form
    {
        public ProgressForm()
        {
            InitializeComponent();
        }

        public string GameName { get; set; }
        public string DownloadUrl { get; set; }
        public string SavePath { get; set; }

        private CancellationTokenSource cancellationTokenSource;
        private bool isPaused = false;
        private long downloadedBytes = 0; // Dữ liệu đã tải
        private SemaphoreSlim pauseSemaphore = new SemaphoreSlim(1, 1); // Semaphore kiểm soát tạm dừng

        public event Action DownloadCompleted;

        private async void ProgressForm_Load(object sender, EventArgs e)
        {
            cancellationTokenSource = new CancellationTokenSource();

            // Hiển thị tên game
            this.Text = $"Đang tải: {GameName}";

            // Bắt đầu tải xuống
            await DownloadFileAsync(DownloadUrl, SavePath, cancellationTokenSource.Token);
        }

        private async Task DownloadFileAsync(string url, string savePath, CancellationToken cancellationToken)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Gửi yêu cầu tải xuống
                    var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
                    response.EnsureSuccessStatusCode();

                    // Tổng số byte của file
                    var totalBytes = response.Content.Headers.ContentLength ?? -1L;

                    using (var stream = await response.Content.ReadAsStreamAsync())
                    using (var fileStream = new FileStream(savePath, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        byte[] buffer = new byte[8192];
                        int bytesRead;
                        long totalBytesRead = 0;

                        while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length, cancellationToken)) > 0)
                        {
                            // Kiểm tra trạng thái tạm dừng
                            await pauseSemaphore.WaitAsync(); // Chờ cho đến khi không ở trạng thái tạm dừng
                            pauseSemaphore.Release();

                            fileStream.Write(buffer, 0, bytesRead);
                            totalBytesRead += bytesRead;

                            // Cập nhật ProgressBar
                            if (totalBytes > 0)
                            {
                                int progress = (int)((double)totalBytesRead / totalBytes * 100);
                                Invoke(new Action(() =>
                                {
                                    progressBarDownload.Value = progress;
                                }));
                            }
                        }
                    }

                    // Tải xuống hoàn tất
                    DownloadCompleted?.Invoke();
                    MessageBox.Show("Tải xuống hoàn tất!");
                    this.Close();
                }
                catch (TaskCanceledException)
                {
                    MessageBox.Show("Tải xuống đã bị hủy.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel(); // Hủy tiến trình tải xuống
                MessageBox.Show("Tiến trình tải xuống đã bị hủy.");
                this.Close();
            }
        }

        private void btnPause_Click_1(object sender, EventArgs e)
        {
            if (!isPaused)
            {
                isPaused = true; // Đặt trạng thái tạm dừng
                pauseSemaphore.Wait(); // Ngăn các tác vụ tiếp tục
                btnPause.Enabled = false;
                btnResume.Enabled = true;
                MessageBox.Show("Tạm dừng tải xuống.");
            }
        }

        private void btnResume_Click_1(object sender, EventArgs e)
        {
            if (isPaused)
            {
                isPaused = false; // Bỏ trạng thái tạm dừng
                pauseSemaphore.Release(); // Cho phép tiếp tục các tác vụ
                btnPause.Enabled = true;
                btnResume.Enabled = false;
                MessageBox.Show("Tiếp tục tải xuống.");
            }
        }

        

    }
}
