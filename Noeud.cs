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
        private string station;
        private int ligne;
        private float longitude;
        private float latitude;
        private string commune_nom;
        private int commune_code;


        public Noeud(int id,string station,int ligne,float longitude,float latitude,string commune_nom, int commune_code)
        {
            this.id = id;
            this.commune_code = commune_code;
            this.station = station;
            this.longitude = longitude;
            this.latitude = latitude;
            this.commune_code= commune_code;
            this.ligne = ligne;

        }
        public int Id
        {
            get { return id; }
        }

        public string Station
        {
            get { return station; }
        }
        public int Ligne
        {
            get { return ligne; }
        }

        public float Longitude
        {
            get { return longitude; }
        }

        public float Latitude
        {
            get { return latitude; }
        }

        public string Commune_nom
        {
            get { return commune_nom; }
        }

        public int Commune_code
        {
            get { return commune_code; }
        }

        public string toString()
        {
            return($"id : {this.id}, La station {this.station} de la ligne {this.ligne} se situe a {this.commune_nom} ({this.commune_code}), aux coordonnées {this.longitude} {this.latitude}.");
        }
    }
}
