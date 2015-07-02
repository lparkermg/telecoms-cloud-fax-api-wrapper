using System;
using System.Collections.Generic;
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
                var req = new HttpRequestMessage() {RequestUri = new Uri(uri), Method=HttpMethod.Post, Content=body};

                foreach(var header in headers)
                    req.Headers.Add(header.Key,header.Value);


                var resp = client.SendAsync(req).Result;

                return resp.Content.ToString();
            }
        }


    }
}
