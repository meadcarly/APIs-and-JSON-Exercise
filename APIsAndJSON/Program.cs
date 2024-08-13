using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Create an instance of a class that makes the API call:
            var client = new HttpClient();
            
            //Build a API URL from where the API call comes from:
            var kanyaURL = $"https://api.kanye.rest";
            
            //_____________________________________________________________________________________________
            
            //Create an instance of a class that makes the API call:
            var clientRonSwanon = new HttpClient();
            
            //Build a API URL from where the API call comes from:
            var ronURL = $"https://ron-swanson-quotes.herokuapp.com/v2/quotes";
            
            //______________________________________________________________________________________________

            for (int i = 0; i <= 4; i++)
            {
                //USe the instance of the class we created to send a GET request to the URL created above to give us a string of JSON back:
                var ronResponse = clientRonSwanon.GetStringAsync(ronURL).Result;
                var kanyaResponse = client.GetStringAsync(kanyaURL).Result;
                
                //Parse the JSON response we just got into a JObject to access certain parts of the JSON.
                var ronQuote = JArray.Parse(ronResponse);
                var kanyaQuote = JObject.Parse(kanyaResponse)["quote"].ToString();
                
                Console.WriteLine($"Ron: {ronQuote[0]}");
                Console.WriteLine($"Kanya: {kanyaQuote}");
                Console.WriteLine();
            }
            Console.WriteLine();
            //_______________________________________________________________________________________________
            
            //Create an instance of a class that makes the API call:
            var clientWeather = new HttpClient();

            //Build a API URL from where the API call comes from:
            //Grab appsettings file and the text it contains
            var appsettingsText = File.ReadAllText("appsettings.json");
            //Get the api key from the appsettingsText using it's name/key
            var apiKey = JObject.Parse(appsettingsText)["apiKey"].ToString();
            var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?zip=87401&appid={apiKey}&units=imperial";
            
            //USe the instance of the class we created to send a GET request to the URL created above to give us a string of JSON back:
            var weatherData = clientWeather.GetStringAsync(weatherURL).Result;
            
            //Parse the JSON response we just got into a JObject to access certain parts of the JSON.
            var temp = JObject.Parse(weatherData)["main"]["temp"].ToString();

            Console.WriteLine($"Current temperature in Farmington, NM: {temp}");
        }
    }
}
