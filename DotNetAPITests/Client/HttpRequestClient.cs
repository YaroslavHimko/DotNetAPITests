using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DotNetAPITests.Client
{
    public class HttpRequestClient
    {
        private readonly HttpClient _client;
        private readonly HttpRequestMessage _requestMessage;
        private readonly HttpClientHandler _handler = new HttpClientHandler();
        private UriBuilder _url;

        public HttpRequestClient()
        {
            _client = new HttpClient(_handler);
            _requestMessage = new HttpRequestMessage();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public Task<HttpResponseMessage> Get()
        {
            _requestMessage.RequestUri = _url.Uri;
            _requestMessage.Method = HttpMethod.Get;

            return _client.SendAsync(_requestMessage);
        }

        public HttpRequestClient CreateRequest(string url)
        {
            var requestClient = new HttpRequestClient
            {
                _url = new UriBuilder(url)
            };

            return requestClient;
        }
    }
}
