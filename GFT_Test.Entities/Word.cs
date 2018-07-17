using System;
using System.Collections.Generic;
using System.Text;

namespace GFT_Test.Entities
{
    public class Word
    {
        public string cypherWord { get; set; }

        public string decypherWord { get; set; }

        public char[] decypherRow { get; set; }

        public List<Value> valuesPerWord { get; set; }

        public List<Rule> rulesPerWord { get; set; } 
    }
}
