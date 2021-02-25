using System.Runtime.Serialization;

namespace Hello_World.Models
{
    [DataContract]
    class Posts
    {
        [DataMember]
        public string title { get; set; }
        [DataMember]
        public string body { get; set; }
    }
}
