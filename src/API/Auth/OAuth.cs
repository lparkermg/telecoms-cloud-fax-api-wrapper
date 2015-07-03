using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using API.Entities;
using API.Http;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;

namespace API.Auth
{
    /// <summary>
    /// OAuth related methods.
    /// </summary>
    public class OAuth
    {
        private string _clientId;
        private string _clientSecret;
        private string _apiUrlBase;

        private HttpCommands _httpCommands;

        private Dictionary<string, string> _headers = new Dictionary<string, string>(); 
        /// <summary>
        /// Construtor for the OAuth object make sure all the dcetails are correctly entered here.
        /// </summary>
        /// <param name="clientId">Unique Client ID issued by TelecomsCloud.</param>
        /// <param name="clientSecret">Client secret issued by TelecomsCloud.</param>
        /// <param name="baseUrl">First part of the API url. Example: "https://api.telecomscloud.com/v1/"</param>
        public OAuth(string clientId, string clientSecret, string baseUrl)
        {
            _clientId = clientId;
            _clientSecret = clientSecret;
            _apiUrlBase = baseUrl;

            _headers.Add("Content-Type", "application/json");

            _httpCommands = new HttpCommands();
        }

        /// <summary>
        /// Uses the Client ID, Client Secret and Base Url ask the server for the correct credentials.
        /// </summary>
        /// <returns>New ClientGrantResponse with all the members populated.</returns>
        public ClientGrantResponse GetAccess()
        {
            var completeUrl = _apiUrlBase + "authorization/oauth2/grant-client";
            var accessBody = "{\"client_id\":\"" + _clientId + "\",\"client_secret\":\"" + _clientSecret + "\"}";
            var postResponse = _httpCommands.HttpPost(completeUrl, accessBody);
            var deserializedJson = JsonConvert.DeserializeObject<dynamic>(postResponse);

            var tempAccessToken = "";
            var tempExpiresIn = 0;
            var tempTokenType = "";
            var tempScope = "";

            try
            {
                tempAccessToken = deserializedJson.access_token.ToString();
                tempExpiresIn = (int) deserializedJson.expires_in;
                tempTokenType = deserializedJson.token_type.ToString();
                tempScope = deserializedJson.scope.ToString();
            }
            catch (RuntimeBinderException rbe)
            {
                Console.WriteLine("\n\nThere has been an issue decoding the json response from the server.");
                Console.WriteLine("Returned Json: " + postResponse);
                throw;
            }

            return new ClientGrantResponse(tempAccessToken,tempExpiresIn,tempTokenType,tempScope);
        }
    }
}
