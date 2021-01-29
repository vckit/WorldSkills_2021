using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace dbAPI.Models
{
    [DataContract]
    public class Car
    {
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string car_num { get; set; }
        [DataMember]
        public string create_date { get; set; }
        [DataMember]
        public string licence_num { get; set; }
        [DataMember]
        public string photo { get; set; }
    }
}
