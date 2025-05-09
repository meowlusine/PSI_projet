using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Windows.Input;
using static System.Collections.Specialized.BitVector32;


namespace PSI
{
    class Program
    {
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
        static void Main(string[] args)
        {
            #region initialisation et graphe
            string mdp = "kakawete";
            string fichier_station = "MetroParis - Noeuds.csv";
            string fichier_arc = "MetroParis - Arcs.csv";
            string[,] matrice_station = Transformation_Matrice(fichier_station);
            string[,] matrice_arc = Transformation_Matrice(fichier_arc);



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


            
            GraphVisualizer visualizer = new GraphVisualizer(graphe);
            visualizer.GenererImage("graphe.png");
            visualizer.AfficherImage("graphe.png");

            #endregion

            #region Graphe Utilisateur

            
            List<Utilisateur> utilisateurs = new List<Utilisateur>();
            List<Commande> commandes = new List<Commande>();
           
            Dictionary<int, Utilisateur> utilisateurParId = new Dictionary<int, Utilisateur>(); 
            string connexionString = "SERVER=localhost;PORT=3306;" +
                                    "DATABASE=LivInParis;" +
                                    "UID=root;PASSWORD=" + mdp;

            try
            {
                using (MySqlConnection maConnexion = new MySqlConnection(connexionString))
                {
                    maConnexion.Open();

                   
                    string requeteUtilisateurs = "SELECT id_utilisateur, nom FROM utilisateur;";
                    MySqlCommand commandUtilisateurs = new MySqlCommand(requeteUtilisateurs, maConnexion);
                    using (MySqlDataReader readerUtilisateurs = commandUtilisateurs.ExecuteReader())
                    {
                        while (readerUtilisateurs.Read())
                        {
                            int id = readerUtilisateurs.GetInt32("id_utilisateur");
                            string nom = readerUtilisateurs.GetString("nom");
                            Utilisateur utilisateur = new Utilisateur(id, nom);
                            utilisateurs.Add(utilisateur);
                            utilisateurParId.Add(id, utilisateur); 
                        }
                    }

                   
                    string requeteCommandes = @"
            SELECT
                c.id_commande,
                cl.id_utilisateur AS id_client_utilisateur,
                cu.id_utilisateur AS id_cuisinier_utilisateur
            FROM commande c
            JOIN client cl ON c.id_client = cl.id_client
            JOIN cuisinier cu ON c.id_cuisinier = cu.id_cuisinier;";

                    MySqlCommand commandCommandes = new MySqlCommand(requeteCommandes, maConnexion);
                    using (MySqlDataReader readerCommandes = commandCommandes.ExecuteReader())
                    {
                        while (readerCommandes.Read())
                        {
                            int idCommande = readerCommandes.GetInt32("id_commande");
                            int idClientUtilisateur = readerCommandes.GetInt32("id_client_utilisateur");
                            int idCuisinierUtilisateur = readerCommandes.GetInt32("id_cuisinier_utilisateur");

                            
                            if (utilisateurParId.ContainsKey(idClientUtilisateur) && utilisateurParId.ContainsKey(idCuisinierUtilisateur))
                            {
                                Utilisateur client = utilisateurParId[idClientUtilisateur];
                                Utilisateur cuisinier = utilisateurParId[idCuisinierUtilisateur];
                                commandes.Add(new Commande(idCommande, client, cuisinier));
                            }
                            else
                            {
                                Console.WriteLine($"Warning: Commande {idCommande} skipped because client {idClientUtilisateur} or cuisinier {idCuisinierUtilisateur} not found.");
                            }
                        }
                    }
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Erreur de connexion : " + e.Message);
                return;
            }

           
            GrapheUtilisateur grapheUtilisateur = new GrapheUtilisateur(utilisateurs);

           
            foreach (var commande in commandes)
            {
                grapheUtilisateur.AjouterCommande(commande);
            }

           
            GrapheUtilisateurVisualizer visualizerUtilisateur = new GrapheUtilisateurVisualizer(grapheUtilisateur);
            string cheminImage = "graphe.png";
            visualizerUtilisateur.GenererImage(cheminImage);
            visualizerUtilisateur.AfficherImage(cheminImage);

            #endregion

            #region XML JSON

           


            ExportXMLHandler handler = new ExportXMLHandler();
            handler.ExportUtilisateursToXML("utilisateurs.xml");


            ExportXMLHandler handler2 = new ExportXMLHandler();
            handler2.ExportCuisiniersToXML("cuisiniers.xml");

            ExportXMLHandler handler3 = new ExportXMLHandler();
            handler3.ExportClientsToXML("clients.xml");


            ExportXMLHandler handler4 = new ExportXMLHandler();
            handler4.ExportRecettesToXML("recettes.xml");

            ExportXMLHandler handler5 = new ExportXMLHandler();
            handler5.ExportCommandesToXML("commandes.xml");

            ExportXMLHandler handler6 = new ExportXMLHandler();
            handler6.ExportEntreprisesToXML("entreprises.xml");

            ExportXMLHandler handler7 = new ExportXMLHandler();
            handler7.ExportLivraisonsToXML("livraisons.xml");

            ExportXMLHandler handler8 = new ExportXMLHandler();
            handler8.ExportLivraisonCommandesToXML("livraison_commandes.xml");

            ExportXMLHandler handler9 = new ExportXMLHandler();
            handler9.ExportPlatsToXML("plats.xml");

            ExportXMLHandler handler10 = new ExportXMLHandler();
            handler10.ExportTransactionsToXML("transactions.xml");

            ExportXMLHandler handler11 = new ExportXMLHandler();
            handler11.ExportTransactionCommandesToXML("transaction_commandes.xml");


            var bdd1 = new BddJson();
            bdd1.ExporterRecettesEnJson();

            var bdd2 = new BddJson();
            bdd2.ExporterClientsEnJson();

            var bdd3 = new BddJson();
            bdd3.ExporterEntreprisesEnJson();

            var bdd4 = new BddJson();
            bdd4.ExporterPlatsEnJson();

            var bdd5 = new BddJson();
            bdd4.ExporterCommandesEnJson();

            var bdd6 = new BddJson();
            bdd6.ExporterCuisiniersEnJson();

            var bdd7 = new BddJson();
            bdd7.ExporterLivraisonsEnJson();

            var bdd8 = new BddJson();
            bdd8.ExporterLivraisonCommandesEnJson();

            var bdd9 = new BddJson();
            bdd9.ExporterTransactionCommandesEnJson();

            var bdd10 = new BddJson();
            bdd10.ExporterTransactionsEnJson();


            var bdd11 = new BddJson();
            bdd11.ExporterUtilisateursEnJson();


            #endregion XML JSON




            bool continuer = true;
            while (continuer)
            {
                Console.WriteLine("Bienvenue sur Liv'In Paris  !\n Voulez vous vous connecter en tant que \n1.admin \nou \n2.utilisateur");
                int val;
                while (!int.TryParse(Console.ReadLine(), out val) || val < 1 || val > 2)
                {
                    Console.WriteLine("Entrée invalide. Veuillez choisir un numéro entre 1 et 2.");
                }
                PSI_Mysql_C_Data Connexion = new PSI_Mysql_C_Data();
                switch (val)
                {
                    

                    case 1:
                       
                            string mot = "";
                            Console.WriteLine("Entrez le mot de passe admin");
                            mot = Console.ReadLine();
                            while (mot != mdp)
                            {
                                Console.WriteLine("Mot de passe incorrect, essayez à nouveau");
                                mot = Console.ReadLine();
                            }
                            int rep;


                            int choix;

                            while (true)
                            {
                                Console.WriteLine("Quelle cathegorie souhaitez-vous afficher ou modifier ?");
                                Console.WriteLine("1.Utilisateur\n2.Client\n3.Cuisinier\n4.Commande\n5.Statistique\n.6");
                                string entre = Console.ReadLine();
                                if (int.TryParse(entre, out choix) && choix >= 1 && choix <= 6)
                                {
                                    break;
                                }
                                Console.WriteLine("Entrée invalide. Veuillez choisir un numéro entre 1 et 6.");
                            }
                            switch (choix)
                            {
                                case 1:

                                    int rep2;
                                    while (true)
                                    {
                                        Console.WriteLine("Que souhaitez-vous faire?");
                                        Console.WriteLine("1.Creer un utilisateur\n2.Modifier un utilisateur\n3.supprier un utilisateur");
                                        string entre = Console.ReadLine();
                                        if (int.TryParse(entre, out rep2) && rep2 >= 1 && rep2 <= 3)
                                        {
                                            break;
                                        }
                                        Console.WriteLine("Entrée invalide. Veuillez choisir un numéro entre 1 et 3.");
                                    }

                                    switch (rep2)
                                    {
                                        case 1:
                                            Connexion.AjouterUtilisateur();

                                            break;
                                        case 2:
                                            Connexion.ModifierUtilisateur();
                                            break;
                                        case 3:
                                            Connexion.SupprimerUtilisateur();

                                            break;

                                    }
                                    break;

                                    break;
                                case 2:
                                    int rep3;
                                    while (true)
                                    {
                                        Console.WriteLine("Que souhaitez-vous faire?");
                                        Console.WriteLine("1.Creer un client\n2.Modifier un client\n3.supprier un client\n4. Afficher les clients par ordre alphabetique" +
                                            "\n5. Afficher les clients par rue\n6. Afficher les clients par montant des achats cumulés");
                                        string entre = Console.ReadLine();
                                        if (int.TryParse(entre, out rep3) && rep3 >= 1 && rep3 <= 6)
                                        {
                                            break;
                                        }
                                        Console.WriteLine("Entrée invalide. Veuillez choisir un numéro entre 1 et 6.");
                                    }
                                    switch (rep3)
                                    {
                                        case 1:
                                            Connexion.AjouterClientDepuisUtilisateurExistant();

                                            break;
                                        case 2:
                                            Connexion.ModifierClient();
                                            break;
                                        case 3:
                                            Connexion.SupprimerClient();

                                            break;
                                        case 4:
                                            Connexion.AfficherClientsOrdreAlphabetique();
                                            break;
                                        case 5:
                                            Connexion.AfficherClientsParRueEtNumero();
                                            break;
                                        case 6:
                                            Connexion.AfficherClientsParMontantCumule();
                                            break;

                                    }
                                    break;

                                    break;
                                case 4:
                                    int rep5;
                                    while (true)
                                    {
                                        Console.WriteLine("Que souhaitez-vous faire?");
                                        Console.WriteLine("1.Creer une commande\n2.Supprier une commande");
                                        string entre = Console.ReadLine();
                                        if (int.TryParse(entre, out rep5) && rep5 >= 1 && rep5 <= 2)
                                        {
                                            break;
                                        }
                                        Console.WriteLine("Entrée invalide. Veuillez choisir un numéro entre 1 et 2.");
                                    }

                                    switch (rep5)
                                    {
                                        case 1:
                                            Connexion.CreerCommandeAdmin();

                                            break;
                                        case 2:
                                            Connexion.SupprimerCommande();
                                            break;


                                    }
                                    break;
                                    break;
                                case 3:
                                case 5:

                                    Connexion.Affichage_statistiques();
                                    break;

                                    break;
                                    int rep4;
                                    while (true)
                                    {
                                        Console.WriteLine("Que souhaitez-vous faire?");
                                        Console.WriteLine("1.Creer un cuisinier\n2.Modifier un cuisinier\n3.supprier un cuisinier\n4.Affihcer les clients servis depuis son inscription" +
                                            "\n5.Afficher les clients servi sur une tranche de temps \n6.Affihcer les plats réalisés par fréquence");
                                        string entre = Console.ReadLine();
                                        if (int.TryParse(entre, out rep4) && rep4 >= 1 && rep4 <= 6)
                                        {
                                            break;
                                        }
                                        Console.WriteLine("Entrée invalide. Veuillez choisir un numéro entre 1 et 6.");
                                    }

                                    switch (rep4)
                                    {
                                        case 1:
                                            Connexion.AjouterCuisinierDepuisUtilisateurExistant();
                                            break;
                                        case 2:
                                            Connexion.ModifierCuisinier();
                                            break;
                                        case 3:
                                            Connexion.SupprimerCuisinier();
                                            break;

                                        case 4:
                                            Connexion.AfficherClientsServisParCuisinier();
                                            break;

                                        case 5:
                                            Connexion.AfficherPlatsDuCuisinierParPeriode();

                                            break;

                                        case 6:
                                            Connexion.AfficherPlatsParFrequencePourCuisinier();

                                            break;
                                    }
                                    break;
                                case 6:
                                    Connexion.Autre();
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
                                Console.WriteLine("Entrez votre ID utilisateur :");
                                int idUtilisateur;
                                while (!int.TryParse(Console.ReadLine(), out idUtilisateur))
                                {
                                    Console.WriteLine("ID invalide. Veuillez entrer un entier.");
                                }

                                Console.WriteLine("Entrez votre mot de passe :");
                                string motDePasse = Console.ReadLine();

                                if (Connexion.AuthentifierUtilisateur(idUtilisateur, motDePasse)==true)
                                {
                                    Console.WriteLine("Connexion réussie !");
                                    Console.WriteLine("Souhaitez-vous vous connecter en tant que :");
                                    Console.WriteLine("1. Client");
                                    Console.WriteLine("2. Cuisinier");

                                    int choixRole;
                                    while (!int.TryParse(Console.ReadLine(), out choixRole) || (choixRole != 1 && choixRole != 2))
                                    {
                                        Console.WriteLine("Choix invalide. Entrez 1 pour client ou 2 pour cuisinier.");
                                    }

                                    bool estValide = false;
                                    if (choixRole == 1)
                                    {
                                        estValide = Connexion.EstClient(idUtilisateur);
                                        if (estValide)
                                        {
                                            Console.WriteLine("Connexion en tant que client validée.");
                                            Console.WriteLine("Bienvenue client !");
                                            Connexion.AfficherPlatsDisponiblesAujourdHui();

                                            Console.WriteLine("Souhaitez-vous passer une commande ? (y/n)");
                                            string reponse2 = Console.ReadLine().Trim().ToLower();
                                            if (reponse2 == "y")
                                            {
                                                Connexion.PasserCommande(idUtilisateur);
                                               
                                            }
                                            Connexion.AfficherCommandesClient(idUtilisateur);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Vous n'avez pas de compte client.");
                                        }
                                    }
                                    else if (choixRole == 2)
                                    {
                                        estValide = Connexion.EstCuisinier(idUtilisateur);
                                        if (estValide)
                                        {
                                            Console.WriteLine("Connexion en tant que cuisinier validée.");
                                            Connexion.AfficherCommandesEnAttenteDuCuisinier(idUtilisateur);
                                            int idCommande = Connexion.ValidationCommandeParCuisinier(idUtilisateur);

                                            var (metroClient, metroCuisinier) = Connexion.Affichage_commande(idCommande);

                                            // Chercher les nœuds dans le graphe
                                            Noeud<Station> noeudClient = null;
                                            Noeud<Station> noeudCuisinier = null;

                                            foreach (var noeud in noeuds_temp)
                                            {
                                                if (noeudClient == null && noeud.Station.Nom_station.Equals(metroClient, StringComparison.OrdinalIgnoreCase))
                                                    noeudClient = noeud;

                                                if (noeudCuisinier == null && noeud.Station.Nom_station.Equals(metroCuisinier, StringComparison.OrdinalIgnoreCase))
                                                    noeudCuisinier = noeud;
                                            }

                                            if (noeudClient == null || noeudCuisinier == null)
                                            {
                                                Console.WriteLine("Erreur : station introuvable.");
                                            }
                                            else
                                            {
                                                var chemin = graphe.BellmanFord(noeudCuisinier, noeudClient, liens);

                                                if (chemin == null || chemin.Count == 0)
                                                {
                                                    Console.WriteLine("Aucun chemin trouvé avec Bellman-Ford.");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("\nItinéraire Bellman-Ford :");
                                                    foreach (var n in chemin)
                                                    {
                                                        Console.Write(n.Station.Nom_station + " → ");
                                                    }
                                                    Console.WriteLine("Client.");

                                                    var grapheChemin = Graphe<Station>.CreerGrapheDuChemin(chemin, liens);
                                                    if (grapheChemin != null)
                                                    {
                                                        GraphVisualizer visualizer2 = new GraphVisualizer(grapheChemin);
                                                        string nomImage = $"livraison_commande_{idCommande}.png";
                                                        visualizer2.GenererImage(nomImage);
                                                        visualizer2.AfficherImage(nomImage);
                                                    }
                                                }
                                            }
                                           
                                        }
                                        else
                                        {
                                            Console.WriteLine("Vous n'avez pas de compte cuisinier.");
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Échec de connexion. ID ou mot de passe incorrect.");
                                }



                                break;
                            case 2:
                                Console.WriteLine("Ajouter un utilisateur ! :");
                                int id_utilisateur = Connexion.AjouterUtilisateur();


                                Console.WriteLine("Souhaitez vous creer un compte client ? ");

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



                                Console.WriteLine("Souhaitez vous creer un compte cuisinier ? ");

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
                Console.WriteLine("\nSouhaitez-vous quitter ? (y/n)");
                string reponse = Console.ReadLine().Trim().ToLower();
                continuer = reponse != "y";
            }


          

        }

    }
}


