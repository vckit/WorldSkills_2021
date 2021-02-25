using System.Runtime.Serialization;

namespace Hello_World.Models
{
    [DataContract]
    public class Competation
    {
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string title { get; set; }
        [DataMember]
        public string share_text { get; set; }
        [DataMember]
        public string bonus { get; set; }
        [DataMember]
        public string image { get; set; }
    }
}
