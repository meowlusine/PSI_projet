using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI
{
    public class Noeud
    {
        private int id;
        public Noeud(int id)
        {
            this.id = id;
        }
        public int Id
        {
            get { return id; }
        }

        public string toString()
        {
            return("id : "+this.id);
        }
    }
}
