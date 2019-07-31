using System;
using System.Runtime.Serialization;


namespace TestTask3
{
    [DataContract]
    public class WeatherInfo
    {
        [DataMember(Name = "sys")]
        public Sys Sys { get; set; }

        [DataMember(Name = "main")]
        public MainInfo Main { get; set; }

        public override string ToString()
        {
            int tempCelsius = Convert.ToInt32((Main.Temperature - 273));
            var Sunrise = (new DateTime(1970, 1, 1, 3, 0, 0, 0)).AddSeconds(Sys.Sunrise);
            var Sunset = (new DateTime(1970, 1, 1, 3, 0, 0, 0)).AddSeconds(Sys.Sunset);
            return $"Температура: {tempCelsius} градусов \nВлажность: {Main.Humidity}% \nВосход: {Sunrise} (мск) \nЗакат: {Sunset} (мск)";
        }
    }
}
