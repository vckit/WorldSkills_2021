using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldSkills.Models.Response
{
	public class Data
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("car_num")]
		public string CarNum { get; set; }

		[JsonProperty("region")]
		public string Region { get; set; }

		[JsonProperty("licence_num")]
		public string LicenceNum { get; set; }

		[JsonProperty("create_date")]
		public DateTime CreateDate { get; set; }

		[JsonProperty("photo")]
		public string Photo { get; set; }
	}
}
