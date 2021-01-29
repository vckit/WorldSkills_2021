using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace dbAPI.Models
{
    [DataContract]
    public class ServerResponse<T>
    {
        [DataMember]
        public List<T> data { get; set; }
        [DataMember]
        public Boolean success { get; set; }
    }
}
