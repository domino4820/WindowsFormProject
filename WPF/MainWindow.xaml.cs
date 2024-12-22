using System;
using System.Windows;
using System.Windows.Forms;  // Ensure you add a reference to System.Windows.Forms
using LauncherGames.BLL;
using LauncherGames.DAL;

namespace LauncherGames.Presentation
{
    public partial class MainWindow : Window
    {
        private string gameDirectory;
        private bool isDownloading = false;
        private GameManager gameManager;
        private string gameName;

        public MainWindow()
        {
            InitializeComponent();
            gameManager = new GameManager();
            gameManager.ProgressChanged += UpdateProgress;
            gameManager.DownloadCompleted += OnDownloadCompleted;
        }

        private void btnInstall_Click(object sender, RoutedEventArgs e)
        {
            if (isDownloading)
            {
                System.Windows.MessageBox.Show("Đang tải xuống, vui lòng đợi.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            gameName = txtGameName.Text;
            var gameState = GameStateManager.GetGameState(gameName);
            if (gameState.IsInstalled)
            {
                System.Windows.MessageBox.Show("Game đã được cài đặt. Đang khởi động.");
                PlayGame();
                return;
            }

            string downloadUrl = gameState.DownloadPath;

            var dlg = new FolderBrowserDialog
            {
                Description = "Chọn thư mục để lưu game",
                ShowNewFolderButton = true
            };

            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                gameDirectory = dlg.SelectedPath;
                isDownloading = true;

                txtStatus.Text = "Đang tải xuống...";

                gameManager.DownloadAndInstallGameAsync(gameName, downloadUrl, gameDirectory);
            }
            else
            {
                System.Windows.MessageBox.Show("Bạn chưa chọn thư mục lưu.");
            }
        }

        private void UpdateProgress(int progress)
        {
            Dispatcher.Invoke(() =>
            {
                progressBar.Value = progress;
                txtStatus.Text = $"Đang tải xuống... {progress}%";
            });
        }

        private void OnDownloadCompleted()
        {
            Dispatcher.Invoke(() =>
            {
                isDownloading = false;
                UpdateInstallButtonToPlay();
                txtStatus.Text = "Tải xuống và giải nén thành công!";
                System.Windows.MessageBox.Show($"Tải xuống và giải nén thành công! Game đã được lưu tại: {gameDirectory}");
            });
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            PlayGame();
        }

        private void PlayGame()
        {
            if (string.IsNullOrEmpty(gameDirectory))
            {
                System.Windows.MessageBox.Show("Không tìm thấy thư mục game. Vui lòng cài đặt lại.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string exePath = System.IO.Path.Combine(gameDirectory, $"{gameName}/{gameName}.exe");

            if (System.IO.File.Exists(exePath))
            {
                System.Diagnostics.Process.Start(exePath);
            }
            else
            {
                System.Windows.MessageBox.Show("Không tìm thấy file thực thi. Vui lòng kiểm tra lại cài đặt.");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var result = System.Windows.MessageBox.Show(
                "Bạn có chắc chắn muốn xóa game này không?",
                "Xác nhận xóa",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning
            );

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    gameManager.DeleteGame(gameName, gameDirectory);
                    UpdatePlayButtonToInstall();
                    System.Windows.MessageBox.Show("Game đã được xóa thành công!", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show($"Đã xảy ra lỗi khi xóa game: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var gameState = GameStateManager.GetGameState(gameName);
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
            btnInstall.Content = "Play";
            btnInstall.Click -= btnInstall_Click;
            btnInstall.Click += btnPlay_Click;
        }

        private void UpdatePlayButtonToInstall()
        {
            btnInstall.Content = "Install";
            btnInstall.Click -= btnPlay_Click;
            btnInstall.Click += btnInstall_Click;
        }
    }
}