using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace LauncherGames.BLL
{
    public class DownloadGame
    {
        public static async Task DownloadFileAsync(string url, string destinationPath, Action<int> progressCallback)
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
    }
}