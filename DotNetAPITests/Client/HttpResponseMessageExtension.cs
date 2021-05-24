using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace DotNetAPITests.Client
{
    public static class HttpResponseMessageExtension
    {
        public static T WithResponseModel<T>(this Task<HttpResponseMessage> responseTask)
        {
            var response = responseTask;
            var httpContent = response.Result.Content;

            var content = httpContent.ReadAsStringAsync().Result;

            var result = JsonConvert.DeserializeObject<T>(content);

            return result;
        }
    }
}
