using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Entities;
using API.Http;
using Newtonsoft.Json;

namespace API.Account
{
    /// <summary>
    /// Account related methods.
    /// </summary>
    public class AccountInfo
    {
        private ClientGrantResponse _clientGrant;
        private string _baseApiUrl;
        private Dictionary<string, string> _headers = new Dictionary<string, string>();

        private HttpCommands _httpCommands;

        /// <summary>
        /// Constructor for the AccountInfo Object make sure all the details are correctly entered here.
        /// </summary>
        /// <param name="clientGrant">Response from Gaining Access.</param>
        /// <param name="baseUrl">First part of the API url. Example: "https://api.telecomscloud.com/v1/"</param>
        public AccountInfo(ClientGrantResponse clientGrant, string baseUrl)
        {
            _clientGrant = clientGrant;
            _baseApiUrl = baseUrl;
            _httpCommands = new HttpCommands();
        }

        /// <summary>
        /// Uases the Access Token and Token Type in the ClientGrantResponse to get all the account info.
        /// </summary>
        /// <returns>New AccountInfoResponse with all the members populated.</returns>
        public AccountInfoResponse GetAccountInfo()
        {
            var completeUrl = _baseApiUrl + "account/info";
            SetHeaders();
            var response = _httpCommands.HttpGet(completeUrl, _headers);

            var deserializedJson = JsonConvert.DeserializeObject<dynamic>(response);

            var tempUsername = deserializedJson.username.ToString();
            var tempStatus = deserializedJson.status.ToString();
            var tempActiveServices = (int)deserializedJson.active_services;
            var tempCreditBalance = (float)deserializedJson.credit_balance;
            var tempPrimaryEmaail = deserializedJson.primary_email.ToString();

            return new AccountInfoResponse(tempUsername,tempStatus,tempActiveServices,tempCreditBalance,tempPrimaryEmaail);
        }

        private void SetHeaders()
        {
            _headers.Add("Authorization", _clientGrant.TokenType + " " + _clientGrant.AccessToken);
        }


    }
}
