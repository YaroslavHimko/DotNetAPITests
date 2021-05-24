using DotNetAPITests.Client;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace DotNetAPITests.Services
{
    public class MockService
    {
        private readonly string _baseUrl = "https://httpstat.us/";
        private readonly HttpRequestClient _requestClient;

        public MockService()
        {
            _requestClient = new HttpRequestClient();
        }

        public Task<HttpResponseMessage> GetCode(HttpStatusCode requestedCode)
        {
            var url = _baseUrl + (int)requestedCode;
            return _requestClient.CreateRequest(url).Get();
        }
    }
}
