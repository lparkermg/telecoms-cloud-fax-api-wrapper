using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.WebSockets;

namespace API.Http
{
    /// <summary>
    /// A Small Collection of basic Http Commands.
    /// </summary>
    public class HttpCommands
    {
        /// <summary>
        /// Make a Http Request using the POST method.
        /// </summary>
        /// <param name="uri">The URL of where to POST to.</param>
        /// <param name="body">What is going to be posted.</param>
        /// <param name="headers">Headers required for posting.</param>
        /// <returns></returns>
        public string HttpPost(string uri, string body, Dictionary<string, string> headers)
        {
            using (HttpClient client = new HttpClient())
            {
                var req = new HttpRequestMessage() {RequestUri = new Uri(uri), Method=HttpMethod.Post,Content = new StringContent(body)};

                foreach(var header in headers)
                    req.Headers.Add(header.Key,header.Value);

                var resp = client.SendAsync(req).Result;

                return resp.Content.ToString();
            }
        }

        /// <summary>
        /// Make a Http Request using the GET method.
        /// </summary>
        /// <param name="uri">The URL of where to GET from.</param>
        /// <param name="body">What to put in the GET. (If needed.)</param>
        /// <param name="headers">Headers required for getting.</param>
        /// <returns></returns>
        public string HttpGet(string uri, string body, Dictionary<string, string> headers)
        {
            using (HttpClient client = new HttpClient())
            {
                var req = new HttpRequestMessage() { RequestUri = new Uri(uri), Method = HttpMethod.Get, Content = new StringContent(body)};

                foreach(var header in headers)
                    req.Headers.Add(header.Key,header.Value);

                var resp = client.SendAsync(req).Result;

                return resp.Content.ToString();
            }
        }

        /// <summary>
        /// Download a file from the stated URL and save it to the destinationPath.
        /// </summary>
        /// <param name="uri">The URL where the redirect is.</param>
        /// <param name="destinationPath">Where we are going to put the file. Example: "C:/Filename.ext"</param>
        /// <param name="headers">Headers required for requesting the file.</param>
        public void DownloadViaRedirect(string uri, string destinationPath, Dictionary<string, string> headers)
        {
            using (HttpClient client = new HttpClient())
            {
                var req = new HttpRequestMessage() {RequestUri = new Uri(uri), Method=HttpMethod.Get};

                foreach(var header in headers)
                    req.Headers.Add(header.Key,header.Value);

                var resp = client.SendAsync(req).Result;

                var redirect = req.RequestUri;

                using (var fileData = client.GetStreamAsync(redirect).Result)
                {
                    using (var fs = new FileStream(destinationPath, FileMode.Create))
                    {
                        fileData.CopyTo(fs);
                        fs.Flush();
                    }
                }
            }
        }
    }
}
