using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI
{
    public class Station
    {
        public string Nom_station { get; set; }
        public int Ligne { get; set; }
        public string Commune_nom { get; set; }
        public int Commune_code { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }


         public Station(string nom_station, int ligne, string commune_nom, int commune_code, float longitude, float latitude)
        {
            this.Nom_station = nom_station;
            this.Ligne = ligne;
            this.Commune_nom = commune_nom;
            this.Commune_code = commune_code;
            this.Longitude = longitude;
            this.Latitude = latitude;
        }
        
    }


}

