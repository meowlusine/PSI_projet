using System;
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

            foreach (var Noeud in noeuds)
            {
                liste_adjacence[Noeud] = new List<Noeud<T>>();
            }

            this.matrice_adjacence = new int[noeuds.Count, noeuds.Count];

        }

        /// <summary>
        /// Ajoute un lien de type Lien dans la liste d'adjacence et dans la matrice d'adjacence
        /// </summary>
        /// <param name="lien"></param>
        public void AjouterLien(Lien lien)
        {
            Noeud<T> station = noeuds.Find(n => n.Id == lien.Station.Id);
            Noeud<T> suivant = noeuds.Find(n => n.Id == lien.Suivant.Id);

            int stationIndex = noeuds.IndexOf(station);
            int suivantIndex = noeuds.IndexOf(suivant);

            if (stationIndex >= 0 && stationIndex < noeuds.Count && suivantIndex >= 0 && suivantIndex < noeuds.Count)
            {
                this.liste_adjacence[station].Add(suivant);
                this.matrice_adjacence[stationIndex, suivantIndex] = lien.Temps_entre_2_stations;
                this.matrice_adjacence[suivantIndex, stationIndex] = lien.Temps_entre_2_stations;
                this.matrice_adjacence[stationIndex, stationIndex] = 0;

            }
        }

        /// <summary>
        /// Permet d'afficher la liste d'adjacence
        /// </summary>
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

        /// <summary>
        /// Permet d'afficher la matrice d'adjacence
        /// </summary>
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

        #region BFS et DFS
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
        #endregion BFS et DFS

        #region Connexité

        /// <summary>
        /// Permet de savoir si un graphe est connexe ou non
        /// </summary>
        /// <returns></returns>
        public bool EstConnexe()
        {
            bool[] visite = this.DFS(this.noeuds[0]);
            return visite.All(v => v);
        }
        #endregion Connexité


        /// <summary>
        /// Fonction FLoydWarshall
        /// </summary>
        /// <param name="liens"></param>
        /// <returns></returns>
        #region FloydWarshall
        public (int[,], int[,]) FloydWarshall(List<Lien> liens)
        {
            int n = noeuds.Count;
            int[,] distance = new int[n, n];
            int[,] pred = new int[n, n];


            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                        distance[i, j] = 0;
                    else
                        distance[i, j] = int.MaxValue;
                    pred[i, j] = -1;
                }
            }


            foreach (var lien in liens)
            {
                int i = lien.Station.Id - 1;
                int j = lien.Suivant.Id - 1;


                if (i >= 0 && i < n && j >= 0 && j < n)
                {
                    distance[i, j] = lien.Temps_entre_2_stations;
                    pred[i, j] = i;
                }
            }


            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (distance[i, k] != int.MaxValue && distance[k, j] != int.MaxValue && distance[i, j] > distance[i, k] + distance[k, j])
                        {
                            distance[i, j] = distance[i, k] + distance[k, j];
                            pred[i, j] = pred[k, j];
                        }
                    }
                }
            }

            return (distance, pred);
        }

        public void ObtenirTempsTrajet(int startId, int endId, int[,] distance, int[,] pred)
        {
            if (distance[startId, endId] == int.MaxValue)
            {
                Console.WriteLine("Aucun chemin trouvé entre les stations " + startId + " et " + endId);
                return;
            }

            int totalTime = distance[startId, endId];
            Console.WriteLine("Temps total du trajet : " + totalTime + " minutes");


            Stack<Noeud<T>> chemin = new Stack<Noeud<T>>();
            Noeud<T> actuel = TrouverNoeudParId(endId);

            while (actuel != null)
            {
                chemin.Push(actuel);
                int predId = pred[startId, actuel.Id];
                actuel = predId == -1 ? null : TrouverNoeudParId(predId);
            }

            Console.Write("Chemin le plus court : ");
            while (chemin.Count > 1)
            {
                var station = chemin.Pop();
                Console.Write(station.Station.Nom_station + " (Ligne " + station.Station.Ligne + ") -> ");
            }
            var lastStation = chemin.Pop();
            Console.WriteLine(lastStation.Station.Nom_station + " (Ligne " + lastStation.Station.Ligne + ")");
        }

        public List<Noeud<T>> ReconstruireChemin(int startId, int endId, int[,] pred)
        {
            List<Noeud<T>> chemin = new List<Noeud<T>>();
            int temporaire = endId - 1;


            if (pred[startId, endId] == -1)
            {
                Console.WriteLine("Aucun chemin trouvé entre les nœuds.");
                return chemin;
            }


            while (temporaire != startId)
            {
                chemin.Insert(0, noeuds[temporaire]);
                temporaire = pred[startId, temporaire];


                if (temporaire == -1)
                {
                    Console.WriteLine("Le chemin est interrompu en raison d'un prédécesseur invalide.");
                    return chemin;
                }
            }

            chemin.Insert(0, noeuds[startId]);
            return chemin;
        }
        #endregion FloydWarshall



        #region BellmanFord
        public List<Noeud<T>> BellmanFord(Noeud<T> depart, Noeud<T> arrivee, List<Lien> liens)
        {
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

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

                                Noeud<T> stationPrecedente = predecesseur[arrivee]; 
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


                                    if (dernierLien != null)
                                    {
                                        distance[suivant] += dernierLien.Temps_entre_2_stations;
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

            List<Noeud<T>> chemin = new List<Noeud<T>>();
            Noeud<T> courant = arrivee;
            while (courant != null)
            {
                chemin.Insert(0, courant);
                courant = predecesseur[courant];
            }

            if (chemin.Count == 0 || chemin[0] != depart)
            {
                Console.WriteLine("Aucun chemin trouvé entre " + depart.Station.Nom_station + " et " + arrivee.Station.Nom_station);
                return null;
            }
            Console.WriteLine("Chemin trouvé de " + depart.Station.Nom_station + " à " + arrivee.Station.Nom_station + " :");
            foreach (var noeud in chemin)
            {
                Console.Write(noeud.Station.Nom_station + " -> ");
            }
            Console.WriteLine("\nDistance totale : " + distance[arrivee]);

            AfficherChemin(predecesseur, depart, arrivee, distance[arrivee]);

            stopwatch.Stop();
            Console.WriteLine("L'algorithme de BellmanFord s'est effectué en: " + stopwatch.ElapsedMilliseconds + "ms");

            return chemin;
        }

        /// <summary>
        /// Fonction pour trouver nœud par son id 
        /// </summary>
        public Noeud<T> TrouverNoeudParId(int id)
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
                Console.WriteLine("Le chemin est trop court.");
                return null;
            }

            
            Graphe<T> grapheChemin = new Graphe<T>(chemin);

            
            for (int i = 0; i < chemin.Count - 1; i++)
            {
                Noeud<T> station = chemin[i];
                Noeud<T> suivant = chemin[i + 1];

                Lien lien = tousLesLiens.Find(l => (l.Station.Id == station.Id && l.Suivant.Id == suivant.Id) || (l.Station.Id == suivant.Id && l.Suivant.Id == station.Id));

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
                actuel = predecesseur[actuel]; 
            }
            while (chemin.Count > 1)
            {
                Console.Write(chemin.Pop().Station.Nom_station + "(Ligne " + chemin.Peek().Station.Ligne + ") -> ");
            }


            Console.Write(chemin.Pop().Station.Nom_station);
            Console.WriteLine();
            Console.WriteLine("La distance la plus courte de " + depart.Station.Nom_station + " jusqu'à " + destination.Station.Nom_station + " est " + distance + " minutes.");
        }
        #endregion BellmanFord

        #region Dijkstra 

        /// <summary>
        /// Fonction Djikstra, permet de trouver le PCC d'un noeud de depart à un noeud d'arrivé
        /// </summary>
        /// <param name="graphe"></param>
        /// <param name="depart"></param>
        /// <param name="arrivee"></param>
        /// <returns></returns>
        public static (Noeud<Station>[], int) dijkstra(Graphe<Station> graphe, Noeud<Station> depart, Noeud<Station> arrivee)
        {
            System.Diagnostics.Stopwatch stopwatch2 = new System.Diagnostics.Stopwatch();
            stopwatch2.Start();

            int temps = 0;
            bool[] visite = new bool[graphe.noeuds.Count()];
            int[] poids = new int[graphe.noeuds.Count()];
            Noeud<Station>[] ordre = new Noeud<Station>[graphe.noeuds.Count()];
            for (int j = 0; j < graphe.noeuds.Count(); j++)
            {
                poids[j] = int.MaxValue;
                ordre[j] = null;
            }
            poids[depart.Id - 1] = 0;
            List<Noeud<Station>> file = new List<Noeud<Station>>(graphe.noeuds);
            while (file.Count > 0)
            {
                Noeud<Station> n = null;
                int mini_poids = int.MaxValue;
                foreach (Noeud<Station> noeud in file)
                {
                    if (visite[noeud.Id - 1] == false && poids[noeud.Id - 1] < mini_poids)
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
                        foreach (Noeud<Station> voisin in graphe.liste_adjacence[n])
                        {
                            if (visite[voisin.Id - 1] == false)
                            {
                                int ponderation = graphe.matrice_adjacence[n.Id - 1, voisin.Id - 1];
                                int dist = poids[n.Id - 1] + ponderation;
                                if (dist < poids[voisin.Id - 1])
                                {
                                    poids[voisin.Id - 1] = dist;
                                    ordre[voisin.Id - 1] = n;
                                }
                            }
                        }
                    }
                }
                else
                {
                    file.Clear();
                }

            }
            List<Noeud<Station>> chemin = new List<Noeud<Station>>();
            Noeud<Station> actuel = arrivee;
            while (actuel != null)
            {
                chemin.Add(actuel);
                Noeud<Station> precedent = ordre[actuel.Id - 1];

                if (precedent != null)
                {
                    temps += graphe.matrice_adjacence[precedent.Id - 1, actuel.Id - 1];
                }

                actuel = precedent;
            }
            chemin.Reverse();

            stopwatch2.Stop();
            Console.WriteLine("Temps d'exécution de Dijkstra (en ticks) : " + stopwatch2.ElapsedTicks);
            Console.WriteLine("Temps d'exécution de Dijkstra(en ms) : " + stopwatch2.Elapsed.TotalMilliseconds);


            return (chemin.ToArray(), temps);
        }

        /// <summary>
        /// Permet de transformer un tableau de noeud en List<Noeud<Station>>, pour ensuite, à partir de cette liste, construire le graphe du PCC
        /// </summary>
        /// <param name="tab"></param>
        /// <returns></returns>
        public static List<Noeud<Station>> CreationListeNoeuds(Noeud<Station>[] tab)
        {
            if (tab == null || tab.Length == 0)
            {
                return null;
            }
            List<Noeud<Station>> list = new List<Noeud<Station>>();
            for (int i = 0; i < tab.Length; i++)
            {
                list.Add(tab[i]);
            }
            return list;
        }



        #endregion

    }
}