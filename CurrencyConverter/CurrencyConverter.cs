using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Collections.Generic;
namespace CurrencyConverter
{
    public class CurrencyConverter
    {
        public int Amount { get; set; }
        public string FromCurrency { get; set; }
        public string ToCurrency { get; set; }

        static HttpClient client = new HttpClient();
        static String API_KEY = "10f744df7fbaf847bdb1c991ac5896ef";

        public double Convert()
        {
            // string url = "localhost" + API_KEY + "&from="+FromCurrency+"&to="+ToCurrency+"&amount="+Amount;
            string url = "http://data.fixer.io/api/latest?access_key="+API_KEY+"&base="+FromCurrency+"&symbols="+ToCurrency;
            client.BaseAddress = new Uri("http://data.fixer.io");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            Root latestRates = new Root();

            HttpResponseMessage response = client.GetAsync(url).Result;
            Console.WriteLine(response);
            if (response.IsSuccessStatusCode)
            {
                string latest = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(latest);
                
                latestRates = JsonConvert.DeserializeObject<Root>(latest);
                double rate = latestRates.rates.Values.Count > 0 ? latestRates.rates[ToCurrency] : 0;
                return Math.Round(Amount * rate,3);
            }

            return 0;
        }
    }

    //public double ConvertToSEK()
    //{

    //}


    public class Query
    {
        public string from { get; set; }
        public string to { get; set; }
        public int amount { get; set; }
    }

    public class Info
    {
        public int timestamp { get; set; }
        public double rate { get; set; }
    }

    public class Root
    { 
        public bool success { get; set; }
        public string date { get; set; }
    public Dictionary<string, double> rates { get; set; }
    public double timestamp { get; set; }
      
    }

}