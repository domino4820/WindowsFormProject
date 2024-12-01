using System;
using System.IO;
using System.Windows.Forms;
using System.IO.Compression;
using LauncherGames.Helpers;

namespace LauncherGames
{
    public partial class Blasphemous : Form
    {
        private string gameDirectory; // Lưu đường dẫn thư mục game
        private bool isDownloading = false; // Trạng thái kiểm soát quá trình tải xuống

        public Blasphemous()
        {
            InitializeComponent();
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            // Kiểm tra trạng thái tải xuống
            if (isDownloading)
            {
                MessageBox.Show("Đang tải xuống, vui lòng đợi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Kiểm tra trạng thái cài đặt
            var gameState = GameStateManager.GetGameState("Blasphemous");
            if (gameState.IsInstalled)
            {
                MessageBox.Show("Game đã được cài đặt. Đang khởi động.");
                PlayGame();
                return;
            }

            // Tên game
            string gameName = "Blasphemous";
            string downloadUrl = "https://storage.googleapis.com/drive-bulk-export-anonymous/20241201T124250.281Z/4133399871716478688/788726de-81c2-49fa-8fa2-49399088b930/1/ac229286-4fe7-4b3b-8e4e-166e5fce18c3?authuser"; // Thay bằng URL tải xuống chính xác

            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Chọn thư mục để lưu game";
                folderDialog.ShowNewFolderButton = true;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    gameDirectory = folderDialog.SelectedPath;
                    string savePath = Path.Combine(gameDirectory, "Blasphemous.zip");

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

                            // Xóa file ZIP sau khi giải nén
                            File.Delete(savePath);

                            // Lưu trạng thái cài đặt game
                            GameStateManager.SetGameInstalled("Blasphemous", true, gameDirectory);

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

            string exePath = Path.Combine(gameDirectory, "Blasphemous/Blasphemous.exe");

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

        private void Blasphemous_Load(object sender, EventArgs e)
        {
            var gameState = GameStateManager.GetGameState("Blasphemous");

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
