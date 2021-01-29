using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldSkills.Models.Request
{
	public class postFine
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("message")]
		public string Message{ get; set; }
	}
}
