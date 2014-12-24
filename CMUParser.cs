using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RantPronounce
{
	class CMUParser
	{
		public Dictionary<string, string> Pronunciations;
		public CMUParser(string file)
		{
			Pronunciations = new Dictionary<string, string>();
			string[] lines = File.ReadAllLines(file);
			foreach(string line in lines)
			{
				if(line.StartsWith("##")) continue;
				string[] parts = line.Split(' ');
				string word = parts[0];
				if(word.EndsWith(")"))
					word = word.Substring(0, word.Length - 3);
				string pron = string.Join(" ", parts.Skip(1).ToArray());
				Pronunciations[word.Trim().ToLower()] = pron.Trim();
			}
		}
	}
}
