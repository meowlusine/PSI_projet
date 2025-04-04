using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using static System.Collections.Specialized.BitVector32;


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
                        matrice[i, j] = liste_temporaire[i][j]; 
                    }
                }
                return matrice;
            }

            List<Station> stations = new List<Station>();
            for (int i = 1; i < matrice_station.GetLength(0); i++) 
            {

                string nom_station = matrice_station[i, 2];
                string ligne = matrice_station[i, 1];
                string commune_nom = matrice_station[i, 5];
                int commune_code = int.Parse(matrice_station[i, 6]);
                float longitude = float.Parse(matrice_station[i, 3], CultureInfo.InvariantCulture);
                float latitude = float.Parse(matrice_station[i, 4], CultureInfo.InvariantCulture);


                stations.Add(new Station(nom_station, ligne, commune_nom, commune_code, longitude, latitude));

            }

            List<Noeud<Station>> noeuds_temp = new List<Noeud<Station>>();
            for (int i = 0; i < stations.Count; i++)
            {
                noeuds_temp.Add(new Noeud<Station>(i + 1, stations[i]));

            }
           

            List<string> exceptions = new List<string> { "place des fetes", "pres saint gervais", "danube" };
            List<Lien> liens = new List<Lien>();
            Dictionary<Noeud<Station>, int> noeudtransfert = new Dictionary<Noeud<Station>, int>();
            for (int i = 1; i < matrice_station.GetLength(0); i++)
            {
                int indice = i - 1;
                int transfert = 0;
                if (!string.IsNullOrEmpty(matrice_arc[i, 5]))
                {
                    if (!int.TryParse(matrice_arc[i, 5], out transfert))
                    {
                        transfert = 0;
                    }
                }
                noeudtransfert[noeuds_temp[indice]] = transfert;

               
                Noeud<Station> prec = new Noeud<Station>(0, null);
                if (matrice_arc.GetLength(1) > 2 && !string.IsNullOrEmpty(matrice_arc[i, 2]) && (indice - 1) >= 0)
                {
                    prec = noeuds_temp[indice - 1];
                }

               
                Noeud<Station> suiv = new Noeud<Station>(0, null);
                if (matrice_arc.GetLength(1) > 3 && !string.IsNullOrEmpty(matrice_arc[i, 3]) && (indice + 1) < noeuds_temp.Count)
                {
                    suiv = noeuds_temp[indice + 1];
                }

                int temp_changement = transfert; 
                int tempsEntre = 0;
                if (matrice_arc.GetLength(1) > 4 && !string.IsNullOrEmpty(matrice_arc[i, 4]))
                {
                    if (!int.TryParse(matrice_arc[i, 4], out tempsEntre))
                    {
                        tempsEntre = 0;
                    }
                }
                liens.Add(new Lien(noeuds_temp[indice], prec, suiv, tempsEntre, temp_changement));
               
                if (noeuds_temp[indice].Station.Ligne == "7bis" &&
                    exceptions.Contains(noeuds_temp[indice].Station.Nom_station.ToLower()))
                {
                    
                    if (!liens.Any(l => l.Station.Id == noeuds_temp[indice].Id && l.Suivant.Id == suiv.Id))
                    {

                    }
                }
                else
                {
                    liens.Add(new Lien(noeuds_temp[indice], suiv, prec, tempsEntre, temp_changement));

                }
            }

           
            var groupedeNoeud = noeuds_temp.GroupBy(n => n.Station.Nom_station);
            foreach (var group in groupedeNoeud)
            {
                var noeudDeMemeNom = group.ToList();
                if (noeudDeMemeNom.Count > 1)
                {
                    int transfert = noeudtransfert[noeudDeMemeNom[0]];
                    for (int i = 0; i < noeudDeMemeNom.Count; i++)
                    {
                        for (int j = i + 1; j < noeudDeMemeNom.Count; j++)
                        {
                           
                            liens.Add(new Lien(noeudDeMemeNom[i], noeudDeMemeNom[j], noeudDeMemeNom[j], 0, transfert));
                            liens.Add(new Lien(noeudDeMemeNom[j], noeudDeMemeNom[i], noeudDeMemeNom[i], 0, transfert));
                        }
                    }
                }
            }

            Graphe<Station> graphe = new Graphe<Station>(noeuds_temp);
            foreach (var lien in liens)
                {
                      graphe.AjouterLien(lien);
                }

               
            int val;
            while (true)
            {
                Console.WriteLine("Bienvenue sur Liv'In Paris  !\n Voulez vous vous connecter en tant que \n1.admin \nou \n2.utilisateur");
                string entre = Console.ReadLine();
                if (int.TryParse(entre, out val) && val >= 1 && val <= 2)
                {
                    break;
                }
                Console.WriteLine("Entrée invalide. Veuillez choisir un numéro entre 1 et 2.");
            }


            PSI_Mysql_C_Data Connexion = new PSI_Mysql_C_Data();
            switch (val)
            {
                case 1:
                    string mdp = "";
                    Console.WriteLine("Entrez le mot de passe admin");
                     mdp = Console.ReadLine();
                    while(mdp != "kakawete")
                    {
                        Console.WriteLine("Mot de passe incorrect, essayez à nouveau");
                        mdp = mdp = Console.ReadLine();
                    }
                    int rep;
                    while (true)
                    {
                        Console.WriteLine("1.Modifier la base de donnée\n2.Affichage");
                        string entre = Console.ReadLine();
                        if (int.TryParse(entre, out rep) && rep >= 1 && rep<= 2)
                        {
                            break;
                        }
                        Console.WriteLine("Entrée invalide. Veuillez choisir un numéro entre 1 et 5$2.");
                    }
                    MySqlConnection maConnexion =null;
                    try
                    {
                        string connexionString = "SERVER=localhost;PORT=3306;" +
                                                 "DATABASE=LivInParis;" +
                                                 "UID=root;PASSWORD=kakawete";

                         maConnexion = new MySqlConnection(connexionString);
                        maConnexion.Open();
                        Console.WriteLine("Connexion réussie.");
                    }
                    catch (MySqlException e)
                    {
                        Console.WriteLine("Erreur de connexion : " + e.Message);
                    }
                    switch (rep)
                    {
                        case 1:
                            Connexion.Requete();

                            break;
                        case 2:
                            int choix;
                            while (true)
                            {
                                Console.WriteLine("1.Clients\n2.Cuisiniers\n3.Commandes\n4.Statistiques\n5.Autres");
                                string entre = Console.ReadLine();
                                if (int.TryParse(entre, out choix) && choix >= 1 && choix <= 5)
                                {
                                    break;
                                }
                                Console.WriteLine("Entrée invalide. Veuillez choisir un numéro entre 1 et 5.");
                            }
                            switch (choix)
                            {
                                case 1:
                                    Connexion.Affichage_client();
                                    break;
                                case 2:
                                    Connexion.Affichage_cuisinier();
                                    break;
                                case 3:
                                    (string metroClient, string metroCuisinier) = Connexion.Affichage_commande();
                                    int id_metroClient = 0;
                                    int id_metroCuisinier = 0;
                                    for (int i = 0; i < noeuds_temp.Count; i++)
                                    {
                                        if (noeuds_temp[i].Station.Nom_station == metroClient)
                                        {
                                            id_metroClient = noeuds_temp[i - 1].Id;
                                        }
                                        else if (noeuds_temp[i].Station.Nom_station == metroCuisinier)
                                        {
                                            id_metroCuisinier = noeuds_temp[i - 1].Id;
                                        }
                                    }
                                    (Noeud<Station>[] chemin, int temps) = Graphe<Station>.dijkstra(graphe, noeuds_temp[id_metroClient], noeuds_temp[id_metroCuisinier]);
                                    Console.WriteLine("le chemin entre " + noeuds_temp[id_metroClient].Station.Nom_station + " et " + noeuds_temp[id_metroCuisinier].Station.Nom_station + " est ");
                                    foreach (Noeud<Station> station in chemin)
                                    {
                                        Console.WriteLine(station.Station.Nom_station);
                                    }
                                    Console.WriteLine("\n Ce trajet durera " + temps + " minutes.");
                                    List<Noeud<Station>> graphechemin = new List<Noeud<Station>>();

                                    for(int i =0; i < chemin.Length; i++)
                                    {
                                        graphechemin.Add(chemin[i]);
                                    }
                                    Graphe<Station> GrapheCheminAffiche = new Graphe<Station>(graphechemin);
                                    foreach (var lien in liens)
                                    {
                                        GrapheCheminAffiche.AjouterLien(lien);
                                    }
                                    GraphVisualizer visualizer = new GraphVisualizer(GrapheCheminAffiche);
                                    visualizer.GenererImage("graphe.png");
                                    visualizer.AfficherImage("graphe.png");


                                    break;
                                case 4:
                                    Connexion.Affichage_statistiques();
                                    break;

                                case 5:
                                    Connexion.Autre();
                                    break;
                            }

                            break;

                    }

                    break;
                case 2:

                    int chiffre;
                    while (true)
                    {
                        Console.WriteLine("Avez vous déjà un compte utilisateur ? \n1.oui\n2.non");
                        string entre = Console.ReadLine();
                        if (int.TryParse(entre, out chiffre) && chiffre >= 1 && chiffre <= 2)
                        {
                            break;
                        }
                        Console.WriteLine("Entrée invalide. Veuillez choisir un numéro entre 1 et 2.");
                    }
                    switch (chiffre)
                    {
                        case 1:
                            Console.WriteLine("En cours de code");

                        break;
                        case 2:
                            Console.WriteLine("Ajouter un utilisateur ! :");
                            int id_utilisateur =Connexion.AjouterUtilisateur();
                            

                            Console.WriteLine("Souhaitez vous creer un comptec client ? ");

                            int aut;
                            while (true)
                            {
                                Console.WriteLine("1.oui\n2.non");
                                string entre = Console.ReadLine();
                                if (int.TryParse(entre, out aut) && aut >= 1 && aut <= 2)
                                {
                                    break;
                                }
                                Console.WriteLine("Entrée invalide. Veuillez choisir un numéro entre 1 et 2.");
                            }
                            switch (aut)
                            {
                                case 1:
                                    Connexion.AjouterClient(id_utilisateur);
                                    break;
                                case 2:
                                    break;

                            }

                           

                            Console.WriteLine("Souhaitez vous creer un comptec cuisinier ? ");

                            int aut0;
                            while (true)
                            {
                                Console.WriteLine("1.oui\n2.non");
                                string entre = Console.ReadLine();
                                if (int.TryParse(entre, out aut0) && aut0 >= 1 && aut0 <= 2)
                                {
                                    break;
                                }
                                Console.WriteLine("Entrée invalide. Veuillez choisir un numéro entre 1 et 2.");
                            }
                            switch (aut0)
                            {
                                case 1:
                                    Connexion.AjouterCuisinier(id_utilisateur);
                                    break;
                                case 2:
                                    break;

                            }

                            break;


                    }
                    break;
               
            }
            







        }




    }



}



