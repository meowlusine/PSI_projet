using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI
{
    public class GrapheUtilisateur
    {
        private Dictionary<Utilisateur, List<(Utilisateur Voisin, Commande Commande)>> adjacenceList;
        public List<Utilisateur> Utilisateurs { get; private set; }

        public GrapheUtilisateur(List<Utilisateur> utilisateurs)
        {
            this.Utilisateurs = utilisateurs;
            adjacenceList = new Dictionary<Utilisateur, List<(Utilisateur Voisin, Commande Commande)>>();
            foreach (var utilisateur in utilisateurs)
            {
                adjacenceList[utilisateur] = new List<(Utilisateur Voisin, Commande Commande)>();
            }
        }

        public void AjouterCommande(Commande commande)
        {
            Utilisateur envoyeur = commande.Cuisinier;
            Utilisateur receveur = commande.Client;

            if (envoyeur != null && receveur != null)
            {
               
                if (adjacenceList.ContainsKey(envoyeur))
                {
                    adjacenceList[envoyeur].Add((receveur, commande));
                }
                else
                {
                    adjacenceList[envoyeur] = new List<(Utilisateur Voisin, Commande Commande)> { (receveur, commande) };
                }

                
                if (adjacenceList.ContainsKey(receveur))
                {
                    adjacenceList[receveur].Add((envoyeur, commande));
                }
                else
                {
                    adjacenceList[receveur] = new List<(Utilisateur Voisin, Commande Commande)> { (envoyeur, commande) };
                }
            }
            else
            {
                Console.WriteLine($"Avertissement : La commande {commande.Id} a un envoyeur ou un receveur nul.");
            }
        }


        public List<(Utilisateur Voisin, Commande Commande)> ObtenirCommandes(Utilisateur utilisateur)
        {
            if (adjacenceList.ContainsKey(utilisateur))
            {
                return adjacenceList[utilisateur];
            }
            else
            {
                return new List<(Utilisateur Voisin, Commande Commande)>();
            }
        }

        public int GetDegre(Utilisateur utilisateur)
        {
            if (adjacenceList.ContainsKey(utilisateur))
            {
                return adjacenceList[utilisateur].Count;
            }
            else
            {
                return 0;
            }
        }
    }
}
