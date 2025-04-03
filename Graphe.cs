﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PSI
{
    public class Graphe<T> where T : Station, new()
    {

        public Dictionary<Noeud<T>, List<Noeud<T>>> liste_adjacence;
        public int[,] matrice_adjacence;
        public List<Noeud<T>> noeuds { get; private set; }

        public Graphe(List<Noeud<T>> noeuds)
        {
            this.noeuds = noeuds;
            this.liste_adjacence = new Dictionary<Noeud<T>, List<Noeud<T>>>();

            // Initialisation de la liste d'adjacence pour chaque noeud
            foreach (var Noeud in noeuds)
            {
                liste_adjacence[Noeud] = new List<Noeud<T>>();  // La clé est le Noeud<T>
            }

            this.matrice_adjacence = new int[noeuds.Count, noeuds.Count];  // Création de la matrice d'adjacence

        }

        /// <summary>
        /// Ajoute un lien de type Lien dans la liste d'adjacence et dans la matrice d'adjacence
        /// </summary>
        /// <param name="lien"></param>
        public void AjouterLien(Lien lien)
        {
            Noeud<T> station = noeuds.Find(n => n.Id == lien.Station.Id);
            Noeud<T> suivant = noeuds.Find(n => n.Id == lien.Suivant.Id);

            // Recherche de l'indice réel dans la liste
            int stationIndex = noeuds.IndexOf(station);
            int suivantIndex = noeuds.IndexOf(suivant);

            if (stationIndex >= 0 && stationIndex < noeuds.Count && suivantIndex >= 0 && suivantIndex < noeuds.Count)
            {
                this.liste_adjacence[station].Add(suivant);
                this.matrice_adjacence[stationIndex, suivantIndex] = 1;
                this.matrice_adjacence[suivantIndex, stationIndex] = 1;
            }
            
        }


        public void Afficher_liste_adj()
        {
            foreach (Noeud<T> noeud in this.liste_adjacence.Keys)
            {
                Console.WriteLine(noeud.ToString() + "\nLien avec  : ");
                foreach (Noeud<T> lie in liste_adjacence[noeud])
                {
                    Console.Write(lie.ToString() + ", ");
                }
                Console.WriteLine("\n");
            }
        }

        public void Affichier_matrice_adj()
        {
            int taille = this.matrice_adjacence.GetLength(0);
            for (int i = 0; i < taille; i++)
            {
                for (int j = 0; j < taille; j++)
                {
                    Console.Write($"{this.matrice_adjacence[i, j],2} ");

                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Parcours en profondeurs du graphe utilisant la liste d'adjacence
        /// </summary>
        /// <param name="depart"></param>
        public bool[] DFS(Noeud<T> depart)
        {
            Stack<Noeud<T>> pile = new Stack<Noeud<T>>();
            bool[] visite = new bool[noeuds.Count];
            List<Noeud<T>> ordreVisites = new List<Noeud<T>>();

            pile.Push(depart);

            while (pile.Count > 0)
            {
                Noeud<T> actuel = pile.Pop();
                int index = actuel.Id - 1;
                if (visite[index] == false)
                {
                    visite[index] = true;
                    ordreVisites.Add(actuel);
                    foreach (Noeud<T> voisin in this.liste_adjacence[actuel])
                    {
                        int voisinIndex = voisin.Id - 1;
                        if (visite[voisinIndex] == false)
                        {
                            pile.Push(voisin);
                        }
                    }
                }
            }

            // Affichage de l'ordre des nœuds visités
            Console.WriteLine("Ordre des noeuds visités : ");
            foreach (Noeud<T> noeud in ordreVisites)
            {
                Console.Write(noeud.ToString() + " ");
            }
            Console.WriteLine();

            return visite;

        }

        /// <summary>
        /// Parcours en largeurs du graphe en utilisant la liste d'adjacence
        /// </summary>
        /// <param name="depart"></param>
        public bool[] BFS(Noeud<T> depart)
        {
            bool[] visite = new bool[noeuds.Count];
            Queue<Noeud<T>> file = new Queue<Noeud<T>>();
            List<Noeud<T>> ordreVisites = new List<Noeud<T>>();

            file.Enqueue(depart);
            visite[depart.Id - 1] = true;

            while (file.Count > 0)
            {
                Noeud<T> actuel = file.Dequeue();
                ordreVisites.Add(actuel);

                foreach (Noeud<T> voisin in liste_adjacence[actuel])
                {
                    if (visite[voisin.Id - 1] == false)
                    {
                        visite[voisin.Id - 1] = true;
                        file.Enqueue(voisin);
                    }
                }
            }

            Console.WriteLine("Ordre des noeuds visités : ");
            foreach (Noeud<T> noeud in ordreVisites)
            {
                Console.Write(noeud.ToString() + " ");
            }
            Console.WriteLine();
            return visite;
        }

        public bool EstConnexe()
        {
            bool[] visite = this.DFS(this.noeuds[0]); // On commence le DFS depuis le premier nœud
            return visite.All(v => v); // Vérifie si tous les nœuds ont été visités
        }
        
        #region BellmanFord
        public List<Noeud<T>> BellmanFord(Noeud<T> depart, Noeud<T> arrivee, List<Lien> liens)
        {
            if (!noeuds.Contains(depart))
            {
                Console.WriteLine("Le point de départ n'existe pas dans le graphe.");
                return null;
            }

            Dictionary<Noeud<T>, int> distance = new Dictionary<Noeud<T>, int>();
            Dictionary<Noeud<T>, Noeud<T>> predecesseur = new Dictionary<Noeud<T>, Noeud<T>>();

            foreach (var noeud in noeuds) 
            {
                distance[noeud] = int.MaxValue;
                predecesseur[noeud] = null;
            }
            distance[depart] = 0;

            int nbNoeuds = noeuds.Count;
            bool miseAJour;

            for (int i = 0; i < nbNoeuds - 1; i++)
            {
                miseAJour = false;
                foreach (var lien in liens)
                {
                    Noeud<T> station = TrouverNoeudParId(lien.Station.Id);
                    Noeud<T> suivant = TrouverNoeudParId(lien.Suivant.Id);

                    if (station != null && suivant != null && distance[station] != int.MaxValue)
                    {
                        int poids = lien.Temps_entre_2_stations;
                        if (station.Station.Ligne != suivant.Station.Ligne) 
                        {
                            poids += lien.Temps_de_changement;
                        }

                        
                        if (distance[station] + poids < distance[suivant])
                        {
                            distance[suivant] = distance[station] + poids;
                            predecesseur[suivant] = station;
                            miseAJour = true;

                            if (suivant.Equals(arrivee))
                            {
                                
                                Noeud<T> stationPrecedente = predecesseur[arrivee]; // La station précédente de la station d'arrivée
                                if (stationPrecedente != null)
                                {
                                    Lien dernierLien = null;

                                    foreach (var l in liens)
                                    {
                                        if ((l.Station.Id == stationPrecedente.Id && l.Suivant.Id == arrivee.Id) || (l.Station.Id == arrivee.Id && l.Suivant.Id == stationPrecedente.Id)) 
                                        {
                                            dernierLien = l;
                                        }
                                    }

                                    // Si un dernier lien a été trouvé, on ajoute son temps de trajet
                                    if (dernierLien != null)
                                    {
                                        distance[suivant] += dernierLien.Temps_entre_2_stations; // Ajout du dernier temps de trajet
                                    } 
                                }
                    
                            }
                        }
                    }
                }
                if (!miseAJour)
                {
                    return null;
                }
            }
            //return ConstruireGraphe(predecesseur, arrivee, liens);
            List<Noeud<T>> chemin = new List<Noeud<T>>();
            Noeud<T> courant = arrivee;

            // Remonter les prédécesseurs depuis l'arrivée jusqu'au départ
            while (courant != null)
            {
                chemin.Insert(0, courant); // Insertion au début pour avoir l'ordre du départ à l'arrivée
                courant = predecesseur[courant];
            }

            // Vérification si un chemin a été trouvé
            if (chemin.Count == 0 || chemin[0] != depart)
            {
                Console.WriteLine("Aucun chemin trouvé entre " + depart.Station.Nom_station + 
                                " et " + arrivee.Station.Nom_station);
                return null;
            }

            // Affichage du chemin et de la distance totale
            Console.WriteLine("Chemin trouvé de " + depart.Station.Nom_station + 
                            " à " + arrivee.Station.Nom_station + " :");
            foreach (var noeud in chemin)
            {
                Console.Write(noeud.Station.Nom_station + " -> ");
            }
            Console.WriteLine("\nDistance totale : " + distance[arrivee]);

            AfficherChemin(predecesseur, depart, arrivee, distance[arrivee]);

            return chemin;
        }

        /// <summary>
        /// Fonction pour trouver nœud par son id 
        /// </summary>
        private Noeud<T> TrouverNoeudParId(int id)
        {
            foreach (Noeud<T> noeud in noeuds)
            {
                if (noeud.Id == id)
                {
                    return noeud;
                }
            }
            return null;
        }


       
        public static Graphe<T> CreerGrapheDuChemin(List<Noeud<T>> chemin, List<Lien> tousLesLiens)
        {
            if (chemin == null || chemin.Count < 2)
            {
                Console.WriteLine("Le chemin est trop court pour créer un graphe.");
                return null;
            }

            // Créer un nouveau graphe avec les nœuds du chemin
            Graphe<T> grapheChemin = new Graphe<T>(chemin);

            // Ajouter les liens entre les nœuds consécutifs du chemin
            for (int i = 0; i < chemin.Count - 1; i++)
            {
                Noeud<T> station = chemin[i];
                Noeud<T> suivant = chemin[i + 1];

                // Trouver le lien correspondant dans la liste complète des liens
                Lien lien = tousLesLiens.Find(l => (l.Station.Id == station.Id && l.Suivant.Id == suivant.Id) ||(l.Station.Id == suivant.Id && l.Suivant.Id == station.Id));

                if (lien != null)
                {
                    grapheChemin.AjouterLien(lien);
                }
            }

            return grapheChemin;
        }

        

        

        /// <summary>
        /// Fonction pour afficher PCC sur terminal
        /// </summary>
        private void AfficherChemin(Dictionary<Noeud<T>, Noeud<T>> predecesseur, Noeud<T> depart, Noeud<T> destination, int distance)
        {
            Stack<Noeud<T>> chemin = new Stack<Noeud<T>>();
            Noeud<T> actuel = destination;

            while (actuel != null)
            {
                chemin.Push(actuel);
                actuel = predecesseur[actuel]; //actualiser 
            }
            while (chemin.Count > 1)
            {
                Console.Write(chemin.Pop().Station.Nom_station+ "(Ligne " +chemin.Peek().Station.Ligne+") -> ");
            }

            
            Console.Write(chemin.Pop().Station.Nom_station);
            Console.WriteLine();
            Console.WriteLine("La distance la plus courte de "+ depart.Station.Nom_station+ " jusqu'à "  +destination.Station.Nom_station+ " est " + distance+ " minutes.");
        }
        #endregion BellmanFord

    }
}