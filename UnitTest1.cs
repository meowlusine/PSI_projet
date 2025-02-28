using NUnit.Framework;
using System;

namespace PSI
{
    public class Tests
    {
        [Test]
        public void Test_CreationGraphe()
        {
            Graphe graphe = new Graphe(5);
            Assert.AreEqual(5, graphe.noeuds.Count);
        }

        [Test]
        public void Test_AjouterLien()
        {
            Graphe graphe = new Graphe(3);
            Noeud n1 = graphe.noeuds[0];
            Noeud n2 = graphe.noeuds[1];
            Lien lien = new Lien(n1, n2);

            graphe.AjouterLien(lien);

            Assert.Contains(n2, graphe.liste_adjacence[n1]);
            Assert.Contains(n1, graphe.liste_adjacence[n2]);
            Assert.AreEqual(1, graphe.matrice_adjacence[n1.Id - 1, n2.Id - 1]);
        }

        [Test]
        public void Test_DFS()
        {
            Graphe graphe = new Graphe(4);
            graphe.AjouterLien(new Lien(graphe.noeuds[0], graphe.noeuds[1]));
            graphe.AjouterLien(new Lien(graphe.noeuds[1], graphe.noeuds[2]));
            graphe.AjouterLien(new Lien(graphe.noeuds[2], graphe.noeuds[3]));

            bool[] visite = graphe.DFS(graphe.noeuds[0]);

            foreach (bool v in visite)
            {
                Assert.IsTrue(v);
            }
        }

        [Test]
        public void Test_BFS()
        {
            Graphe graphe = new Graphe(4);
            graphe.AjouterLien(new Lien(graphe.noeuds[0], graphe.noeuds[1]));
            graphe.AjouterLien(new Lien(graphe.noeuds[1], graphe.noeuds[2]));
            graphe.AjouterLien(new Lien(graphe.noeuds[2], graphe.noeuds[3]));

            bool[] visite = graphe.BFS(graphe.noeuds[0]);

            foreach (bool v in visite)
            {
                Assert.IsTrue(v);
            }
        }

        [Test]
        public void Test_EstConnexe()
        {
            Graphe graphe = new Graphe(3);
            graphe.AjouterLien(new Lien(graphe.noeuds[0], graphe.noeuds[1]));
            graphe.AjouterLien(new Lien(graphe.noeuds[1], graphe.noeuds[2]));

            Assert.IsTrue(graphe.EstConnexe());

            // Ajout d'un nœud isolé
            Graphe graphe2 = new Graphe(4);
            graphe2.AjouterLien(new Lien(graphe2.noeuds[0], graphe2.noeuds[1]));
            graphe2.AjouterLien(new Lien(graphe2.noeuds[1], graphe2.noeuds[2]));

            Assert.IsFalse(graphe2.EstConnexe());
        }
    }
}