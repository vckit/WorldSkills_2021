using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace VIN_LIB
{
	public class VinLib
	{
		

		public static string GetVINCountry(string Vin)
		{
			if (Vin.Length != 17)
			{
				return "";
			}

			string WMI = Vin.Substring(0, 3);
			string VDS = Vin.Substring(3, 6);
			string VIS = Vin.Substring(9);



			return "";
		}

		public static int GetVINYear(string Vin)
		{
			string WMI = Vin.Substring(0, 3);
			string VDS = Vin.Substring(3, 6);
			string VIS = Vin.Substring(9);

		

			string VisYear = VIS.Substring(0, 1);

			if (VisYear == "A")
			{
				return 1980;
			}
			if (VisYear == "B")
			{
				return 1981;
			}
			if (VisYear == "C")
			{
				return 1982;
			}
			if (VisYear == "D")
			{
				return 1983;
			}
			if (VisYear == "E")
			{
				return 1984;
			}
			if (VisYear == "F")
			{
				return 1985;
			}
			if (VisYear == "G")
			{
				return 1986;
			}
			if (VisYear == "H")
			{
				return 1987;
			}
			if (VisYear == "J")
			{
				return 1988;
			}
			if (VisYear == "L")
			{
				return 1990;
			}
			if (VisYear == "M")
			{
				return 1991;
			}
			if (VisYear == "N")
			{
				return 1992;
			}
			if (VisYear == "P")
			{
				return 1993;
			}
			if (VisYear == "R")
			{
				return 1994;
			}
			if (VisYear == "S")
			{
				return 1995;
			}
			if (VisYear == "T")
			{
				return 1996;
			}
			if (VisYear == "V")
			{
				return 1997;
			}
			if (VisYear == "Y")
			{
				return 2000;
			}
			if (VisYear == "K")
			{
				return 1989;
			}
			if (VisYear == "X")
			{
				return 1999;
			}
			if (VisYear == "0")
			{
				return 2001;
			}
			if (VisYear == "1")
			{
				return 2002;
			}
			if (VisYear == "2")
			{
				return 2003;
			}
			if (VisYear == "3")
			{
				return 2004;
			}
			if (VisYear == "4")
			{
				return 2005;
			}
			if (VisYear == "5")
			{
				return 2006;
			}
			if (VisYear == "6")
			{
				return 2007;
			}
			if (VisYear == "7")
			{
				return 2008;
			}
			if (VisYear == "8")
			{
				return 2009;
			}
			return 0;
		}

		public static bool CheckVIN(string Vin)
		{
			if (Vin.Length == 17 || 
				Vin.IndexOf("I") == -1 ||
				Vin.IndexOf("Q") == -1 ||
				Vin.IndexOf("O") == -1 ||
				Regex.IsMatch(Vin, @"[A-Z0-9]"))

			{
				return true;
			}
			return false;
		}
	}
}
