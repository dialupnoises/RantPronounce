using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rant.Vocabulary;
using System.IO;

namespace RantPronounce
{
    class Program
    {
        static void Main(string[] args)
		{
			CMUParser dict = new CMUParser("cmu.dict");
			SAMPAConverter converter = new SAMPAConverter();
			converter.FromARPABet(dict.Pronunciations["grassy"]);
            foreach (string file in Directory.GetFiles("vocab", "*.dic"))
            {
                RantDictionaryTable table = RantDictionaryTable.FromFile(file, NsfwFilter.Allow);
				foreach(RantDictionaryEntry entry in table.GetEntries())
				{
					foreach(RantDictionaryTerm term in entry.Terms)
					{
						string pron = "";
						foreach(string part in term.Value.Split(' '))
						{
							if(dict.Pronunciations.ContainsKey(part))
								pron += converter.FromARPABet(dict.Pronunciations[part]) + " ";
						}
						term.Pronunciation = pron.Trim();
					}
					// if all subs don't have pronunciations, none of them should
					if(!entry.Terms.All(x => !string.IsNullOrEmpty(x.Pronunciation)))
						entry.Terms.ToList().ForEach(x => x.Pronunciation = "");
				}
				table.Save("new_vocab/" + Path.GetFileName(file));
            }
        }
    }
}
