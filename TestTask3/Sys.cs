using System.Runtime.Serialization;

namespace TestTask3
{
    [DataContract(Name = "sys")]
    public class Sys
    {
        [DataMember(Name = "sunset")]
        public int Sunset { get; set; }
        [DataMember(Name = "sunrise")]
        public int Sunrise { get; set; }
    }
}
