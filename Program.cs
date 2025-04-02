using System;
using System.Globalization;
using System.IO;


namespace PSI
{
    class Program
    {
        static void Main(string[] args)
        {
            string fichier_station = "MetroParis - Noeuds.csv";
            string fichier_arc = "MetroParis - Arcs.csv";
            string[,] matrice_station = Transformation_Matrice(fichier_station);
            string[,] matrice_arc = Transformation_Matrice(fichier_arc);

            static string[,] Transformation_Matrice(string fichier)
            {
                List<string[]> liste_temporaire = new List<string[]>();

                using (var reader = new StreamReader(fichier))
                {
                    while (!reader.EndOfStream)
                    {
                        string ligne = reader.ReadLine();
                        string[] valeurs = ligne.Split(',');
                        liste_temporaire.Add(valeurs);
                    }
                }

                int nb_lignes = liste_temporaire.Count;
                int nb_colonnes = liste_temporaire[0].Length;

                string[,] matrice = new string[nb_lignes, nb_colonnes];

                for (int i = 0; i < nb_lignes; i++)
                {
                    for (int j = 0; j < nb_colonnes; j++)
                    {
                        matrice[i, j] = liste_temporaire[i][j]; //liste pcq on ne connait pas la longueur de la matrice pour l'instant
                    }
                }
                return matrice;
            }



            //Console.WriteLine("Première ligne (ID Station, Libelle Line, etc.):");
            //for (int i = 1; i < matrice_station.GetLength(1); i++)
            //{
            //Console.Write(matrice_station[0, i] + " | ");
            //}
            //Console.WriteLine();

            //Console.WriteLine("\nDétails pour la station 2:");
            //Console.WriteLine("ID Station: " + matrice_station[2, 0]);  // Devrait afficher "2"
            //Console.WriteLine("Libelle station: " + matrice_station[2, 2]);  // Devrait afficher "Argentine"
            //Console.WriteLine("Longitude: " + matrice_station[2, 3]);  // Devrait afficher "2.2894"
            //Console.WriteLine("Latitude: " + matrice_station[2, 4]);  // Devrait afficher "48.8756"  



            List<Station> stations = new List<Station>();

            for (int i = 1; i < matrice_station.GetLength(0); i++) // i = 1 pour ignorer nom de colonnes
            {

                string nom_station = matrice_station[i, 2];
                string ligne = matrice_station[i, 1];
                string commune_nom = matrice_station[i, 5];
                int commune_code = int.Parse(matrice_station[i, 6]);
                float longitude = float.Parse(matrice_station[i, 3], CultureInfo.InvariantCulture);
                float latitude = float.Parse(matrice_station[i, 4], CultureInfo.InvariantCulture);


                stations.Add(new Station(nom_station, ligne, commune_nom, commune_code, longitude, latitude));

            }

            // ajout de noeud

            List<Noeud<Station>> noeuds_temp = new List<Noeud<Station>>();
            for (int i = 0; i < stations.Count; i++)
            {
                noeuds_temp.Add(new Noeud<Station>(i + 1, stations[i]));

            }
            List<Noeud<Station>> noeuds = new List<Noeud<Station>>();
            List<string> nom_noeuds = new List<string>();

            for (int i = 0; i < stations.Count; i++)
            {
                if (!nom_noeuds.Contains(noeuds_temp[i].Station.Nom_station))
                {
                    nom_noeuds.Add(noeuds_temp[i].Station.Nom_station);
                    noeuds.Add(new Noeud<Station>(int.Parse(matrice_station[i + 1, 0]), stations[i]));
                }

            }




            //ajout lien 
            List<Lien> liens = new List<Lien>();


            // Boucle sur la matrice en ignorant la ligne 0.
            for (int i = 1; i < matrice_station.GetLength(0); i++)
            {
                // Calcul de l'indice dans la liste de nœuds (décalage de 1)
                int index = i - 1;

                Noeud<Station> prec = new Noeud<Station>(0, null);
                if (matrice_arc.GetLength(1) > 2 && !string.IsNullOrEmpty(matrice_arc[i, 2]) && index - 1 >= 0)
                {
                    prec = noeuds_temp[index - 1];
                }


                Noeud<Station> suiv = new Noeud<Station>(0, null);
                if (matrice_arc.GetLength(1) > 3 && !string.IsNullOrEmpty(matrice_arc[i, 3]) && (index + 1) < noeuds_temp.Count)
                {
                    suiv = noeuds_temp[index + 1];
                }

                int temp_changement = 0;
                if (matrice_arc.GetLength(1) > 5 && !string.IsNullOrEmpty(matrice_arc[i, 5]))
                {
                    if (!int.TryParse(matrice_arc[i, 5], out temp_changement))
                    {
                        temp_changement = 0;
                    }
                }


                int tempsEntre = 0;
                if (matrice_arc.GetLength(1) > 4 && !string.IsNullOrEmpty(matrice_arc[i, 4]))
                {
                    if (!int.TryParse(matrice_arc[i, 4], out tempsEntre))
                    {
                        tempsEntre = 0;
                    }
                }


                liens.Add(new Lien(noeuds_temp[index], prec, suiv, tempsEntre, temp_changement));
            }





            //Creation graphe 
            Graphe<Station> graphe = new Graphe<Station>(noeuds_temp );

            // Ajoute les liens dans le graphe
            foreach (var lien in liens)
            {
                graphe.AjouterLien(lien);
            }

            // Affiche la liste d'adjacence
            //.Afficher_liste_adj();

            //Affichage de la matrice d'adjacence
            //Console.WriteLine("Matrice d'adjacence :");
            //graphe.Affichier_matrice_adj();

            GraphVisualizer visualizer = new GraphVisualizer(graphe);
           
            visualizer.GenererImage("graphe.png");
            visualizer.AfficherImage("graphe.png");

            //// Test DFS
            //Console.WriteLine("\nTest DFS depuis Station 1 :");
            //graphe.DFS(noeuds[0]);

            //// Test BFS
            //Console.WriteLine("\nTest BFS depuis Station 1 :");
            //graphe.BFS(noeuds[0]);

            //// Vérification si le graphe est connexe
            //Console.WriteLine("\nLe graphe est-il connexe ? " + graphe.EstConnexe());


            //// Pause pour voir le résultat dans une application console classique
            //Console.WriteLine("\nAppuyez sur une touche pour fermer...");
            //Console.ReadKey();









            // test lien 
            //Console.WriteLine("\nListe des liens créés :");
            //foreach (Lien lien in liens)
            //{
            //Console.WriteLine(lien.Temps_entre_2_stations);
            //}
            //Console.WriteLine(liens.Count());
            //Console.WriteLine(noeuds_temp.Count());


            //TEST STATIONS
            //foreach (var station in stations)
            //{
            //Console.WriteLine($"Station : {station.Nom_station}, Ligne : {station.Ligne}, " +
            //$"Commune : {station.Commune_nom} ({station.Commune_code}), " +
            //$"Coordonnées : {station.Longitude}, {station.Latitude}");
            //}


            //TEST NOEUDS
            //Console.WriteLine("Liste des Noeuds :");
            //foreach (var noeud in noeuds)
            //{
            //Affiche chaque noeud avec son contenu (via ToString)
            //Console.WriteLine(noeud.ToString());
            //}


        }
    }
}





