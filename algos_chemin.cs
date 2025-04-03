﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI
{
    internal class algos_chemin
    {
       
        public static  Noeud<Station>[] dijkstra(Graphe<Station> graphe, Noeud<Station> depart, Noeud<Station> arrivee)
        {
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

            return chemin.ToArray();

        }

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
