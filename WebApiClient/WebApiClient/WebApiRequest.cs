using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WebApiClient
{
    public class WebApiRequest<T> where T : class
    {
        private readonly string _url;

        public WebApiRequest(string url)
        {
            _url = url;
        }

        public async Task<T> GetDataAsync()
        {
            T result;

            var request = WebRequest.Create(_url);

            using (var response = await request.GetResponseAsync())
            {
                using (var dataStream = response.GetResponseStream())
                {
                    if (dataStream == null)
                    {
                        return null;
                    }

                    using (var reader = new StreamReader(dataStream))
                    {
                        string responseFromServer = reader.ReadToEnd();
                        result = JsonConvert.DeserializeObject<T>(responseFromServer);
                        reader.Close();
                    }
                    response.Close();
                }
            }

            return result;
        }
    }
}