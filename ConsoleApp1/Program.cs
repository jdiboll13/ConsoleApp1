using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "http://api.openweathermap.org/data/2.5/weather?zip=33614,us&units=imperial&appid=0cf8cad19c95a8c1b81426766612471e";


            var request = WebRequest.Create(url);

            var response = request.GetResponse();

            var rawResponse = String.Empty;
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                rawResponse = reader.ReadToEnd();
            }

            var weather = JsonConvert.DeserializeObject<RootObject>(rawResponse);

            Console.WriteLine(weather.main.temp);
            Console.ReadLine();
        }
    }
}
