using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Analysis;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace WinFormsTest1
{
	public class LiveConnection
	{
        private readonly string _token;

        public LiveConnection()
        {
            //key provided by alphaVantage
            //api tuttorial citation https://www.youtube.com/watch?v=u_Bk8S8Z4j8
            _token = "NlV2c2cxU0NRRGF3M25qdEdrWUloemp6Y25jdkpmQ1l4Ym9jVEl3bklxST0";
        }

        public string retrievePrice(string symbol)
        {
            //create restful API
            var client = new RestClient("https://api.marketdata.app/v1/stocks/quotes/" + symbol +"/?token=" + _token);
            var request = new RestRequest("");

            var response = client.Get(request);
            var json = JObject.Parse(response.Content);

            return ($"{json["ask"]}");



        }
    }
}
