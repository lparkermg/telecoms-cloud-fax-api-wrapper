﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TcFaxApi.Auth;
using TcFaxApi.Fax;

namespace Fax_Wrapper_Test
{
    class Program
    {
        private const string _clientId = "tm7shk8t8o1TgfbJ";
        private const string _clientSecret = "qdmDnjkRDhT6AWh50W2z666X";
        private const string _baseUrl = "https://api.telecomscloud.com/v1/";
        private static OAuth _oAuth = new OAuth(_clientId,_clientSecret,_baseUrl);
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Fax Test:\n\n");

            Console.Write("Asking for Access to API: ");

            var clientResp = _oAuth.GetAccess();

            Console.Write("[Completed]\n\n");

            Console.Write("Getting Test Fax Collection: ");

            var faxInbound = new FaxInbound(clientResp,_baseUrl);

            var faxCollection = faxInbound.GetFaxCollection(0);

            Console.Write("[Complete]\n\n");

            Console.Write("Downloading Single Fax to Application Location: ");

            faxInbound.DownloadFax(faxCollection.Records[0].Id,"DownloadedFax.tiff");

            Console.Write("[Complete]\n\n");

            Console.Write("All tests completed, press any key to close.");

            Console.ReadLine();

        }
    }
}
