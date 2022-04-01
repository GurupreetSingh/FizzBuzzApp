using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CoreWebAppFizzBuzz.IntegrationTests
{
    [TestClass]
    public class BaseTestController
    {
        private readonly string _smokeTestRoot = "https://localhost/FizzBuzz"; //Once Hosted
        private readonly Lazy<HttpClient> _httpClient = new Lazy<HttpClient>(() => new HttpClient());
        private string FizzBuzzAppURI
        {
            get
            {
                return _smokeTestRoot;
            }
        }
        public BaseTestController()
        {

        }

        public BaseTestController(string smokeTestRoot) : this()
        {
            _smokeTestRoot = smokeTestRoot;
        }

        public async Task<HttpResponseMessage> GetFizzBuzzAsync(string[] fizzBuzzOperation)
        {
            var requestUrl = $"{FizzBuzzAppURI}";
            return await SendAsync(requestUrl, HttpMethod.Post, GetJsonPayload(fizzBuzzOperation));
        }


        protected HttpClient GetHttpClient()
        {
            return _httpClient.Value;
        }

        protected async Task<HttpResponseMessage> SendAsync(string apiUrl, HttpMethod httpMethod, HttpContent content,
            Dictionary<string, string> headers = null, string acceptType = "application/json")
        {
            var httpClient = GetHttpClient();
            using (var request = CreateHttpRequest(apiUrl, httpMethod, content,
            headers, acceptType))
            {
                try
                {
                    var response = await httpClient.SendAsync(request);
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new FailedRequestException($"URL: {apiUrl}; statusCode: { response.StatusCode }; Reason: {response.Content.ReadAsStringAsync().Result}", response.StatusCode);
                    }
                    return response;
                }
                catch (Exception ex)
                { throw; }
            }

        }

        protected HttpRequestMessage CreateHttpRequest(string apiUrl, HttpMethod httpMethod, HttpContent content,
            Dictionary<string, string> headers = null, string acceptType = "application/json")
        {
            var request = new HttpRequestMessage();
            request.Method = httpMethod;
            request.Content = content;
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(acceptType));
            request.RequestUri = new Uri(apiUrl);
            return request;
        }

        private StringContent GetJsonPayload(object objectToConvert)
        {
            var jsonPayload = JsonConvert.SerializeObject(objectToConvert);
            return new StringContent(jsonPayload, Encoding.UTF8, "application/json");
        }


    }

    public class FailedRequestException : Exception
    {
        public FailedRequestException(string message, HttpStatusCode statusCode) : base(message)
        {
            StatusCode = statusCode;
        }

        public HttpStatusCode StatusCode { get; set; }
    }
}
