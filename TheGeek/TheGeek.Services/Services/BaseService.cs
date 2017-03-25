using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace TheGeek.Services.Services
{
    public abstract class BaseService
    {
        /// <summary>
        /// Invokes a request and reads the data into a string
        /// </summary>
        /// <param name="request">The request to invoke</param>
        /// <returns>Web response data</returns>
        protected async Task<string> MakeRequestAsync(HttpWebRequest request)
        {
            string responseData = string.Empty;

            //Invoke request
            HttpWebResponse response = await request.GetResponseAsync() as HttpWebResponse;

            if (response.StatusCode == HttpStatusCode.Accepted)
            {
                return await MakeRequestAsync(request);
            }
            else if (response.StatusCode == HttpStatusCode.OK)
            {
                using (response)
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        //Read data
                        responseData = await reader.ReadToEndAsync();
                    }
                }

                return responseData;
            }
            else
            {
                return responseData;
            }
        }
    }
}
