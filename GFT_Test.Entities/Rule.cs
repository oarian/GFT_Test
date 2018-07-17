using System;
using System.Collections.Generic;
using System.Text;

namespace GFT_Test.Entities
{
    public class Rule
    {
        public int order { get; set; }

        public string source { get; set; }

        public string replacement { get; set; }

        public bool isTermination { get; set; }
    }
}
