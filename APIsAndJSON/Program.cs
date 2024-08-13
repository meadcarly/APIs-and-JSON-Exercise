using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    public class Program
    {
        static void Main(string[] args)
        {
            RonVSKanyeAPI.Convo();
            
            //_______________________________________________________________________________________________
            
            OpenWeatherMapAPI.GetTempFromWebsite();
        }
    }
}
