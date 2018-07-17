using System;
using System.Collections.Generic;
using System.Text;

namespace GFT_Test.Entities
{
    public class Puzzel
    {
        public char[,] matrix { get; set; }

        public List<string> wordsToFind { get; set; }

        public List<PuzzelSolution> puzzelSolutions { get; set; }

    }
}
