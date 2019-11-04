using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_applications_Facts
{
    public class WordsApparitions
    {
        public WordsApparitions(string[] text)
        {
            Text = text;
        }

        public IEnumerable<string> Text { get; set; }

        public IEnumerable<string> GetMostUsed()
        {
            return Text.GroupBy(x => x.ToLower())
                .OrderByDescending(x => x.Count())
                .Select(x => x.Key);
        }
    }
}