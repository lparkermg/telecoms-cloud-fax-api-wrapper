using System;
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
        private const string _clientId = "cxAEQXJsEILsCRiS";
        private const string _clientSecret = "uYvKjBMyQzrOdU1iJD61N39N";
        private const string _baseUrl = "https://api.telecomscloud.com/v1/";
        private static OAuth _oAuth = new OAuth(_clientId,_clientSecret,_baseUrl);

        private static bool _error = false;
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

            try
            {
                faxInbound.DownloadFax(faxCollection.Records[0].Id, "DownloadedFax.tiff");
            }
            catch (ArgumentOutOfRangeException argOutOfRange)
            {
                Console.Write("\n" + argOutOfRange + ": " + argOutOfRange.Message + "\n");
                Console.Write("An Error occured while trying to download the faxes.\n\n");
                _error = true;
            }

            if (_error)
            {
                Console.Write("[File Download Didn't Complete]\n\n");
                Console.Write("A few of the tests completed, press any key to close.");
            }
            else
            {
                Console.Write("[Complete]\n\n");
                Console.Write("All tests completed, press any key to close.");
            }



            Console.ReadLine();

        }
    }
}
