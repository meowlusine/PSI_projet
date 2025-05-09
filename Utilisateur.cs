using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI
{
    public class Utilisateur
    {
        private int id; // Champ privé pour stocker l'ID
        private string nom; // Champ privé pour stocker le nom

        public int Id
        { // Propriété publique pour accéder à l'ID
            get { return id; }
            set { id = value; }
        }

        public string Nom
        { // Propriété publique pour accéder au nom
            get { return nom; }
            set { nom = value; }
        }

        public Utilisateur(int id, string nom)
        {
            this.id = id; // Assigner la valeur du paramètre 'id' au champ privé '_id'
            this.nom = nom; // Assigner la valeur du paramètre 'nom' au champ privé '_nom'
        }
    }
}