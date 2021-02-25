using System.Runtime.Serialization;

namespace Hello_World.Models
{
    [DataContract]
    public class News
    {
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string title { get; set; }
        [DataMember]
        public string create_date { get; set; }
        [DataMember]
        public string update_date { get; set; }
        [DataMember]
        public int comments_count { get; set; }
        [DataMember]
        public string share_text { get; set; }
        [DataMember]
        public string image { get; set; }
    }
}
