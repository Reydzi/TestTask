using System.Runtime.Serialization;

namespace TestTask3
{
    [DataContract(Name = "main")]
    public class MainInfo
    {
        [DataMember(Name = "humidity")]
        public int Humidity { get; set; }

        [DataMember(Name = "temp")]
        public double Temperature { get; set; }
    }
}
