using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace DotNetAPITests.Client
{
    public class HttpRequestClient
    {
        private readonly HttpClient _client;
        private UriBuilder _url;
        private HttpRequestMessage _requestMessage;

        private readonly HttpClientHandler _handler = new HttpClientHandler
        {
            AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
        };

        public HttpRequestClient()
        {
            _client = new HttpClient(_handler);
            _requestMessage = new HttpRequestMessage();
            _client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public HttpRequestClient AcceptAllContentType()
        {
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));

            return this;
        }

        public HttpRequestClient WithParameter(string name, string value)
        {
            var query = HttpUtility.ParseQueryString(_url.Query);

            query.Add(name, value);

            _url.Query = query.ToString();

            return this;
        }

        public Task<HttpResponseMessage> Get()
        {
            _requestMessage.RequestUri = _url.Uri;
            _requestMessage.Method = HttpMethod.Get;

            return _client.SendAsync(_requestMessage);
        }

        public HttpRequestClient CreateRequest(string url)
        {
            var builder = new HttpRequestClient
            {
                _url = new UriBuilder(url)
            };

            return builder;
        }
    }
}
