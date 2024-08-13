using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    public class OpenWeatherMapAPI
    {
        public static void TemperatureFarmington()
        {
            
        }

        public static void GetTempFromWebsite()
        {
            //Grab appsettings file text
            var appsettingsText = File.ReadAllText("appsettings.json");
            //Get the api key from the appsettingsText using it's name/key:turn the json into an object to grab the piece.
            var apiKey = JObject.Parse(appsettingsText).GetValue("apiKey").ToString();
            //Build a API URL from where the API call comes from:
            var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?zip=87401&appid={apiKey}&units=imperial";
            //Create an instance of a class that makes the API call:
            var clientWeather = new HttpClient();
            //USe the instance of the class we created to send a GET request to the URL created above to give us a string of JSON back:
            var weatherData = clientWeather.GetStringAsync(weatherURL).Result;
            //Parse the JSON response we just got into a JObject to access certain parts of the JSON.
            var temp = JObject.Parse(weatherData)["main"]["temp"].ToString();
            Console.WriteLine($"Current temperature in Farmington, NM: {temp}");
        }
    }
}
