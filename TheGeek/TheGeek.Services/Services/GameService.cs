using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TheGeek.Services.Services
{
    public class GameService : BaseService
    {
        private const string _collectionAddress = "http://boardgamegeek.com/xmlapi2/thing";
        private const string _stats = "stats=1";
        private string _ids;

        /// <summary>
        /// Uses BGG API to get details about a particular game
        /// </summary>
        /// <param name="id">Id of game to get details for</param>
        /// <returns>XML Game Data</returns>
        public async Task<string> GetGameDetailsAsync(List<int> ids)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("id=");

            foreach (int id in ids)
            {
                if (id == ids.Last())
                {
                    stringBuilder.Append(id);
                }
                else
                {
                    stringBuilder.Append(id + ",");
                }
            }

            _ids = stringBuilder.ToString();

            //Create Request
            HttpWebRequest request = WebRequest.Create(string.Format("{0}?{1}&{2}", _collectionAddress, _ids, _stats)) as HttpWebRequest;
            request.ContentType = "application/xml";
            request.Method = "GET";

            return await MakeRequestAsync(request);
        }
    }
}
