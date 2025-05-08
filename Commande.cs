using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI
{
    public class Commande
    {
        public int Id { get; set; }
        public Utilisateur Client { get; set; }
        public Utilisateur Cuisinier { get; set; }

        public Commande(int id, Utilisateur client, Utilisateur cuisinier)
        {
            Id = id;
            Client = client;
            Cuisinier = cuisinier;
        }
    }
}
