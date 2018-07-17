using System;
using System.Collections.Generic;
using System.Text;

namespace GFT_Test.Entities
{
    public class WordValues
    {
        public WordValues()
        {
            this.valuesPerWord = new List<Value>();
        }

        public List<Value> valuesPerWord { get; set; }
    }
}
