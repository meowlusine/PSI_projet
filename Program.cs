using System;
using System.IO;

namespace PSI
{
    class Program
    {
        static void Main(string[] args)
        {
            string ligne;
            StreamReader sr = new StreamReader("soc-karate.mtx");
            do 
            { 
                ligne = sr.ReadLine(); 
            } 
            while (ligne.StartsWith("%"));

            string[] dimensions = ligne.Split(' ');
            int nbNoeuds = int.Parse(dimensions[0]);  // Le nombre de noeuds
            int nbAretes = int.Parse(dimensions[2]); // Le nombre d'arêtes

            Graphe graphe = new Graphe(nbNoeuds);
            while ((ligne = sr.ReadLine()) != null)
            {
                string[] valeurs = ligne.Split(' ');
                int depart = int.Parse(valeurs[0]);  
                int arrivee = int.Parse(valeurs[1]);

                Noeud n_depart = graphe.noeuds[depart-1];
                Noeud n_arrivee = graphe.noeuds[arrivee-1];

                Lien lien = new Lien(n_depart, n_arrivee);
                graphe.AjouterLien(lien);
            }

            //graphe.Afficher_liste_adj();
            //graphe.Affichier_matrice_adj();
            //Console.WriteLine("DFS : ");
            //graphe.DFS(graphe.noeuds[0]);
            //graphe.BFS(graphe.noeuds[0]);
            //Console.WriteLine(graphe.EstConnexe());


            GraphVisualizer visualizer = new GraphVisualizer(graphe);
            string fichierSortie = "graphe.png";
            visualizer.GenererImage(fichierSortie);
            visualizer.AfficherImage(fichierSortie);
        }
    }
}
