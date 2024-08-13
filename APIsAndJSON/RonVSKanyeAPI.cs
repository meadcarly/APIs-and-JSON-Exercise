using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    public class RonVSKanyeAPI
    {
        public static void Convo()
        {
            //Create an instance of a class that makes the API call:
            var client = new HttpClient();
            for (int i = 0; i <= 4; i++)
            {
                Console.WriteLine($"Kanya: {GetKanyaQuote(client)}");
                Thread.Sleep(1000);
                Console.WriteLine($"Ron: {GetRonQuote(client)}");
                Thread.Sleep(1000);
                Console.WriteLine();
            }
        }
        //Build a API URL from where the API call comes from:
        //USe the instance of the class we created to send a GET request to the URL created above to give us a string of JSON back:
        //Parse the JSON response we just got into a JObject to access certain parts of the JSON.
        private static string GetKanyaQuote(HttpClient client)
        {
            var kanyaResponse = client.GetStringAsync("https://api.kanye.rest/").Result;
            return JObject.Parse(kanyaResponse)["quote"].ToString();
        }

        private static string GetRonQuote(HttpClient client)
        {
            var ronResponse = client.GetStringAsync("https://ron-swanson-quotes.herokuapp.com/v2/quotes").Result;
            return ronResponse.Replace('[', ' ').Replace(']', ' ').Replace('"', ' ').Trim();
        }

    }
}
