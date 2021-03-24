using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBeginHate.Model
{
    class JsonOrder
    {
        public string patient { get; set; }

        public JsonService[] services { get; set; }
    }
}
