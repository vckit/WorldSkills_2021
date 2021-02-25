using System.Runtime.Serialization;

namespace Hello_World.Models
{
    [DataContract]
    public class Comments
    {
        [DataMember]
        public string text { get; set; }
        [DataMember]
        public string create_date { get; set; }
        [DataMember]
        public User user { get; set; }
    }
}
