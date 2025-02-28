using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI
{
    public class Lien
    {
        Noeud n_depart;
        Noeud n_arrivee;

        public Lien(Noeud n_depart, Noeud n_arrivee)
        {
            this.n_depart = n_depart;
            this.n_arrivee = n_arrivee;

        }

        public Noeud N_depart 
        { 
            get { return n_depart; } 
            set { n_depart = value; }
        }

        public Noeud N_arrivee 
        {
            get { return n_arrivee; }
            set { n_arrivee = value; }
        }

    }
}
