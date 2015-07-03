using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;

namespace TcFaxApi.Http
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
        /// <returns>JSON</returns>
        public string HttpPost(string uri, string body)
        {
            using (HttpClient client = new HttpClient())
            {
                var req = new HttpRequestMessage() {RequestUri = new Uri(uri), Method=HttpMethod.Post,Content = new StringContent(body,Encoding.UTF8,"application/json")};

                HttpResponseMessage resp;
                try
                {
                    resp = client.SendAsync(req).Result;
                }
                catch (AggregateException ae)
                {
                    Console.WriteLine("\nAn Error Occured while trying to make a HttpPost Request.");
                    Console.WriteLine(ae.InnerExceptions[0] + ": " + ae.InnerExceptions[0].Message + "\n");
                    throw;
                }

                return resp.Content.ReadAsStringAsync().Result;
            }
        }

        /// <summary>
        /// Make a Http Request using the GET method.
        /// </summary>
        /// <param name="uri">The URL of where to GET from.</param>
        /// <param name="headers">Headers required for getting.</param>
        /// <returns>JSON</returns>
        public string HttpGet(string uri, Dictionary<string, string> headers)
        {
            using (HttpClient client = new HttpClient())
            {
                var req = new HttpRequestMessage() { RequestUri = new Uri(uri), Method = HttpMethod.Get};

                foreach(var header in headers)
                    req.Headers.Add(header.Key,header.Value);

                HttpResponseMessage resp;
                try
                {
                    resp = client.SendAsync(req).Result;
                }
                catch (AggregateException ae)
                {
                    Console.WriteLine("\nAn Error Occured while trying to make a HttpGet Request.");
                    Console.WriteLine(ae.InnerExceptions[0] + ": " + ae.InnerExceptions[0].Message + "\n");
                    throw;
                }

                return resp.Content.ReadAsStringAsync().Result;
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

                HttpResponseMessage resp;
                try
                {
                    resp = client.SendAsync(req).Result;
                }
                catch (AggregateException ae)
                {
                    Console.WriteLine("\nAn Error Occured while trying to Download via Redirect.");
                    Console.WriteLine(ae.InnerExceptions[0] + ": " + ae.InnerExceptions[0].Message + "\n");
                    throw;
                }

                var redirect = req.RequestUri;
                try
                {
                    using (var fileData = client.GetStreamAsync(redirect).Result)
                    {
                        using (var fs = new FileStream(destinationPath, FileMode.Create))
                        {
                            fileData.CopyTo(fs);
                            fs.Flush();
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("There was an issue when writing the file to disk.\n");
                    Console.WriteLine(e + ": " + e.Message);
                    throw;
                }
            }
        }
    }
}
