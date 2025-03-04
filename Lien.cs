using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI
{
    public class Lien
    {
        Noeud station;
        Noeud precedent;
        Noeud suivant;
        int temps_entre_2_stations;
        int temps_de_changement;


        public Lien(Noeud station, Noeud precedent, Noeud suivant, int temps_entre_2_stations, int temps_de_changement)
        {
            this.station = station;
            this.precedent = precedent;
            this.suivant = suivant;
            this.temps_entre_2_stations = temps_entre_2_stations;
            this.temps_de_changement = temps_de_changement;

        }

        public Noeud Station 
        {
            get { return station; } 
        }

        public Noeud Precedent 
        { 
            get { return precedent; } 
        }

        public Noeud Suivant
        {
            get { return suivant; }
        }

        public int Temps_entre_2_stations
        {
            get { return temps_entre_2_stations; }
        }

        public int Temps_de_changement
        {
            get { return temps_de_changement; }
        }

    }
}
