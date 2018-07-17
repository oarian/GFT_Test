using System;
using System.Collections.Generic;
using System.Text;

namespace GFT_Test.Entities
{
    public class PuzzelSolution
    {
        public PuzzelSolution()
        {
            this.breakdown = new List<Breakdown>();
        }

        public string word { get; set; }

        public List<Breakdown> breakdown { get; set; }
    }
}
