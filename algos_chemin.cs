using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI
{
    internal class algos_chemin
    {
       
        public static Noeud[] dijkstra(Graphe graphe, Noeud depart, Noeud arrivee)
        {
            bool[] visite = new bool[graphe.noeuds.Count()];
            int[] poids = new int[graphe.noeuds.Count()];
            Noeud[] ordre = new Noeud[graphe.noeuds.Count()];
            for (int j=0; j<graphe.noeuds.Count(); j++)
            {
                poids[j] = int.MaxValue;
                ordre[j] = null;
            }
            poids[depart.Id - 1] = 0;
            List<Noeud> file = new List<Noeud>(graphe.noeuds);
            while(file.Count > 0)
            {
                Noeud n = null;
                int mini_poids = int.MaxValue;
                foreach(Noeud noeud in file)
                {
                    if (visite[noeud.Id -1] == false && poids[noeud.Id - 1] < mini_poids)
                    {
                        mini_poids = poids[noeud.Id - 1];
                        n = noeud;
                    }
                }

                if (n != null)
                {
                    file.Remove(n);
                    visite[n.Id - 1] = true;

                    if (n == arrivee)
                    {
                        file.Clear();
                    }
                    else
                    {
                        foreach(Noeud voisin in graphe.liste_adjacence[n])
                        {
                            if (visite[voisin.Id - 1] == false)
                            {
                                int ponderation = graphe.matrice_adjacence[n.Id - 1, voisin.Id - 1];
                                int dist = poids[n.Id - 1] + ponderation;
                                if (dist < poids[voisin.Id - 1])
                                {
                                    poids[voisin.Id -1]= dist;
                                    ordre[voisin.Id - 1] = n;
                                }
                            }
                        }
                    }
                }
                else
                {
                    file.Clear() ;
                }

            }
            List<Noeud> chemin = new List<Noeud>();
            Noeud actuel = arrivee;
            while (actuel != null)
            {
                chemin.Add(actuel);
                actuel = ordre[actuel.Id - 1];
            }
            chemin.Reverse();

            return chemin.ToArray();

        }

        
    }
}
