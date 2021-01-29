using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldSkills.Models.Response;

namespace WorldSkills.Models
{
	public class Fines
	{
		[JsonProperty("data")]
		public List<Data> Datas { get; set; }

		[JsonProperty("success")]
		public string Success { get; set; }
		
	}
}
