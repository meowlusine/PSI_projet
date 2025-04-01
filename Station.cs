using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI
{
    public class Station
    {
        private string nom_station;
        private string ligne;
        private string commune_nom;
       private int commune_code;
        private float longitude;
        private float latitude;
        public string Nom_station { get; set; }
        public string Ligne { get; set; }
        public string Commune_nom { get; set; }
        public int Commune_code { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }

        public Station(string nom_station, string ligne, string commune_nom, int commune_code, float longitude, float latitude)
        {
            this.Nom_station = nom_station;
            this.Ligne = ligne;
            this.Commune_nom = commune_nom;
            this.Commune_code = commune_code;
            this.Longitude = longitude;
            this.Latitude = latitude;
        }

        public Station()
        {

        }
    }


}

