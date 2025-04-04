using PSI; 
using System.Collections.Generic;
namespace TestPSI2;

public class Tests
{
    private Graphe<Station> graphe;
    private List<Lien> liens;
    
    [SetUp]
    public void Setup()
    {
        Graphe<Station> graphe = new Graphe<Station>(new List<Noeud<Station>>());
        liens = new List<Lien>();
        var stationA = new Station("Station A", "Ligne 1", "Paris", 0, 28.0f, 18.0f);
        var stationB = new Station("Station B", "Ligne 1", "Paris", 1, 42.0f, 50.0f);
        var stationC = new Station("Station C", "Ligne 2", "paris", 2, 13.0f, 32.0f);
        
        var noeudA = new Noeud<Station>(0, stationA);
        var noeudB = new Noeud<Station>(1, stationB);
        var noeudC = new Noeud<Station>(2, stationC);
        
        var noeuds = new List<Noeud<Station>> { noeudA, noeudB, noeudC };
        graphe = new Graphe<Station>(noeuds);
        
        liens = new List<Lien>
        {
            new Lien(noeudA, noeudA, noeudB, 10, 5),
            new Lien(noeudB, noeudB, noeudC, 15, 5)
        };
    }
    
    [Test]
    public void TestTrouverNoeudParId()
    {
        Graphe<Station> graphe = new Graphe<Station>(new List<Noeud<Station>>());
        liens = new List<Lien>();

        var stationA = new Station("Station A", "Ligne 1", "Paris", 0, 28.0f, 18.0f);
        var stationB = new Station("Station B", "Ligne 1", "Paris", 1, 42.0f, 50.0f);
        var stationC = new Station("Station C", "Ligne 2", "paris", 2, 13.0f, 32.0f);
        
        var noeudA = new Noeud<Station>(0, stationA);
        var noeudB = new Noeud<Station>(1, stationB);
        var noeudC = new Noeud<Station>(2, stationC);
        
        var noeuds = new List<Noeud<Station>> { noeudA, noeudB, noeudC };
        graphe = new Graphe<Station>(noeuds);
        
        liens = new List<Lien>
        {
            new Lien(noeudA, noeudA, noeudB, 10, 5),
            new Lien(noeudB, noeudB, noeudC, 15, 5)
        };
        
        var noeud = graphe.TrouverNoeudParId(1);
        Assert.IsNotNull(noeud);
        Assert.AreEqual("Station B", noeud.Station.Nom_station);
    }
    
    [Test]
    public void TestCreerGrapheDuChemin()
    {
        Graphe<Station> graphe = new Graphe<Station>(new List<Noeud<Station>>());
        liens = new List<Lien>();
        var stationA = new Station("Station A", "Ligne 1", "Paris", 0, 28.0f, 18.0f);
        var stationB = new Station("Station B", "Ligne 1", "Paris", 1, 42.0f, 50.0f);
        var stationC = new Station("Station C", "Ligne 2", "paris", 2, 13.0f, 32.0f);
        
        var noeudA = new Noeud<Station>(0, stationA);
        var noeudB = new Noeud<Station>(1, stationB);
        var noeudC = new Noeud<Station>(2, stationC);
        
        var noeuds = new List<Noeud<Station>> { noeudA, noeudB, noeudC };
        graphe = new Graphe<Station>(noeuds);
        
        liens = new List<Lien>
        {
            new Lien(noeudA, noeudA, noeudB, 10, 5),
            new Lien(noeudB, noeudB, noeudC, 15, 5)
        };
        var chemin = new List<Noeud<Station>>
        {
            graphe.TrouverNoeudParId(0),
            graphe.TrouverNoeudParId(1),
            graphe.TrouverNoeudParId(2)
        };

        var grapheChemin = Graphe<Station>.CreerGrapheDuChemin(chemin, liens);

        Assert.IsNotNull(grapheChemin);
        Assert.AreEqual(chemin.Count, grapheChemin.noeuds.Count);
    }


    [Test]
        public void TestBellmanFord()
        {
            Graphe<Station> graphe = new Graphe<Station>(new List<Noeud<Station>>());
            liens = new List<Lien>();
            var stationA = new Station("Station A", "Ligne 1", "Paris", 0, 28.0f, 18.0f);
            var stationB = new Station("Station B", "Ligne 1", "Paris", 1, 42.0f, 50.0f);
            var stationC = new Station("Station C", "Ligne 2", "paris", 2, 13.0f, 32.0f);
            
            var noeudA = new Noeud<Station>(0, stationA);
            var noeudB = new Noeud<Station>(1, stationB);
            var noeudC = new Noeud<Station>(2, stationC);
            
            var noeuds = new List<Noeud<Station>> { noeudA, noeudB, noeudC };
            graphe = new Graphe<Station>(noeuds);
            
            liens = new List<Lien>
            {
                new Lien(noeudA, noeudA, noeudB, 10, 5),
                new Lien(noeudB, noeudB, noeudC, 15, 5)
            };
            var depart = graphe.TrouverNoeudParId(0);
            var arrivee = graphe.TrouverNoeudParId(2);
            var chemin = graphe.BellmanFord(depart, arrivee, liens);
            
            Assert.That(depart, Is.EqualTo(chemin[0]));
            Assert.AreEqual(arrivee, chemin[^1]);
        }

         public void TestFloydWarshall()
        {
            var (distance, pred) = graphe.FloydWarshall(liens);

            
            int ligne = distance.GetLength(0); 
            int colonne = distance.GetLength(1); 

            Assert.IsNotNull(distance);
            Assert.Greater(ligne, 0);
            Assert.Greater(colonne, 0);

            int distanceTest = distance[0, 2]; 
            Assert.AreEqual(25, distanceTest);
        }
        
}