using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;

namespace TestTask3
{
    public class Program
    {
        private const string baseUrl = "http://api.openweathermap.org";
        private const string APIkey = "29da13938bd504acfbd41c87c0de9983";

        static void Main(string[] args)
        {
            Console.WriteLine("Введите название города: ");
            var city = Console.ReadLine();
            Console.WriteLine("Информация о погоде в городе {0}", city);


            var request = WebRequest.Create($"{baseUrl}/data/2.5/weather?q={city}&appid={APIkey}");
            using (var response = request.GetResponse() as HttpWebResponse)
            {
                using (var webStream = response.GetResponseStream())
                {
                    var reader = new StreamReader(webStream);
                    var jsonResult = reader.ReadToEnd();

                    var stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonResult)) { Position = 0 };
                    var ser = new DataContractJsonSerializer(typeof(WeatherInfo));
                    var info = (WeatherInfo)ser.ReadObject(stream);

                    Console.WriteLine(info.ToString());

                    var currentTime = DateTime.Now;
                    
                    System.IO.File.WriteAllText($@"D:\{currentTime.ToShortDateString()}.txt", info.ToString());
                }
            }
           
            Console.ReadKey();
        }
    }
}
