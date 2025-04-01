using System;
using System.Globalization;
using System.IO;
using OfficeOpenXml;
using static OfficeOpenXml.ExcelErrorValue;

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



            Console.WriteLine("Première ligne (ID Station, Libelle Line, etc.):");
            for (int i = 0; i < matrice_station.GetLength(1); i++)
            {
                Console.Write(matrice_station[0, i] + " | ");
            }
            Console.WriteLine();

            Console.WriteLine("\nDétails pour la station 2:");
            Console.WriteLine("ID Station: " + matrice_station[2, 0]);  // Devrait afficher "2"
            Console.WriteLine("Libelle station: " + matrice_station[2, 2]);  // Devrait afficher "Argentine"
            Console.WriteLine("Longitude: " + matrice_station[2, 3]);  // Devrait afficher "2.2894"
            Console.WriteLine("Latitude: " + matrice_station[2, 4]);  // Devrait afficher "48.8756"  



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
                    noeuds.Add(new Noeud<Station>(int.Parse(matrice_station[i+1,0]), stations[i]));
                }
               
            }
            // test noeud
            
            foreach (var noeud in noeuds)
            {
                Console.WriteLine("Noeud Id: " + noeud.Id + ", Station: " + noeud.Station.Nom_station);
            }

            //ajout lien 
            List<Lien> liens = new List<Lien>();
            for(int i=1; i < matrice_station.GetLength(0); i++)
            {
                Noeud<Station> prec = new Noeud<Station>(0, null);
                if (matrice_arc[i,2] !=null )
                {
                    prec = noeuds_temp[i - 1];
                }
                Noeud<Station> suiv = new Noeud<Station>(0, null);
                if (!string.IsNullOrEmpty(matrice_arc[i, 3]))
                {
                    suiv = noeuds_temp[i + 1];
                }
                int temp_changement = 0;
                if (!string.IsNullOrEmpty(matrice_arc[i, 5]))
                {
                    if (!int.TryParse(matrice_arc[i, 5], out temp_changement))
                    {
                        temp_changement = 0; // ou une autre valeur par défaut
                    }
                }

                liens.Add(new Lien (noeuds_temp[i], prec, suiv, int.Parse(matrice_arc[i, 4]),temp_changement ));


            }
            // test lien 

            Console.WriteLine("\nListe des liens créés :");
            foreach (Lien lien in liens)
            {
                Console.WriteLine(lien);
            }

            // Pause pour voir le résultat dans une application console classique
            Console.WriteLine("\nAppuyez sur une touche pour fermer...");
            Console.ReadKey();


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
            // Affiche chaque noeud avec son contenu (via ToString)
            //Console.WriteLine(noeud.ToString());
            //}


        }
    }
}



