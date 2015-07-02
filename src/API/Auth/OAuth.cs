using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Auth
{
    public class OAuth
    {
        private string _clientId;
        private string _clientSecret;

        public OAuth(string clientId, string clientSecret)
        {
            _clientId = clientId;
            _clientSecret = clientSecret;
        }

        public string GetAccess()
        {
            return "";
        }

    }
}
