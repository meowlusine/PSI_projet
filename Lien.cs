using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI
{
    public class Lien
    {
        Noeud<Station> station;
        Noeud<Station> precedent;
        Noeud<Station> suivant;
        int temps_entre_2_stations;
        int temps_de_changement;


        public Lien(Noeud<Station> station, Noeud<Station> precedent, Noeud<Station> suivant, int temps_entre_2_stations, int temps_de_changement)
        {
            this.station = station;
            this.precedent = precedent;
            this.suivant = suivant;
            this.temps_entre_2_stations = temps_entre_2_stations;
            this.temps_de_changement = temps_de_changement;

        }

        public Noeud<Station> Station
        {
            get { return station; }
        }

        public Noeud<Station> Precedent
        {
            get { return precedent; }
        }

        public Noeud<Station> Suivant
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

        public override string ToString()
        {
            string nomStation = station?.Station?.Nom_station ?? "inconnu";
            string nomPrec = precedent?.Station?.Nom_station ?? "inconnu";
            string nomSuiv = suivant?.Station?.Nom_station ?? "inconnu";

            return nomStation + " le prec est " + nomPrec + " la suiv est " + nomSuiv +
                   Convert.ToString(Temps_entre_2_stations) + Convert.ToString(Temps_de_changement);
        }

    }
}
