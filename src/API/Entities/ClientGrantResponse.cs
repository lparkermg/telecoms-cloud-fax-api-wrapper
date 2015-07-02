using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Entities
{
    public class ClientGrantResponse
    {
        public string AccessToken { get; private set; }
        private string _accessToken;

        public int ExpiresIn { get; private set; }
        private int _expiresIn;

        public string TokenType { get; private set; }
        private string _tokenType;

        public string Scope { get; private set; }
        private string _scope;

    }
}
