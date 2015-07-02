using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Entities;
using API.Entities.Fax;
using API.Http;

namespace API
{
    public class FaxInbound
    {
        private ClientGrantResponse _clientGrant;
        private string _baseApiUrl;
        private Dictionary<string,string> _headers = new Dictionary<string, string>();

        private HttpCommands _httpCommands;

        public FaxInbound(ClientGrantResponse clientGrant, string baseApiUrl)
        {
            _clientGrant = clientGrant;
            _baseApiUrl = baseApiUrl;
            _httpCommands = new HttpCommands();
        }

        public FaxInfoCollectionResponse GetFaxCollection(int lastPointer)
        {
            var completeUrl = _baseApiUrl + "fax/inbound/info";
            SetHeaders();
            //var response = _httpCommands.HttpGet(completeUrl,)
        }

        private void SetHeaders()
        {
            _headers.Add("Content-Type","application/json");
            _headers.Add("Authorization", _clientGrant.TokenType + " " + _clientGrant.AccessToken);
        }
    }
}
