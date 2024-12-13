using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LauncherGames.Helpers;

namespace LauncherGames
{
    public partial class LittleNightMares : Form
    {
        private string gameDirectory; 
        private bool isDownloading = false;
        public LittleNightMares()
        {
            InitializeComponent();
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            if (isDownloading)
            {
                MessageBox.Show("Đang tải xuống, vui lòng đợi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Kiểm tra trạng thái cài đặt
            var gameState = GameStateManager.GetGameState("Little Nightmares");
            if (gameState.IsInstalled)
            {
                MessageBox.Show("Game đã được cài đặt. Đang khởi động.");
                PlayGame();
                return;
            }

            // Tên game
            string gameName = "Little Nightmares";
            string downloadUrl = "https://drive.google.com/uc?export=download&id=1xMR6bwAL4K-VNq_ow81kNuu0kstn0bfK";

            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Chọn thư mục để lưu game";
                folderDialog.ShowNewFolderButton = true;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    gameDirectory = folderDialog.SelectedPath;
                    string savePath = Path.Combine(gameDirectory, "Little Nightmares.zip");

                    // Đặt trạng thái đang tải xuống
                    isDownloading = true;

                    // Hiển thị tiến trình tải xuống
                    ProgressForm progressForm = new ProgressForm
                    {
                        GameName = gameName,
                        DownloadUrl = downloadUrl,
                        SavePath = savePath
                    };

                    progressForm.DownloadCompleted += () =>
                    {
                        try
                        {
                            // Giải nén ngay sau khi tải xuống hoàn tất
                            ZipFile.ExtractToDirectory(savePath, gameDirectory);

                            // Lưu trạng thái cài đặt game
                            GameStateManager.SetGameInstalled("Little Nightmares", true, gameDirectory);

                            // Cập nhật nút bấm
                            UpdateInstallButtonToPlay();

                            MessageBox.Show($"Tải xuống và giải nén thành công! Game đã được lưu tại: {gameDirectory}");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Lỗi khi giải nén: {ex.Message}");
                        }
                        finally
                        {
                            // Đặt lại trạng thái tải xuống
                            isDownloading = false;
                        }
                    };

                    progressForm.Show();
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn thư mục lưu.");
                }
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            PlayGame();
        }

        private void PlayGame()
        {
            if (string.IsNullOrEmpty(gameDirectory))
            {
                MessageBox.Show("Không tìm thấy thư mục game. Vui lòng cài đặt lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string exePath = Path.Combine(gameDirectory, "Bloody-Roar-2/Bloody-Roar-2.exe");

            if (File.Exists(exePath))
            {
                System.Diagnostics.Process.Start(exePath); // Chạy game
            }
            else
            {
                MessageBox.Show("Không tìm thấy file thực thi. Vui lòng kiểm tra lại cài đặt.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            {
                DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa game này không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(gameDirectory) && Directory.Exists(gameDirectory))
                        {
                            DeleteDirectoryContents(gameDirectory);

                            // Xóa trạng thái cài đặt
                            GameStateManager.SetGameInstalled("Little Nightmares", false, null);

                            // Cập nhật nút bấm
                            UpdatePlayButtonToInstall();

                            MessageBox.Show("Game đã được xóa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Game không tồn tại hoặc chưa được cài đặt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Đã xảy ra lỗi khi xóa game: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void DeleteDirectoryContents(string directoryPath)
        {
            try
            {
                foreach (var file in Directory.GetFiles(directoryPath))
                {
                    File.SetAttributes(file, FileAttributes.Normal); // Đặt lại thuộc tính file
                    File.Delete(file); // Xóa file
                }

                foreach (var subDirectory in Directory.GetDirectories(directoryPath))
                {
                    DeleteDirectoryContents(subDirectory); // Xóa nội dung trong thư mục con
                    Directory.Delete(subDirectory);       // Xóa thư mục con
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa nội dung thư mục: {directoryPath}\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LittleNightMares_Load(object sender, EventArgs e)
        {
            var gameState = GameStateManager.GetGameState("Little Nightmares");

            // Cập nhật `gameDirectory` từ trạng thái
            gameDirectory = gameState.GameDirectory;

            if (gameState.IsInstalled && !string.IsNullOrEmpty(gameDirectory))
            {
                UpdateInstallButtonToPlay();
            }
            else
            {
                UpdatePlayButtonToInstall();
            }
        }

        private void UpdateInstallButtonToPlay()
        {
            btnInstall.Text = "Play";
            btnInstall.Click -= btnInstall_Click;
            btnInstall.Click += btnPlay_Click;
        }

        private void UpdatePlayButtonToInstall()
        {
            btnInstall.Text = "Install";
            btnInstall.Click -= btnPlay_Click;
            btnInstall.Click += btnInstall_Click;
        }
    }
}
