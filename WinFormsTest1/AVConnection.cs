using System;
using System.IO;
using System.Net;
using Microsoft.Data.Analysis;


namespace WinFormsTest1
{
    public class AVConnection
    {
        private readonly string _apiKey;

        public AVConnection()
        {
            //key provided by alphaVantage
            //api tuttorial citation https://youtu.be/ULGMStkOf7Y?si=9YZI7QkJyt22wPAH
            _apiKey = "BVGL7ANAUC727H02";
        }

        public string SAveCSVFromURL(string symbol)
        {
            //conect to alphavantage through web
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://" + $@"www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol=" +symbol+"&apikey="+this._apiKey+"&datatype=csv");
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string results = sr.ReadToEnd();
            //sr.close();

            return results;

        }
    }






}