using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RantPronounce
{
	public class SAMPAConverter
	{
		Dictionary<string, string> conversionTable;
		public SAMPAConverter()
		{
			conversionTable = new Dictionary<string, string>()
			{
				{ "AO", "O" },
				{ "AA", "A" },
				{ "IY", "i" },
				{ "UW", "u" },
				{ "EH", "E" },
				{ "IH", "I" },
				{ "UH", "U" },
				{ "AH", "V" },
				{ "AX", "@" },
				{ "AE", "{" },
				{ "EY", "eI" },
				{ "AY", "aI" },
				{ "OW", "oU" },
				{ "AW", "aU" },
				{ "OY", "OI" },
				{ "ER", "3`" },
				{ "AXR", "@`" },
				{ "EH R", "er" },
				{ "UH R", "Ur" },
				{ "AO R", "Or" },
				{ "AA R", "Ar" },
				{ "IH R", "Ir" },
				{ "IY R", "Ir" },
				{ "AW R", "@r" },
				{ "P", "p" },
				{ "B", "b" },
				{ "T", "t" },
				{ "D", "d" },
				{ "K", "k" },
				{ "G", "g" },
				{ "CH", "tS" },
				{ "JH", "dZ" },
				{ "F", "f" },
				{ "V", "v" },
				{ "TH", "T" },
				{ "DH", "D" },
				{ "S", "s" },
				{ "Z", "z" },
				{ "SH", "S" },
				{ "ZH", "Z" },
				{ "HH", "h" },
				{ "M", "m" },
				{ "EM", "m" },
				{ "N", "n" },
				{ "EN", "n" },
				{ "NG", "N" },
				{ "ENG", "N" },
				{ "L", "l" },
				{ "EL", "@l" },
				{ "R", "r" },
				{ "DX", "t" },
				{ "NX", "n" },
				{ "Y", "j" },
				{ "W", "w" }
			};
		}

		public string FromARPABet(string arpabet)
		{
			string[] parts = arpabet.Split(' ');
			string final = "";
			for(var i = 0; i < parts.Length; i++) 
			{
				string part = parts[i];
				if(part == "-")
				{
					final += "-";
					continue;
				}
				part = string.Join("", part.ToCharArray().Where(x => !Char.IsDigit(x)).ToArray());
				if(i < parts.Length - 1 && parts[i + 1] == "R")
					if(conversionTable.ContainsKey(part + " R"))
					{
						final += conversionTable[part + " R"];
						continue;
					}
				if(conversionTable.ContainsKey(part))
					final += conversionTable[part];
				else
					Console.WriteLine("Unknown ARPAbet character: " + part);
			}
			return final;
		}
	}
}
