using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Entities;

namespace API.Account
{
    public class AccountInfo
    {
        private ClientGrantResponse _clientGrant;

        public AccountInfo(ClientGrantResponse clientGrant)
        {
            _clientGrant = clientGrant;
        }


    }
}
