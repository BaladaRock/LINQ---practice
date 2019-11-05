using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_applications
{
    public class WordsApparitions
    {
        public WordsApparitions(string[] text)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
        }

        public IEnumerable<string> Text { get; set; }

        public IEnumerable<string> GetMostUsed()
        {
            const string toJoin = "\"";

            return Text.GroupBy(x => x.ToLower())
                .OrderByDescending(x => x.Count())
                .Select(x =>
                  string.Join(" - ", string.Join(x.Key, toJoin, toJoin), x.Count().ToString()));
        }
    }
}