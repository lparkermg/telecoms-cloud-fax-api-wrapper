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
    public class HttpCommands
    {
        public string HttpPost(string uri, string body, Dictionary<string, string> headers)
        {
            using (HttpClient client = new HttpClient())
            {
                
                var req = new HttpRequestMessage() {RequestUri = new Uri(uri), Method=HttpMethod.Post, Content=new StringContent(body) };

                foreach(var header in headers)
                    req.Headers.Add(header.Key,header.Value);


                var resp = client.SendAsync(req).Result;

                return resp.Content.ToString();
            }
        }

        public string HttpGet(string uri, string body, Dictionary<string, string> headers)
        {
            using (HttpClient client = new HttpClient())
            {
                var req = new HttpRequestMessage() { RequestUri = new Uri(uri), Method = HttpMethod.Get};

                foreach(var header in headers)
                    req.Headers.Add(header.Key,header.Value);

                var resp = client.SendAsync(req).Result;

                return resp.Content.ToString();
            }
        }

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
