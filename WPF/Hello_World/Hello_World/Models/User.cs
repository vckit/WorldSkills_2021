using System.Runtime.Serialization;

namespace Hello_World.Models
{
    [DataContract]
    public class User
    {
        [DataMember]
        public string login { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string image { get; set; }
    }
}
