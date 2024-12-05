using System;
using System.IO;
using System.Windows.Forms;
using LauncherGames.Helpers;

namespace LauncherGames
{
    public partial class FlappyBird : Form
    {
        private string gameDirectory;
        private bool isDownloading = false;

        public FlappyBird()
        {
            InitializeComponent();
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            if (isDownloading)
            {
                MessageBox.Show("Đang tải xuống, vui lòng đợi.");
                return;
            }

            var gameState = GameStateManager.GetGameState("Flappy Bird");
            if (gameState.IsInstalled)
            {
                MessageBox.Show("Game đã được cài đặt. Đang khởi động.");
                PlayGame();
                return;
            }

            string gameName = "Flappy Bird";
            string downloadUrl = "https://storage.googleapis.com/drive-bulk-export-anonymous/20241201T130106.924Z/4133399871716478688/b556a49e-90b4-43cd-8021-37f5524cd24a/1/63685607-1043-45fa-a124-74f1e5d5bf98?authuser"; // Link tải file zip game
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Chọn thư mục để lưu game";

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    gameDirectory = folderDialog.SelectedPath;
                    string savePath = Path.Combine(gameDirectory, "Flappy Bird.zip");

                    isDownloading = true;

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
                            System.IO.Compression.ZipFile.ExtractToDirectory(savePath, gameDirectory);
                            File.Delete(savePath);

                            GameStateManager.SetGameInstalled("Flappy Bird", true, gameDirectory);

                            UpdateInstallButtonToPlay();

                            MessageBox.Show($"Game đã được cài đặt thành công tại: {gameDirectory}");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Lỗi khi cài đặt: {ex.Message}");
                        }
                        finally
                        {
                            isDownloading = false;
                        }
                    };

                    progressForm.Show();
                }
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            PlayGame();
        }

        private void PlayGame()
        {
            string exePath = Path.Combine(gameDirectory, "Flappy Bird/Flappy-Bird-Game.exe");

            if (File.Exists(exePath))
            {
                System.Diagnostics.Process.Start(exePath);
            }
            else
            {
                MessageBox.Show("Không tìm thấy file thực thi. Vui lòng kiểm tra lại.");
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
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
                        GameStateManager.SetGameInstalled("Bloody Roar 2", false, null);

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

        private void FlappyBirdForm_Load(object sender, EventArgs e)
        {
            var gameState = GameStateManager.GetGameState("Flappy Bird");
            gameDirectory = gameState.GameDirectory;

            if (gameState.IsInstalled)
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
