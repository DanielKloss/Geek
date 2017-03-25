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
            byte[] image = await webClient.GetByteArrayAsync(url);

            StorageFile imageFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(gameId, CreationCollisionOption.OpenIfExists);
            await FileIO.WriteBytesAsync(imageFile, image);

            return imageFile.Path;
        }
    }
}
