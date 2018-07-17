using System;
using System.Collections.Generic;
using System.Text;

namespace GFT_Test.Entities
{
    public class WordRules
    {
        public WordRules()
        {
            this.rulesPerWord = new List<Rule>();
        }

        public List<Rule> rulesPerWord { get; set; }
    }
}
