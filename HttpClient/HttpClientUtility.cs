using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace CSharpOsu.HttpClient
{
    /// <summary>
    /// Helper class of HttpClient.
    /// To increase the efficiency, please consider to initialize this class infrequently.
    /// </summary>
    public class HttpClientUtility
    {
        public static readonly string CacheImagePath =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "imageCache");

        public TimeSpan Timeout { get; set; }

        public int RetryCount { get; set; }

        private readonly System.Net.Http.HttpClient _httpClient;

        public HttpClientUtility() : this(TimeSpan.FromSeconds(8), 3)
        {
        }

        public HttpClientUtility(TimeSpan timeout) : this(timeout, 3)
        {
        }

        public HttpClientUtility(TimeSpan timeout, int retryCount)
        {
            Timeout = timeout;
            RetryCount = retryCount;
            var handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip
            };
            ServicePointManager.ServerCertificateValidationCallback = CheckValidationResult;
            _httpClient = new System.Net.Http.HttpClient(handler)
            {
                Timeout = Timeout
            };
        }

        /// <summary>
        /// Post with nothing.
        /// </summary>
        /// <param name="url">Http uri.</param>
        /// <returns></returns>
        public string HttpPost(string url)
        {
            HttpContent content = new StringContent("");
            content.Headers.ContentType = new MediaTypeHeaderValue(HttpContentType.Form.GetContentType());
            return HttpPost(url, content);
        }

        /// <summary>
        /// Post with Json.
        /// </summary>
        /// <param name="url">Http uri.</param>
        /// <param name="postJson">json string.</param>
        /// <returns></returns>
        public string HttpPost(string url, string postJson)
        {
            HttpContent content = new StringContent(postJson);
            content.Headers.ContentType = new MediaTypeHeaderValue(HttpContentType.Json.GetContentType());
            return HttpPost(url, content);
        }

        /// <summary>
        /// Post with Json.
        /// </summary>
        /// <param name="url">Http uri.</param>
        /// <param name="args">Parameter dictionary.</param>
        /// <param name="argsHeader">Header dictionary.</param>
        /// <returns></returns>
        public string HttpPost(string url,
            IDictionary<string, string> args,
            IDictionary<string, string> argsHeader = null)
        {
            HttpContent content;
            if (args != null)
            {
                var jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(args);
                content = new StringContent(jsonStr);
                content.Headers.ContentType = new MediaTypeHeaderValue(HttpContentType.Json.GetContentType());
            }
            else
            {
                content = new StringContent("");
                content.Headers.ContentType = new MediaTypeHeaderValue(HttpContentType.Form.GetContentType());
            }

            if (argsHeader != null)
            {
                foreach (var item in argsHeader)
                    content.Headers.Add(item.Key, item.Value);
            }

            return HttpPost(url, content);
        }

        /// <summary>
        /// Get with value-pairs.
        /// </summary>
        /// <param name="url">Http uri.</param>
        /// <param name="args">Parameter dictionary.</param>
        /// <param name="argsHeader">Header dictionary.</param>
        /// <returns></returns>
        public string HttpGet(string url, IDictionary<string, string> args = null, IDictionary<string, string> argsHeader = null)
        {
            for (int i = 0; i < RetryCount; i++)
            {
                try
                {
                    if (args != null)
                    {
                        url = url + args.ToUrlParamString();
                    }

                    var message = new HttpRequestMessage(HttpMethod.Get, url);
                    if (argsHeader != null)
                    {
                        foreach (var item in argsHeader)
                        {
                            message.Headers.Add(item.Key, item.Value);
                        }
                    }
                    CancellationTokenSource cts = new CancellationTokenSource(Timeout);
                    HttpResponseMessage response = _httpClient.SendAsync(message, cts.Token).Result;

                    return response.Content.ReadAsStringAsync().Result;
                }
                catch (Exception)
                {
                    Debug.WriteLine($"Tried {i + 1} time{(i + 1 > 1 ? "s" : "")} for timed out. (>{Timeout}ms): " + url);
                    if (i == RetryCount - 1)
                        throw;
                }
            }

            return null;
        }

        private string HttpPost(string url, HttpContent content)
        {
            string responseStr = null;
            for (int i = 0; i < RetryCount; i++)
            {
                try
                {
                    var response = _httpClient.PostAsync(url, content).Result;
                    // ensure if the request is success.
                    response.EnsureSuccessStatusCode();
                    // read the Json asynchronously.

                    // notice currently was auto decompressed with GZip,
                    // because AutomaticDecompression was set to DecompressionMethods.GZip
                    responseStr = response.Content.ReadAsStringAsync().Result;
                    return responseStr;
                }
                catch (Exception)
                {
                    Debug.WriteLine($"Tried {i + 1} time{(i + 1 > 1 ? "s" : "")} for timed out. (>{Timeout}ms): " + url);
                    if (i == RetryCount - 1)
                        throw;
                }
            }

            return responseStr;
        }

        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true; // always accept.  
        }
    }
}
