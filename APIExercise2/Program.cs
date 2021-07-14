using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace APIExercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            string response;
            do
            {
                var client = new HttpClient();

                var apiKey = "fbee9fa05f73862ff7bf76b13430cf2e";

                Console.WriteLine("Enter a city name to check weather:");

                var userCity = Console.ReadLine();

                var weatherURL = $"http://api.openweathermap.org/data/2.5/weather?q={userCity}&units=imperial&appid={apiKey}";

                var getWeather = client.GetStringAsync(weatherURL).Result;

                var weather = JObject.Parse(getWeather).GetValue("main").ToString();

                var uppercase = userCity.ToUpper();

                Console.WriteLine($"-----------------------------");
                Console.WriteLine($"{uppercase} Current Weather:");
                Console.WriteLine($"-----------------------------");
                Console.WriteLine(weather);
                Console.WriteLine($"-----------------------------");

                bool answer = false;
                do
                {
                    Console.WriteLine("Would you like to check the weather for another city? Enter yes or no.");
                    response = Console.ReadLine();
                    if (response == "yes" || response == "no")
                    {
                        answer = true;
                    }
                } while (answer == false);
                

            } while (response == "yes");
            Console.WriteLine("Come back anytime to get more weather updates!!");
        }
    }
}
