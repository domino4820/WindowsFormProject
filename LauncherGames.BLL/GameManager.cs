using System;
using System.IO;
using System.IO.Compression;
using System.Net.Http;
using System.Threading.Tasks;
using LauncherGames.DAL;

namespace LauncherGames.BLL
{
    public class GameManager
    {
        public event Action<int> ProgressChanged;
        public event Action DownloadCompleted;

        public async Task DownloadAndInstallGameAsync(string gameName, string downloadUrl, string installationPath)
        {
            if (!Directory.Exists(installationPath))
            {
                Directory.CreateDirectory(installationPath);
            }

            string savePath = Path.Combine(installationPath, $"{gameName}.zip");

            try
            {
                await DownloadFileAsync(downloadUrl, savePath, progress =>
                {
                    ProgressChanged?.Invoke(progress);
                });

                ZipFile.ExtractToDirectory(savePath, installationPath);
                File.Delete(savePath);

                GameStateManager.SetGameInstalled(gameName, true, installationPath);

                DownloadCompleted?.Invoke();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while downloading or extracting: {ex.Message}");
            }
        }

        private async Task DownloadFileAsync(string url, string destinationPath, Action<int> progressCallback)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead))
                {
                    response.EnsureSuccessStatusCode();
                    long totalBytes = response.Content.Headers.ContentLength ?? -1L;
                    long totalBytesRead = 0L;
                    byte[] buffer = new byte[8192];

                    using (Stream contentStream = await response.Content.ReadAsStreamAsync(), fileStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write, FileShare.None, buffer.Length, true))
                    {
                        int bytesRead;
                        while ((bytesRead = await contentStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                        {
                            await fileStream.WriteAsync(buffer, 0, bytesRead);
                            totalBytesRead += bytesRead;
                            if (totalBytes != -1)
                            {
                                int progressPercentage = (int)((totalBytesRead * 100) / totalBytes);
                                progressCallback(progressPercentage);
                            }
                        }
                    }
                }
            }
        }

        public void DeleteGame(string gameName, string installationPath)
        {
            string targetDirectory = Path.Combine(installationPath, gameName);

            if (Directory.Exists(targetDirectory))
            {
                DeleteDirectoryContents(targetDirectory);
                Directory.Delete(targetDirectory);
                GameStateManager.SetGameInstalled(gameName, false, null);
            }
        }

        private void DeleteDirectoryContents(string directoryPath)
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
    }
}