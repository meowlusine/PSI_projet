using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI
{
   public  class FloydResult
    {
        public int[,] Dist { get; set; }
        public int?[,] Pred { get; set; }

        public FloydResult(int[,] dist, int?[,] pred)
        {
            this.Dist = dist;
            this.Pred = pred;
        }
    }
}
