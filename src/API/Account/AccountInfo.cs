using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Entities;

namespace API.Account
{
    public class AccountInfo
    {
        private ClientGrantResponse _clientGrant;
        private string _baseApiUrl;

        public AccountInfo(ClientGrantResponse clientGrant, string baseUrl)
        {
            _clientGrant = clientGrant;
            _baseApiUrl = baseUrl;
        }

        public AccountInfoResponse GetAccountInfo()
        {
            var completeUrl = _baseApiUrl + "/account/info";

            return new AccountInfoResponse("","",0,0.0f,"");
        }


    }
}
