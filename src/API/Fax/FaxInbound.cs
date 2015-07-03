using System;
using System.Collections.Generic;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using TcFaxApi.Entities;
using TcFaxApi.Entities.Fax;
using TcFaxApi.Http;

namespace TcFaxApi.Fax
{
    /// <summary>
    /// Fax related methods.
    /// </summary>
    public class FaxInbound
    {
        private ClientGrantResponse _clientGrant;
        private string _baseApiUrl;
        private Dictionary<string,string> _headers = new Dictionary<string, string>();

        private HttpCommands _httpCommands;

        /// <summary>
        /// Constructor for the FaxInbound Object make sure all the details are correctly entered here.
        /// </summary>
        /// <param name="clientGrant">Response from Gaining Access.</param>
        /// <param name="baseApiUrl">First part of the API url. Example: "https://api.telecomscloud.com/v1/"</param>
        public FaxInbound(ClientGrantResponse clientGrant, string baseApiUrl)
        {
            _clientGrant = clientGrant;
            _baseApiUrl = baseApiUrl;
            _httpCommands = new HttpCommands();
        }

        /// <summary>
        /// Gets the collection of faxes from the using the lastPointer as the start.
        /// </summary>
        /// <param name="lastPointer">The what fax you want to start on.</param>
        /// <returns>New FaxInfoCollectionResponse with any faxes in it/ [Nullable]</returns>
        public FaxInfoCollectionResponse GetFaxCollection(int lastPointer)
        {
            var faxInfoCollection = new List<FaxInfo>();
            var completeUrl = _baseApiUrl + "fax/inbound/info?last_pointer=" + lastPointer;
            SetHeaders();
            var response = _httpCommands.HttpGet(completeUrl, _headers);

            var deserializedJson = JsonConvert.DeserializeObject<dynamic>(response);

            var records = JsonConvert.DeserializeObject<List<dynamic>>(deserializedJson.records.ToString());

            foreach (var record in records)
            {
                try
                {
                    var tempId = record.id.ToString();
                    var tempFromNumber = record.from_number.ToString();
                    var tempServiceNumber = record.service_number.ToString();
                    var tempPageCount = (int) record.page_count;
                    var tempReceivedDate = record.received_date.ToString();
                    var tempTiffBytes = (int) record.tiff_bytes;
                    var tempPointer = (int) record.pointer;

                    faxInfoCollection.Add(new FaxInfo(tempId, tempFromNumber, tempServiceNumber, tempPageCount,
                        tempReceivedDate, tempTiffBytes, tempPointer));
                }
                catch (RuntimeBinderException rbe)
                {
                    Console.WriteLine("The was an issue adding the record. Moving onto the next one...");
                }
            }

            return new FaxInfoCollectionResponse(faxInfoCollection);
        }

        /// <summary>
        /// Downloads a selected fax to a specific destination based on the faxId.
        /// </summary>
        /// <param name="faxId">The ID of the fax you wish to download.</param>
        /// <param name="destinationPath">Where to store the fax</param>
        public void DownloadFax(string faxId, string destinationPath)
        {
            var completeUrl = _baseApiUrl + "fax/inbound/" + faxId;
            SetHeaders();
            _httpCommands.DownloadViaRedirect(completeUrl,destinationPath,_headers);
        }

        private void SetHeaders()
        {
            _headers = new Dictionary<string, string>
            {
                {"Authorization", _clientGrant.TokenType + " " + _clientGrant.AccessToken}
            };
        }
    }
}
