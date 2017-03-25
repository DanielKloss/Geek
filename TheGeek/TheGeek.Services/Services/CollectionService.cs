using System.Net;
using System.Threading.Tasks;

namespace TheGeek.Services.Services
{
    public class CollectionService : BaseService
    {
        private const string _collectionAddress = "http://boardgamegeek.com/xmlapi2/collection";
        private const string _owned = "own=1";
        private const string _excludeExpansion = "excludesubtype=boardgameexpansion";
        private const string _expansionOnly = "subtype=boardgameexpansion";
        private const string _stats = "stats=1";
        private string _username;

        /// <summary>
        /// Uses BGG API to get all owned games in a users collection
        /// </summary>
        /// <param name="username">Username to get data for</param>
        /// <returns>XML Collection Data</returns>
        public async Task<string> GetBaseCollectionOwnedAsync(string username)
        {
            _username = "username=" + username;

            //Create Request
            HttpWebRequest request = WebRequest.Create(string.Format("{0}?{1}&{2}&{3}&{4}", _collectionAddress, _username, _owned, _excludeExpansion, _stats)) as HttpWebRequest;
            request.ContentType = "application/xml";
            request.Method = "GET";

            return await MakeRequestAsync(request);
        }

        /// <summary>
        /// Uses BGG API to get all owned expansions in a users collection
        /// </summary>
        /// <param name="username">Username to get data for</param>
        /// <returns>XML Collection Data</returns>
        public async Task<string> GetExpansionCollectionOwnedAsync(string username)
        {
            _username = "username=" + username;

            //Create Request
            HttpWebRequest request = WebRequest.Create(string.Format("{0}?{1}&{2}&{3}&{4}", _collectionAddress, _username, _owned, _expansionOnly, _stats)) as HttpWebRequest;
            request.ContentType = "application/xml";
            request.Method = "GET";

            return await MakeRequestAsync(request);
        }
    }
}
