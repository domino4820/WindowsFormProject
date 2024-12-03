using System;
using System.IO;
using System.Windows.Forms;
using System.IO.Compression;
using LauncherGames.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace LauncherGames
{
    public partial class BloodyRoar2 : Form
    {
        private string gameDirectory; 
        private bool isDownloading = false; 

        public BloodyRoar2()
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

            var gameState = GameStateManager.GetGameState("Bloody Roar 2");
            if (gameState.IsInstalled)
            {
                MessageBox.Show("Game đã được cài đặt. Đang khởi động.");
                PlayGame();
                return;
            }

            string gameName = "Bloody Roar 2"; // Tên game
            string downloadUrl = "https://drive.usercontent.google.com/download?id=1JrTLLWO6JQHjJJ0LzD8-AcKfNZhkE_wH&export=download&confirm=t&uuid=2ba6446a-5e77-4187-ad33-b89f54c9a853"; // Đường dẫn tải xuống

            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Chọn thư mục để lưu game";
                folderDialog.ShowNewFolderButton = true;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    gameDirectory = folderDialog.SelectedPath;
                    string savePath = Path.Combine(gameDirectory, "Bloody-Roar-2.zip");

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

                            ZipFile.ExtractToDirectory(savePath, gameDirectory);


                            File.Delete(savePath);


                            GameStateManager.SetGameInstalled("Bloody Roar 2", true, gameDirectory);


                            UpdateInstallButtonToPlay();

                            MessageBox.Show($"Tải xuống và giải nén thành công! Game đã được lưu tại: {gameDirectory}");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Lỗi khi giải nén: {ex.Message}");
                        }
                        finally
                        {

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
                System.Diagnostics.Process.Start(exePath); 
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

                    string targetDirectory = Path.Combine(gameDirectory, "Bloody-Roar-2");

                    if (!string.IsNullOrEmpty(targetDirectory) && Directory.Exists(targetDirectory))
                    {
                        DeleteDirectoryContents(targetDirectory);


                        Directory.Delete(targetDirectory);


                        GameStateManager.SetGameInstalled("Bloody Roar 2", false, null);

                        UpdatePlayButtonToInstall();

                        MessageBox.Show("Game đã được xóa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thư mục game không tồn tại hoặc chưa được cài đặt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    File.SetAttributes(file, FileAttributes.Normal);
                    File.Delete(file);
                }

                foreach (var subDirectory in Directory.GetDirectories(directoryPath))
                {
                    DeleteDirectoryContents(subDirectory);
                    Directory.Delete(subDirectory);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa nội dung thư mục: {directoryPath}\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void BloodyRoar2_Load(object sender, EventArgs e)
        {
            var gameState = GameStateManager.GetGameState("Bloody Roar 2");

        
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
