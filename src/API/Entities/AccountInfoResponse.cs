using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Entities
{
    public class AccountInfoResponse
    {
        public string Username { get { return _username; } }
        private string _username;

        public string Status { get { return _status; } }
        private string _status;

        public int AccountServices { get { return _accountServices; } }
        private int _accountServices;

        public float CreditBalance { get { return _creditBalance; } }
        private float _creditBalance;

        public string PrimaryEmail { get { return _primaryEmail; } }
        private string _primaryEmail;

        public AccountInfoResponse(string username, string status, int accountServices, float creditBalance, string primaryEmail)
        {
            _username = username;
            _status = status;
            _accountServices = accountServices;
            _creditBalance = creditBalance;
            _primaryEmail = primaryEmail;
        }
    }
}
