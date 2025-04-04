using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI.Tests
{
    [TestClass()]

    
    public class GrapheTests
    {

        [TestMethod()]
        public void AjouterLienTest()
        {
            Noeud<Station> node1 = new Noeud<Station>(1, new Station("Station1", "Ligne1", "Commune", 101, 1.0f, 1.0f));
            Noeud<Station> node2 = new Noeud<Station>(2, new Station("Station2", "Ligne1", "Commune", 102, 2.0f, 2.0f));
            List<Noeud<Station>> nodes = new List<Noeud<Station>>() { node1, node2 };

            Graphe<Station> graphe = new Graphe<Station>(nodes);

            Lien lien = new Lien(node1, node1, node2, 5, 0);
            graphe.AjouterLien(lien);

            Assert.IsTrue(graphe.liste_adjacence[node1].Contains(node2), "La liste d'adjacence de Station1 doit contenir Station2.");

            int index0 = 0, index1 = 1;
            Assert.AreEqual(5, graphe.matrice_adjacence[index0, index1], "La matrice doit contenir la valeur 5 entre Station1 et Station2.");
            Assert.AreEqual(5, graphe.matrice_adjacence[index1, index0], "La matrice doit être symétrique et contenir 5 entre Station2 et Station1.");
        
        }

        
       

        [TestMethod()]
        public void dijkstraTest()
        {
            Noeud<Station> node1 = new Noeud<Station>(1, new Station("Station1", "Ligne1", "Commune", 101, 1.0f, 1.0f));
            Noeud<Station> node2 = new Noeud<Station>(2, new Station("Station2", "Ligne1", "Commune", 102, 2.0f, 2.0f));
            Noeud<Station> node3 = new Noeud<Station>(3, new Station("Station3", "Ligne1", "Commune", 103, 3.0f, 3.0f));
            Noeud<Station> node4 = new Noeud<Station>(4, new Station("Station4", "Ligne1", "Commune", 104, 4.0f, 4.0f));
            List<Noeud<Station>> nodes = new List<Noeud<Station>>() { node1, node2, node3, node4 };

            Graphe<Station> graphe = new Graphe<Station>(nodes);

           
            graphe.AjouterLien(new Lien(node1, node1, node2, 1, 0));
            graphe.AjouterLien(new Lien(node2, node2, node3, 2, 0));
            graphe.AjouterLien(new Lien(node1, node1, node3, 5, 0));
            graphe.AjouterLien(new Lien(node3, node3, node4, 1, 0));

            
            (Noeud<Station>[] chemin, int tempsTotal) = Graphe<Station>.dijkstra(graphe, node1, node4);

            
            Assert.AreEqual(4, tempsTotal, "Le temps total devrait être 1 + 2 + 1 = 4.");
        }

        
    }
}