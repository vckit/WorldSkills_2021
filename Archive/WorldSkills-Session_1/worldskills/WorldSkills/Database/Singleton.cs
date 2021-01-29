using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldSkills.Database
{
	public class Singleton
	{
		public static Database Context = new Database();
	}
}
