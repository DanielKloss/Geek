using System;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.Storage;

namespace TheGeek.Services.Services
{
    public class ImageDownloadService
    {
        public async Task<string> GetImageAsync(string url, string gameId)
        {
            HttpClient webClient = new HttpClient();
            byte[] image;
            StorageFile imageFile;

            try
            {
                image = await webClient.GetByteArrayAsync(url);
                imageFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(gameId, CreationCollisionOption.OpenIfExists);
                await FileIO.WriteBytesAsync(imageFile, image);
            }
            catch (Exception)
            {
                return string.Empty;
            }

            return imageFile.Path;
        }
    }
}
