using System;
using System.Collections.Generic;
using System.Linq;

namespace REG_MARK_LIB
{
	public class RegMarkLib
	{
		public static List<string> Nums= new List<string>();

		public static bool CheckMark(string Mark)
		{
			//Для проверки правильности введенных данных


			try
			{
				string[] Chars = new string[] { "A", "B", "E", "K", "M", "H", "O", "P", "C", "T", "Y", "X" };
				int CH1 = Chars.ToList().IndexOf(Mark.Substring(0, 1));
				int CH2 = Chars.ToList().IndexOf(Mark.Substring(4, 1));
				int CH3 = Chars.ToList().IndexOf(Mark.Substring(5, 1));

				int Num = int.Parse(Mark.Substring(1, 3));
				int Region = Mark.Length == 9 ? int.Parse(Mark.Substring(6, 3)) : int.Parse(Mark.Substring(6, 2));

				if (Num > 999 || Num < 1)
				{
					return false;
				}

			}
			catch (Exception Ex)
			{
				return false;
			}

			return true;

		}

		public static string GetNextMarkAfter(string Mark)
		{
			//Для получения следующего номера

			string[] Chars = new string[] { "A", "B", "E", "K", "M", "H", "O", "P", "C", "T", "Y", "X" };

			if (Mark.Substring(1, 4) == "0010")
			{
				Mark = Mark.Substring(0, 1) + Mark.Substring(2);
			}
			int Region = Mark.Length == 9 ? int.Parse(Mark.Substring(6, 3)) : int.Parse(Mark.Substring(6, 2));

			int CH1 = Chars.ToList().IndexOf(Mark.Substring(0, 1));
			int CH2 = Chars.ToList().IndexOf(Mark.Substring(4, 1));
			int CH3 = Chars.ToList().IndexOf(Mark.Substring(5, 1));

			int Num = int.Parse(Mark.Substring(1, 3));

			

			if (Num > 999 || Num < 1)
			{

				return "";
			}
			else
			{


				if (Num == 999)
				{
					if (CH3 == Chars.Length - 1 && CH2 == Chars.Length - 1 && CH1 == Chars.Length - 1)
					{
						return "A001AA" + (Region + 1);
					}
					else if (CH3 == Chars.Length - 1 && CH2 == Chars.Length - 1)
					{
						return Chars[CH1 + 1] + "001" + Chars[0] + Chars[0] + new String('0', Region.ToString().Length == 3 ? 3 - Region.ToString().Length : 2 - Region.ToString().Length) + Region;
					}
					else if (CH3 == Chars.Length - 1)
					{
						return Chars[CH1] + "001" + Chars[CH2 + 1] + Chars[0] + new String('0', Region.ToString().Length == 3 ? 3 - Region.ToString().Length : 2 - Region.ToString().Length) + Region;
					}
					else
					{
						return Chars[CH1] + "001" + Chars[CH2] + Chars[CH3 + 1] + new String('0', Region.ToString().Length == 3 ? 3 - Region.ToString().Length : 2 - Region.ToString().Length) + Region;
					}
				}

				var StringNum = new String('0', 3 - Num.ToString().Length);
				var Result = Num == 99 ? Num + 1 + "" : StringNum + (Num + 1);

				return Chars[CH1] +  Result + Chars[CH2] + Chars[CH3] + Region;
			}
		}

		public static int GetCombinationsCountInRange(string Mark1, string Mark2)
		{
			//Для проверки количества номеров между двумя введенными

			int Count = 1;
			while (Mark1 != Mark2)
			{
				Mark1 = GetNextMarkAfter(Mark1);
				Count++;
			}
			return Count;
		}



		public static string GetNextMarkAfterInRange(string PrevMark, string RangeStart, string RangeEnd)
		{
			//Для получения следующего номера между двумя введенными номерами

			string Start = RangeStart;
			

			while (Start != RangeEnd)
			{
				Nums.Add(Start);
				Start = GetNextMarkAfter(Start);	
			}

			int Is = Nums.IndexOf(PrevMark);

			if (Is == -1)
			{
				Console.WriteLine("out of stock");
			}
			else
			{
				return GetNextMarkAfter(PrevMark);
			}
			return null;
		}
	}
}

