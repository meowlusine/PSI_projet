using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI
{
    internal class algos_chemin
    {
       /// <summary>
       /// Fonction Djikstra, permet de trouver le PCC d'un noeud de depart à un noeud d'arrivé
       /// </summary>
       /// <param name="graphe"></param>
       /// <param name="depart"></param>
       /// <param name="arrivee"></param>
       /// <returns></returns>
        public static (Noeud<Station>[],int) dijkstra(Graphe<Station> graphe, Noeud<Station> depart, Noeud<Station> arrivee)
       {
           System.Diagnostics.Stopwatch stopwatch2 = new System.Diagnostics.Stopwatch();
           stopwatch2.Start();

           int temps =0;
           bool[] visite = new bool[graphe.noeuds.Count()];
           int[] poids = new int[graphe.noeuds.Count()];
           Noeud<Station>[] ordre = new Noeud<Station>[graphe.noeuds.Count()];
           for (int j=0; j<graphe.noeuds.Count(); j++)
           {
               poids[j] = int.MaxValue;
               ordre[j] = null;
           }
           poids[depart.Id - 1] = 0;
           List<Noeud<Station>> file = new List<Noeud<Station>>(graphe.noeuds);
           while(file.Count > 0)
           {
               Noeud<Station> n = null;
               int mini_poids = int.MaxValue;
               foreach(Noeud<Station> noeud in file)
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
                       foreach(Noeud<Station> voisin in graphe.liste_adjacence[n])
                       {
                           if (visite[voisin.Id - 1] == false)
                           {
                               int ponderation = graphe.matrice_adjacence[n.Id - 1, voisin.Id - 1];
                               int dist = poids[n.Id - 1] + ponderation;
                               if (dist < poids[voisin.Id - 1])
                               {
                                   poids[voisin.Id -1]= dist;
                                   ordre[voisin.Id - 1] = n;
                                   temps += ponderation;
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
           List<Noeud<Station>> chemin = new List<Noeud<Station>>();
           Noeud<Station> actuel = arrivee;
           while (actuel != null)
           {
               chemin.Add(actuel);
               actuel = ordre[actuel.Id - 1];
           }
           chemin.Reverse();

           stopwatch2.Stop();
           Console.WriteLine("Temps d'exécution de Dijkstra(en ms) : " + stopwatch2.Elapsed.TotalMilliseconds);


           return (chemin.ToArray(),temps); 
       }

       /// <summary>
       /// Permet de transformer un tableau de noeud en List<Noeud<Station>>, pour ensuite, à partir de cette liste, construire le graphe du PCC
       /// </summary>
       /// <param name="tab"></param>
       /// <returns></returns>
        public static List<Noeud<Station>> CreationListeNoeuds( Noeud<Station>[] tab)
        {
            if(tab == null || tab.Length == 0){
                return null;
            }
            List<Noeud<Station>> list= new List<Noeud<Station>>();
            for (int i = 0; i < tab.Length; i++){
                list.Add(tab[i]);
            }
            return list;
        }



        
    }
}
