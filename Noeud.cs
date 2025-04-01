using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI
{
    public class Noeud<T> where T:Station
    {
        private int id;
        private T station; 


        public Noeud(int id,T station )
        {
            this.id = id;
            this.station = station;

        }
        public int Id
        {
            get { return id; }
        }

       
        public string toString()
        {
            return ($"id : {this.id}, La station {this.station.Nom_station} de la ligne {this.station.Ligne} " +
                $"se situe a {this.station.Commune_nom} ({this.station.Commune_code}), aux coordonnées {this.station.Longitude} {this.station.Latitude}.");
        }
    }
}