using MySql.Data.MySqlClient;
using Mysqlx.Prepare;
using MySqlX.XDevAPI;
using Org.BouncyCastle.Tls.Crypto;
using SkiaSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Net.Sockets;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Text.RegularExpressions;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;
using static Org.BouncyCastle.Bcpg.Attr.ImageAttrib;

namespace PSI
{

    public class PSI_Mysql_C_Data
    {
        private MySqlConnection maConnexion;

        private string mdp = "kakawete";
        /// <summary>
        /// Ouvre une connexion à la base et insère des données de test
        /// dans les tables utilisateur, cuisinier, plat, client, entreprise, recette, commande, transaction, livraison, etc.
        /// </summary>
        public void Peuplement()
        {

            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=LivInParis;" +
                                         "UID=root;PASSWORD=" + mdp;

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();

            }
            catch (MySqlException e)
            {
                Console.WriteLine("Erreur de connexion : " + e.Message);
            }

            string Peuplement = " INSERT INTO utilisateur (nom, prenom, email, mot_de_passe, telephone, numero_de_rue, rue, code_postal, ville, metro) " +
                "\r\nVALUES ('Bernorie', 'Louane', 'L.Bernorie@gmail.com', 'mdp123', '1234567891', 645, 'Rue Ribéra', 75016, 'Paris', 'Jasmin');" +
                "\r\nINSERT INTO utilisateur (nom, prenom, email, mot_de_passe, telephone, numero_de_rue, rue, code_postal, ville, metro) " +
                "\r\nVALUES ('Moripet', 'Victor', 'VictorMoripet@gmail.com', 'soleil654', '1234567892', 18, 'Rue des Volontaires', 75015, 'Paris', 'Volontaires');" +
                "\r\nINSERT INTO utilisateur (nom, prenom, email, mot_de_passe, telephone, numero_de_rue, rue, code_postal, ville, metro) " +
                "\r\nVALUES ('Cao', 'Lily', 'lilycao@gmail.com', 'passd123', '1234567893', 65, 'Avenue du Général Leclerc', 75014, 'Paris', 'Alésia');" +
                "\r\nINSERT INTO utilisateur (nom, prenom, email, mot_de_passe, telephone, numero_de_rue, rue, code_postal, ville, metro) " +
                "\r\nVALUES ('Cohen', 'Ruben', 'R.cohen05@gmail.com', 'word123', '1234567894', 6, 'Rue de la Pompe', 75016, 'Paris', 'La Muette');" +
                "\r\nINSERT INTO utilisateur (nom, prenom, email, mot_de_passe, telephone, numero_de_rue, rue, code_postal, ville, metro)" +
                " \r\nVALUES ('Petroni', 'Arthur', 'A.petroni@gmail.com', 'mdp588', '1234567895', 43, 'Rue Vavin', 75006, 'Paris', 'Vavin');" +
                "\r\nINSERT INTO utilisateur (nom, prenom, email, mot_de_passe, telephone, numero_de_rue, rue, code_postal, ville, metro) " +
                "\r\nVALUES ('Perez', 'Emilia', 'EmiliaP@gmail.com', 'password873', '1234567896', 7, 'Rue Clément', 75006, 'Paris', 'Mabillon');" +
                "\r\nINSERT INTO utilisateur (nom, prenom, email, mot_de_passe, telephone, numero_de_rue, rue, code_postal, ville, metro)" +
                " \r\nVALUES ('Dubar', 'Ludovic', 'ludo.dubar@gmail.com', 'chaise679', '1234567897', 3, 'Rue Lassus', 75019, 'Paris', 'Jourdain');" +
                "\r\nINSERT INTO utilisateur (nom, prenom, email, mot_de_passe, telephone, numero_de_rue, rue, code_postal, ville, metro)" +
                " \r\nVALUES ('Houlet', 'Pierre', 'PierreHoulet@gmail.com', 'sword614', '1234567898', 103, 'Rue Blanche', 75009, 'Paris', 'Blanche');" +
                "\r\nINSERT INTO utilisateur (nom, prenom, email, mot_de_passe, telephone, numero_de_rue, rue, code_postal, ville, metro)" +
                " \r\nVALUES ('Gouronne', 'Raphael', 'RaphGouronne@gmail.com', 'fleur546', '1234567899', 51, 'Rue de Rome', 75008, 'Paris', 'Europe');" +
                "\r\nINSERT INTO utilisateur (nom, prenom, email, mot_de_passe, telephone, numero_de_rue, rue, code_postal, ville, metro) " +
                "\r\nVALUES ('Dupond', 'Marie', 'Mdupond@gmail.com', 'password123', '1234567880', 30, 'Rue de la République', 75011, 'Paris', 'République');" +
                "\r\nINSERT INTO utilisateur (nom, prenom, email, mot_de_passe, telephone, numero_de_rue, rue, code_postal, ville, metro) " +
                "\r\nVALUES ('Durand', 'Medhy', 'Mdurand@gmail.com', 'password123', '1234567881', 15, 'Rue Cardinet', 75017, 'Paris', 'Cardinet');" +
                "\r\nINSERT INTO utilisateur (nom, prenom, email, mot_de_passe, telephone, numero_de_rue, rue, code_postal, ville, metro) " +
                "\r\nVALUES ('Chamy', 'Chloe', 'ChloeChamy@gmail.com', 'pass819', '1234567882', 1, 'Rue des Bauches', 75016, 'Paris', 'La Muette');" +
                "\r\nINSERT INTO utilisateur (nom, prenom, email, mot_de_passe, telephone, numero_de_rue, rue, code_postal, ville, metro) " +
                "\r\nVALUES ('lamoie', 'george', 'G.lam@gmail.com', 'momo99', '1234567883', 15, 'Rue Carrier-Belleuse', 75015, 'Paris', 'Cambronne');" +
                "\r\nINSERT INTO utilisateur (nom, prenom, email, mot_de_passe, telephone, numero_de_rue, rue, code_postal, ville, metro) " +
                "\r\nVALUES ('David', 'Camille', 'C.David@gmail.com', 'pop84', '123456784', 29, 'Rue Dussoubs', 75002, 'Paris', 'Sentier');" +
                "\r\n\r\nINSERT INTO utilisateur (nom, prenom, email, mot_de_passe, telephone, numero_de_rue, rue, code_postal, ville, metro) " +
                "\r\nVALUES ('Parvizi', 'Lianne', 'parvizi.lianne@gmail.com', 'hkjqdfjr', '123456785', 12, 'Rue de la Grange Batelière', 75009, 'Paris', 'Jourdain');" +
                "\r\nINSERT INTO utilisateur (nom, prenom, email, mot_de_passe, telephone, numero_de_rue, rue, code_postal, ville, metro) " +
                "\r\nVALUES ('Mouillet', 'Aude', 'aude.mouillet@gmail.com', 'chickenkfc', '123456786', 13, 'Rue Blanche', 75009, 'Paris', 'Blanche');" +
                "\r\nINSERT INTO utilisateur (nom, prenom, email, mot_de_passe, telephone, numero_de_rue, rue, code_postal, ville, metro) " +
                "\r\nVALUES ('Amouyal', 'Celia', 'celia.amouyal@gmail.com', 'fleurlilac', '123456787', 41, 'Rue de Rome', 75008, 'Paris', 'Europe');" +
                "\r\nINSERT INTO utilisateur (nom, prenom, email, mot_de_passe, telephone, numero_de_rue, rue, code_postal, ville, metro)" +
                " \r\nVALUES ('Kim', 'Jennie', 'jennie.kim@gmail.com', 'passwordblackpink', '123456788', 12, 'Rue de la République', 75011, 'Paris', 'République');" +
                "\r\nINSERT INTO utilisateur (nom, prenom, email, mot_de_passe, telephone, numero_de_rue, rue, code_postal, ville, metro) " +
                "\r\nVALUES ('Jeon', 'Jungkook', 'jungkook.jeon@gmail.com', 'passwordbts', '123456789', 5, 'Rue Cardinet', 75017, 'Paris', 'Cardinet');\r\n";
            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = Peuplement;
            try
            {
                command.ExecuteNonQuery();


            }
            catch (MySqlException e)
            {
                Console.WriteLine(" Peuplement echec : " + e.ToString());
                Console.ReadLine();
                return;
            }
            command.Dispose();

            string Peuplement_cuisinier = "INSERT INTO cuisinier (id_utilisateur, nb_etoile, avis_cuisinier)" +
               "\r\nVALUES (6, 3, 'Spécialiste en cuisine française')," +
               "(2, 5, 'Cuisinière renommée pour ses desserts')," +
               "(8, 4, 'Passionné de cuisine méditerranéenne')," +
               "(1, 2, 'Débutante mais prometteuse en cuisine contemporaine')," +
               " (9, 4, 'Expert en cuisine française, reconnu pour ses plats traditionnels.')" +
               ",(11, 5, 'Spécialiste des desserts et pâtisseries, innovant et créatif.')," +
               "(18, 3, 'Passionné de cuisine méditerranéenne, avec une touche de modernité.');";

            MySqlCommand command3 = maConnexion.CreateCommand();
            command3.CommandText = Peuplement_cuisinier;
            try
            {
                command3.ExecuteNonQuery();


            }
            catch (MySqlException e)
            {
                Console.WriteLine(" Peuplement cuisiniers echec : " + e.ToString());
                Console.ReadLine();
                return;
            }
            command3.Dispose();





            string Peuplement_plat = "INSERT INTO plat (nom_plat, prix, quantite, type_plat, date_fabrication, date_peremption, regime, origine, description_recette, id_cuisinier)" +
                "\r\nVALUES ('Raclette', 10.00, 6, 'plat', '2025-05-02', '2025-05-15', 'Française', 'France', 'raclette, pommes de terre, jambon, cornichon', 1), " +
                "\r\n('Salade de fruits', 5.00, 6, 'dessert', '2025-05-01', '2025-05-09', 'Végétarien', 'Indifférent', 'fraise, kiwi, sucre', 1),\r\n" +
                "('Pizza Margherita', 8.50, 10, 'plat', '2025-02-01', '2025-02-05', 'Italienne', 'Italie', 'pâte, sauce tomate, mozzarella, basilic', 2)," +
                "\r\n('Boeuf Bourguignon', 12.00, 5, 'plat', '2025-02-02', '2025-02-10', 'Française', 'France', 'bœuf, vin rouge, champignons, carottes, oignons', 3)," +
                "\r\n('Tarte aux pommes', 6.00, 8, 'dessert', '2021-02-03', '2021-02-07', 'Végétarien', 'France', 'pommes, pâte brisée, cannelle, sucre', 1)," +
                "\r\n('Quiche Lorraine', 7.50, 7, 'plat', '2025-02-04', '2025-02-08', 'Française', 'France', 'pâte, lardons, crème, œufs, fromage', 2)," +
                "\r\n('Crème brûlée', 5.50, 10, 'dessert', '2025-02-05', '2025-02-12', 'Végétarien', 'France', 'crème, sucre, œufs, vanille', 3)," +
                "\r\n('Sushi', 12.00, 8, 'plat', '2025-03-10', '2025-03-15', 'Pescetarien', 'Japon', 'riz, poisson cru, algues, wasabi', 4)," +
                "\r\n('Ratatouille', 9.00, 10, 'plat', '2020-03-12', '2020-03-18', 'Végétarien', 'France', 'aubergine, courgette, tomate, poivron, herbes de Provence', 2)," +
                "\r\n('Falafel', 7.00, 12, 'plat', '2025-03-11', '2025-03-17', 'Végétarien', 'Moyen-Orient', 'pois chiches, épices, tahini, pita', 5)," +
                "\r\n('Tacos', 8.00, 9, 'plat', '2025-03-13', '2025-03-20', 'Omnivore', 'Mexique', 'tortilla, viande assaisonnée, salsa, fromage, guacamole', 3)," +
                "\r\n('Panna Cotta', 6.50, 8, 'dessert', '2022-03-14', '2022-03-21', 'Végétarien', 'Italie', 'crème, sucre, gélatine, vanille, coulis de fruits', 4)," +
                "\r\n('Biryani', 11.00, 6, 'plat', '2025-03-15', '2025-03-22', 'Omnivore', 'Inde', 'riz, épices, poulet, yaourt, coriandre', 6)," +
                "\r\n('Pad Thaï', 10.50, 7, 'plat', '2025-03-16', '2025-03-23', 'Omnivore', 'Thaïlande', 'nouilles de riz, crevettes, tofu, cacahuètes, citron vert', 5)," +
                "\r\n('Baklava', 5.00, 10, 'dessert', '2025-03-17', '2025-03-24', 'Végétarien', 'Turquie', 'pâte filo, noix, miel, sirop', 7)," +
                "\r\n('Ceviche', 13.00, 5, 'plat', '2025-03-18', '2025-03-25', 'Pescetarien', 'Pérou', 'poisson cru, citron vert, oignon, coriandre, piment', 4)," +
                "\r\n('Goulash', 9.50, 8, 'plat', '2025-04-28', '2025-05-12', 'Omnivore', 'Hongrie', 'bœuf, paprika, oignon, tomate, bouillon', 3);";

            MySqlCommand command2 = maConnexion.CreateCommand();
            command2.CommandText = Peuplement_plat;
            try
            {
                command2.ExecuteNonQuery();


            }
            catch (MySqlException e)
            {
                Console.WriteLine(" Peuplement plats echec : " + e.ToString());
                Console.ReadLine();
                return;
            }
            command2.Dispose();







            string Peuplement_clients = "INSERT INTO client (id_utilisateur, type_client)" +
               "\r\nVALUES (12, 'particulier'),(3,'particulier'),(4,'entreprise'),(5,'particulier'),(7,'particulier'),(10,'entreprise'),(13,'particulier'),(14,'particulier'),(15,'particulier')," +
               "(16,'entreprise'),(17,'particulier'),(19,'entreprise');";
            MySqlCommand command4 = maConnexion.CreateCommand();
            command4.CommandText = Peuplement_clients;
            try
            {
                command4.ExecuteNonQuery();


            }
            catch (MySqlException e)
            {
                Console.WriteLine(" Peuplement clients echec : " + e.ToString());
                Console.ReadLine();
                return;
            }
            command4.Dispose();


            string Peuplement_entreprise = "INSERT INTO entreprise (nom_entreprise, nom_referent, id_client)" +
               "\r\nVALUES ('Acme Corporation', 'Ruben Cohen', 3)," +
               "\r\n('Tech Innovators', 'Marie Dupond', 6)," +
               "\r\n('Green Solutions', 'Aude Mouillet', 10)," +
               "\r\n('Future Systems', 'Jeon Jungkook', 12);";



            MySqlCommand command5 = maConnexion.CreateCommand();
            command5.CommandText = Peuplement_entreprise;
            try
            {
                command5.ExecuteNonQuery();


            }
            catch (MySqlException e)
            {
                Console.WriteLine(" Peuplement entreprise echec : " + e.ToString());
                Console.ReadLine();
                return;
            }
            command5.Dispose();


            string Peuplement_recette = "INSERT INTO recette (nom_recette, description_recette, date_creation, id_cuisinier, id_recette_origine) VALUES" +
            "('Raclette', 'Recette pour Raclette : raclette, pommes de terre, jambon, cornichon', '2025-01-09 08:00:00', 1, NULL)," +
            "('Salade de fruits', 'Recette pour Salade de fruits : fraise, kiwi, sucre', '2025-01-09 09:00:00', 1, NULL)," +
            "('Pizza Margherita', 'Recette pour Pizza Margherita : pâte, sauce tomate, mozzarella, basilic', '2025-01-31 12:00:00', 2, NULL)," +
            "('Boeuf Bourguignon', 'Recette pour Boeuf Bourguignon : bœuf, vin rouge, champignons, carottes, oignons', '2025-02-01 14:00:00', 3, NULL)," +
            "('Tarte aux pommes', 'Recette pour Tarte aux pommes : pommes, pâte brisée, cannelle, sucre', '2025-02-02 16:00:00', 1, NULL)," +
            "('Quiche Lorraine', 'Recette pour Quiche Lorraine : pâte, lardons, crème, œufs, fromage', '2025-02-03 11:00:00', 2, NULL)," +
            "('Crème brûlée', 'Recette pour Crème brûlée : crème, sucre, œufs, vanille', '2025-02-04 17:00:00', 3, NULL)," +
            "('Sushi', 'Recette pour Sushi : riz, poisson cru, algues, wasabi', '2025-03-09 13:00:00', 4, NULL)," +
            "('Ratatouille', 'Recette pour Ratatouille : aubergine, courgette, tomate, poivron, herbes de Provence', '2025-03-10 12:00:00', 2, NULL)," +
            "('Falafel', 'Recette pour Falafel : pois chiches, épices, tahini, pita', '2025-03-10 14:00:00', 5, NULL)," +
            "('Tacos', 'Recette pour Tacos : tortilla, viande assaisonnée, salsa, fromage, guacamole', '2025-03-11 15:00:00', 3, NULL)," +
            "('Panna Cotta', 'Recette pour Panna Cotta : crème, sucre, gélatine, vanille, coulis de fruits', '2025-03-12 10:00:00', 4, NULL)," +
            "('Biryani', 'Recette pour Biryani : riz, épices, poulet, yaourt, coriandre', '2025-03-13 12:00:00', 6, NULL)," +
            "('Pad Thaï', 'Recette pour Pad Thaï : nouilles de riz, crevettes, tofu, cacahuètes, citron vert', '2025-03-14 14:00:00', 5, NULL)," +
            "('Baklava', 'Recette pour Baklava : pâte filo, noix, miel, sirop', '2025-03-15 16:00:00', 7, NULL)," +
            "('Ceviche', 'Recette pour Ceviche : poisson cru, citron vert, oignon, coriandre, piment', '2025-03-16 18:00:00', 4, NULL)," +
            "('Goulash', 'Recette pour Goulash : bœuf, paprika, oignon, tomate, bouillon', '2025-03-17 20:00:00', 3, NULL); ";
            MySqlCommand command6 = maConnexion.CreateCommand();
            command6.CommandText = Peuplement_recette;
            try
            {
                command6.ExecuteNonQuery();


            }
            catch (MySqlException e)
            {
                Console.WriteLine(" Peuplement recette echec : " + e.ToString());
                Console.ReadLine();
                return;
            }
            command6.Dispose();

            string Peuplement_commande = "INSERT INTO commande (id_cuisinier, id_client,statut,date_commande, id_plat)" +
               "\r\nVALUES (1, 6,'validée','2020-03-05 08:15:54',8),(2, 7,'validée','2021-06-09 17:54:21',7),(3, 8,'validée','2025-01-18 21:16:04',2), (1, 9,'validée','2024-12-26 09:04:43',4),(2, 10,'validée','2024-10-14 16:31:57',11);";
            MySqlCommand command7 = maConnexion.CreateCommand();
            command7.CommandText = Peuplement_commande;
            try
            {
                command7.ExecuteNonQuery();


            }
            catch (MySqlException e)
            {
                Console.WriteLine(" Peuplement commande echec : " + e.ToString());
                Console.ReadLine();
                return;
            }
            command7.Dispose();


            string Peuplement_transaction = "INSERT INTO transaction (montant_total, date_paiement, moyen_paiement)" +
               "\r\nVALUES (45.50, '2025-04-01 14:30:00', 'carte bancaire');" +
               "\r\n\r\nINSERT INTO transaction (montant_total, date_paiement, moyen_paiement)" +
               "\r\nVALUES (30.00, '2025-04-02 10:15:00', 'especes');" +
               "\r\n\r\nINSERT INTO transaction (montant_total, date_paiement, moyen_paiement)" +
               "\r\nVALUES (55.75, '2025-04-03 18:45:00', 'carte bancaire');" +
               "\r\n\r\nINSERT INTO transaction (montant_total, date_paiement, moyen_paiement)" +
               "\r\nVALUES (22.00, '2025-04-04 12:00:00', 'especes');" +
               "\r\n\r\nINSERT INTO transaction (montant_total, date_paiement, moyen_paiement)" +
               "\r\nVALUES (60.00, '2025-04-05 20:30:00', 'carte bancaire');";

            MySqlCommand command8 = maConnexion.CreateCommand();
            command8.CommandText = Peuplement_transaction;
            try
            {
                command8.ExecuteNonQuery();


            }
            catch (MySqlException e)
            {
                Console.WriteLine(" Peuplement transaction echec : " + e.ToString());
                Console.ReadLine();
                return;
            }
            command8.Dispose();


            string Peuplement_livraison = "INSERT INTO livraison (id_cuisinier, date_livraison, zone_livraison)" +
                "\r\nVALUES (1, '2025-04-10', 'Paris 17');\r\n\r\nINSERT INTO livraison (id_cuisinier, date_livraison, zone_livraison)" +
                "\r\nVALUES (2, '2025-04-11', 'Paris 18');\r\n";

            MySqlCommand command9 = maConnexion.CreateCommand();
            command9.CommandText = Peuplement_livraison;
            try
            {
                command9.ExecuteNonQuery();

            }
            catch (MySqlException e)
            {
                Console.WriteLine(" Peuplement livraison echec : " + e.ToString());
                Console.ReadLine();
                return;
            }
            command9.Dispose();

            string Peuplement_transaction_commande = "INSERT INTO transaction_commande (id_transaction, id_commande)" +
               "\r\nVALUES (1, 1);" +
               "\r\n\r\nINSERT INTO transaction_commande (id_transaction, id_commande)" +
               "\r\nVALUES (2, 2);";

            MySqlCommand command10 = maConnexion.CreateCommand();
            command10.CommandText = Peuplement_transaction_commande;
            try
            {
                command10.ExecuteNonQuery();


            }
            catch (MySqlException e)
            {
                Console.WriteLine(" Peuplement transaction_commande echec : " + e.ToString());
                Console.ReadLine();
                return;
            }
            command10.Dispose();

            string Peuplement_livraison_commande = "INSERT INTO livraison_commande (id_livraison, id_commande)" +
               "\r\nVALUES (1, 1);" +
               "\r\n\r\nINSERT INTO livraison_commande (id_livraison, id_commande)" +
               "\r\nVALUES (2, 2);";

            MySqlCommand command11 = maConnexion.CreateCommand();
            command11.CommandText = Peuplement_livraison_commande;
            try
            {
                command11.ExecuteNonQuery();


            }
            catch (MySqlException e)
            {
                Console.WriteLine(" Peuplement livraison_commande echec : " + e.ToString());
                Console.ReadLine();
                return;
            }
            command11.Dispose();
        }

        public void Affichage_client()
        {

            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=LivInParis;" +
                                         "UID=root;PASSWORD=" + mdp;

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();

            }
            catch (MySqlException e)
            {
                Console.WriteLine("Erreur de connexion : " + e.Message);
            }


            Console.WriteLine("Liste des clients par ordre alphabetique et de rue ");
            string Affichage_client = "SELECT * FROM utilisateur join client on utilisateur.id_utilisateur where " +
                "client.id_utilisateur = utilisateur.id_utilisateur ORDER BY nom ASC, prenom , numero_de_rue ASC;";


            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = Affichage_client;
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                try
                {
                    int idClient = Convert.ToInt32(reader["id_client"]);
                    int idUtilisateur = Convert.ToInt32(reader["id_utilisateur"]);
                    string typeClient = reader["type_client"].ToString();
                    string nom = reader["nom"].ToString();
                    string prenom = reader["prenom"].ToString();
                    string email = reader["email"].ToString();
                    string motDePasse = reader["mot_de_passe"].ToString();
                    string telephone = reader["telephone"].ToString();
                    int numeroDeRue = Convert.ToInt32(reader["numero_de_rue"]);
                    string rue = reader["rue"].ToString();
                    int codePostal = Convert.ToInt32(reader["code_postal"]);
                    string ville = reader["ville"].ToString();
                    string metro = reader["metro"].ToString();

                    Console.WriteLine($"ID Client: {idClient},\nID Utilisateur: {idUtilisateur},\nType Client: {typeClient},\nNom: {nom},\nPrénom: {prenom},\nEmail: {email},\nMot de passe: {motDePasse},\nTéléphone: {telephone},\nNuméro de rue: {numeroDeRue},\nRue: {rue},\nCode Postal: {codePostal},\nVille: {ville},\nMétro: {metro}");
                    Console.WriteLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur lors de la lecture d'une colonne : " + ex.Message);
                }

            }
            reader.Close();

            Console.WriteLine();
            Console.WriteLine("Clients triés par montant cumulé");

            MySqlCommand command1 = maConnexion.CreateCommand();
            command1.CommandText = " SELECT cl.id_client, u.nom,  u.prenom, SUM(t.montant_total) AS montant_cumul FROM client cl " +
                "JOIN utilisateur u ON cl.id_utilisateur = u.id_utilisateur JOIN commande c ON cl.id_client = c.id_client " +
                "JOIN transaction_commande tc ON c.id_commande = tc.id_commande JOIN transaction t ON tc.id_transaction = t.id_transaction " +
                "GROUP BY cl.id_client, u.nom, u.prenom ORDER BY montant_cumul DESC;";

            MySqlDataReader reader0 = command1.ExecuteReader();
            while (reader0.Read())
            {
                try
                {
                    int idClient = Convert.ToInt32(reader0["id_client"]);
                    string nom = reader0["nom"].ToString();
                    string prenom = reader0["prenom"].ToString();
                    decimal montantCumule = Convert.ToDecimal(reader0["montant_cumul"]);
                    Console.WriteLine($"ID Client: {idClient}, Nom: {nom}, Prénom: {prenom}, Montant Cumulé: {montantCumule}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur lors de la lecture d'une colonne : " + ex.Message);
                }
            }
            reader0.Close();
            Console.WriteLine();


            if (maConnexion != null && maConnexion.State == System.Data.ConnectionState.Open)
            {
                maConnexion.Close();

            }

        }

        public void Affichage_cuisinier()
        {
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=LivInParis;" +
                                         "UID=root;PASSWORD=" + mdp;

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();

            }
            catch (MySqlException e)
            {
                Console.WriteLine("Erreur de connexion : " + e.Message);

            }
            MySqlCommand command12 = maConnexion.CreateCommand();


            int id;
            while (true)
            {
                Console.WriteLine("Donnez l'id du cuisinier :");
                string identree = Console.ReadLine();
                if (!int.TryParse(identree, out id))
                {
                    Console.WriteLine("Erreur : l'id doit être un entier. Veuillez réessayer.");
                    continue;
                }

                MySqlCommand cmdCheck = new MySqlCommand("SELECT COUNT(*) FROM cuisinier WHERE id_cuisinier = @id", maConnexion);
                cmdCheck.Parameters.AddWithValue("@id", id);
                int count = Convert.ToInt32(cmdCheck.ExecuteScalar());
                if (count == 0)
                {
                    Console.WriteLine("Il n'y a pas de cuisiniers enregistrés sous cet id. Veuillez réessayer.");
                    continue;
                }
                break;
            }



            command12.CommandText = "SELECT DISTINCT u.id_utilisateur AS id_utilisateur, u.nom AS nom, u.prenom AS prenom, u.email AS email " +
                           "FROM commande c " +
                           "JOIN client cl ON c.id_client = cl.id_client " +
                           "JOIN utilisateur u ON cl.id_utilisateur = u.id_utilisateur " +
                           "WHERE c.id_cuisinier = " + id;
            Console.WriteLine("les clients que le cuisinier " + id + " a pu servir depuis son inscription à la plateforme");
            MySqlDataReader reader = command12.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    int idUtilisateur = Convert.ToInt32(reader["id_utilisateur"]);
                    string nom = reader["nom"].ToString();
                    string prenom = reader["prenom"].ToString();
                    string email = reader["email"].ToString();
                    Console.WriteLine($"ID: {idUtilisateur}, Nom: {nom}, Prénom: {prenom}, Email: {email}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur lors de la lecture d'une colonne : " + ex.Message);
                }
            }

            reader.Close();
            Console.WriteLine();


            DateTime date;
            while (true)
            {
                Console.WriteLine("Depuis quand voulez - vous savoir les plats que le cuisinier a préparé ? sous le format AAAA - MM - JJ HH: MM:SS");
                string entree = Console.ReadLine();
                if (DateTime.TryParseExact(entree, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                {
                    break;
                }
                Console.WriteLine("Erreur: le format de la date n'est pas correct. Veuillez respecter le format AAAA-MM-JJ HH:MM:SS.");
            }


            Console.WriteLine("les clients que le cuisinier " + id + " a pu servir depuis le " + Convert.ToString(date));
            MySqlCommand command13 = maConnexion.CreateCommand();
            command13.CommandText = "SELECT DISTINCT u.id_utilisateur, u.nom, u.prenom, u.email " +
                "FROM commande c JOIN client cl ON c.id_client = cl.id_client JOIN utilisateur u" +
                " ON cl.id_utilisateur = u.id_utilisateur WHERE c.id_cuisinier =  " + id +
                " AND c.date_commande BETWEEN '" + date + "' AND CURDATE(); ";

            MySqlDataReader reader1 = command13.ExecuteReader();
            while (reader1.Read())
            {
                try
                {
                    int idUtilisateur = Convert.ToInt32(reader1["id_utilisateur"]);
                    string nom = reader1["nom"].ToString();
                    string prenom = reader1["prenom"].ToString();
                    string email = reader1["email"].ToString();
                    Console.WriteLine($"ID: {idUtilisateur}, Nom: {nom}, Prénom: {prenom}, Email: {email}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur lors de la lecture d'une colonne : " + ex.Message);
                }
            }

            reader1.Close();
            Console.WriteLine();


            Console.WriteLine("Plat par fréquence");

            string query = "SELECT p.id_cuisinier,p.nom_plat,COUNT(*) AS dish_count,(COUNT(*) / total.total_count * 1.0) AS frequency_ratio FROM plat p " +
                "JOIN ( SELECT id_cuisinier, COUNT(*) AS total_count FROM plat GROUP BY id_cuisinier) total ON p.id_cuisinier = total.id_cuisinier " +
                "GROUP BY p.id_cuisinier, p.nom_plat, total.total_count ORDER BY p.id_cuisinier, frequency_ratio DESC;";

            MySqlCommand command = new MySqlCommand(query, maConnexion);
            MySqlDataReader reader4 = command.ExecuteReader();

            while (reader4.Read())
            {
                try
                {
                    int idCuisinier = Convert.ToInt32(reader4["id_cuisinier"]);
                    string nomPlat = reader4["nom_plat"].ToString();
                    int dishCount = Convert.ToInt32(reader4["dish_count"]);
                    decimal frequencyRatio = Convert.ToDecimal(reader4["frequency_ratio"]);

                    Console.WriteLine($"Cuisinier ID: {idCuisinier}, Plat: {nomPlat}, Effectif: {dishCount}, Fréquence: {frequencyRatio:P}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur lors de la lecture d'une colonne : " + ex.Message);
                }
            }
            reader4.Close();


            if (maConnexion != null && maConnexion.State == System.Data.ConnectionState.Open)
            {
                maConnexion.Close();

            }
        }


        /// <summary>
        /// Affiche des statistiques globales :
        /// - Nombre de livraisons par cuisinier
        /// - Commandes dans une période
        /// - Moyenne des prix des commandes
        /// - Moyenne des commandes par client
        /// - Commandes d’un client par origine de plat et période
        /// </summary>
        public void Affichage_statistiques()
        {
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=LivInParis;" +
                                         "UID=root;PASSWORD=" + mdp;

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
                Console.WriteLine("Connexion réussie.");
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Erreur de connexion : " + e.Message);
            }

            Console.WriteLine(" le nombre de livraisons effectuées par cuisinier");
            string requete = "SELECT id_cuisinier, COUNT(*) AS nb_livraisons FROM livraison GROUP BY id_cuisinier;";

            MySqlCommand cmdLivraison = new MySqlCommand(requete, maConnexion);
            MySqlDataReader readerLivraison = cmdLivraison.ExecuteReader();

            while (readerLivraison.Read())
            {
                try
                {
                    int idCuisinier = Convert.ToInt32(readerLivraison["id_cuisinier"]);
                    int nbLivraisons = Convert.ToInt32(readerLivraison["nb_livraisons"]);
                    Console.WriteLine($"Cuisinier {idCuisinier} a effectué {nbLivraisons} livraisons.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur lors de la lecture d'une colonne : " + ex.Message);
                }
            }
            readerLivraison.Close();

            Console.WriteLine();


            Console.WriteLine(" les commandes selon une période de temps");




            DateTime date1;
            while (true)
            {
                Console.WriteLine("La premiere date de la periode ? sous le format AAAA-MM-JJ HH:MM:SS");
                string entree = Console.ReadLine();
                if (DateTime.TryParseExact(entree, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out date1))
                {
                    break;
                }
                Console.WriteLine("Erreur: le format de la date n'est pas correct. Veuillez respecter le format AAAA-MM-JJ HH:MM:SS.");
            }

            DateTime date2;
            while (true)
            {
                Console.WriteLine("La deuxieme date de la periode ? sous le format AAAA-MM-JJ HH:MM:SS");
                string entree = Console.ReadLine();
                if (DateTime.TryParseExact(entree, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out date2))
                {
                    break;
                }
                Console.WriteLine("Erreur: le format de la date n'est pas correct. Veuillez respecter le format AAAA-MM-JJ HH:MM:SS.");
            }



            string requeteCommande = @" SELECT * FROM commande WHERE date_commande BETWEEN @date1 AND @date2 ORDER BY date_commande;";

            using (MySqlCommand cmdCommande = new MySqlCommand(requeteCommande, maConnexion))
            {
                cmdCommande.Parameters.Add("@date1", MySqlDbType.DateTime).Value = date1;
                cmdCommande.Parameters.Add("@date2", MySqlDbType.DateTime).Value = date2;

                using (MySqlDataReader readerCommande = cmdCommande.ExecuteReader())
                {
                    while (readerCommande.Read())
                    {
                        try
                        {
                            int idCommande = Convert.ToInt32(readerCommande["id_commande"]);
                            int idCuisinier = Convert.ToInt32(readerCommande["id_cuisinier"]);
                            int idClient = Convert.ToInt32(readerCommande["id_client"]);
                            DateTime dateCommande = Convert.ToDateTime(readerCommande["date_commande"]);

                            Console.WriteLine($"Commande {idCommande}: Cuisinier {idCuisinier}, Client {idClient}, Date {dateCommande}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Erreur lors de la lecture d'une colonne : " + ex.Message);
                        }
                    }
                }
            }

            Console.WriteLine();



            string requeteMoyennePrix = " SELECT AVG(t.montant_total) AS moyenne_prix FROM commande c JOIN transaction_commande tc ON c.id_commande = tc.id_commande JOIN `transaction` t ON tc.id_transaction = t.id_transaction;";

            using (MySqlCommand cmdMoyennePrix = new MySqlCommand(requeteMoyennePrix, maConnexion))
            {
                object resultPrix = cmdMoyennePrix.ExecuteScalar();
                if (resultPrix != null && resultPrix != DBNull.Value)
                {
                    decimal moyennePrix = Convert.ToDecimal(resultPrix);
                    Console.WriteLine($"La moyenne des prix des commandes est : {moyennePrix}");
                }
                else
                {
                    Console.WriteLine("Aucune donnée disponible pour calculer la moyenne.");
                }
            }
            Console.WriteLine();

            Console.WriteLine("moyenne des comptes clients :");
            string queryMoyenneCommandes = @"SELECT AVG(nb_commandes) AS moyenne_commandes FROM (SELECT id_client, COUNT(*) AS nb_commandes FROM commande GROUP BY id_client) AS sub;";

            MySqlCommand cmdMoyenneCommandes = new MySqlCommand(queryMoyenneCommandes, maConnexion);
            object resultMoyenne = cmdMoyenneCommandes.ExecuteScalar();
            if (resultMoyenne != null)
            {
                decimal moyenneCommandes = Convert.ToDecimal(resultMoyenne);
                Console.WriteLine($"La moyenne des commandes par client est : {moyenneCommandes}");
            }
            Console.WriteLine();


            Console.WriteLine(" liste des commandes pour un client selon la nationalité des plats, la période ");
            int id;
            while (true)
            {
                Console.WriteLine("Donnez l'id du client :");
                string identree = Console.ReadLine();
                if (!int.TryParse(identree, out id))
                {
                    Console.WriteLine("Erreur : l'id doit être un entier. Veuillez réessayer.");
                    continue;
                }

                MySqlCommand cmdCheck = new MySqlCommand("SELECT COUNT(*) FROM client WHERE id_client = @id", maConnexion);
                cmdCheck.Parameters.AddWithValue("@id", id);
                int count = Convert.ToInt32(cmdCheck.ExecuteScalar());
                if (count == 0)
                {
                    Console.WriteLine("Il n'y a pas de client enregistrés sous cet id. Veuillez réessayer.");
                    continue;
                }
                break;
            }


            DateTime date3;
            while (true)
            {
                Console.WriteLine("La premiere date de la periode ? sous le format AAAA-MM-JJ HH:MM:SS");
                string entree = Console.ReadLine();
                if (DateTime.TryParseExact(entree, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out date3))
                {
                    break;
                }
                Console.WriteLine("Erreur: le format de la date n'est pas correct. Veuillez respecter le format AAAA-MM-JJ HH:MM:SS.");
            }

            DateTime date4;
            while (true)
            {
                Console.WriteLine("La deuxieme date de la periode ? sous le format AAAA-MM-JJ HH:MM:SS");
                string entree = Console.ReadLine();
                if (DateTime.TryParseExact(entree, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out date4))
                {
                    break;
                }
                Console.WriteLine("Erreur: le format de la date n'est pas correct. Veuillez respecter le format AAAA-MM-JJ HH:MM:SS.");
            }


            string nationalite;
            while (true)
            {
                Console.WriteLine("Veuillez entrer la nationalité du plat que vous demandez :");
                nationalite = Console.ReadLine().Trim();
                if (!string.IsNullOrEmpty(nationalite))
                {
                    break;
                }
                Console.WriteLine("Erreur : la nationalité ne peut pas être vide. Veuillez réessayer.");
            }

            string queryCommandesClient = @"SELECT DISTINCT c.id_commande, c.date_commande, cl.id_client, 
                                                   u.nom AS nom_client, u.prenom AS prenom_client, p.origine 
                                            FROM commande c
                                            JOIN client cl ON c.id_client = cl.id_client 
                                            JOIN utilisateur u ON cl.id_utilisateur = u.id_utilisateur 
                                            JOIN plat p ON c.id_cuisinier = p.id_cuisinier 
                                            WHERE cl.id_client = @clientId 
                                            AND c.date_commande BETWEEN @date3 AND @date4 
                                            AND p.origine = @nationalite 
                                            ORDER BY c.date_commande;";

            MySqlCommand cmdCommandesClient = new MySqlCommand(queryCommandesClient, maConnexion);
            cmdCommandesClient.Parameters.AddWithValue("@clientId", id);
            cmdCommandesClient.Parameters.AddWithValue("@date3", date3);
            cmdCommandesClient.Parameters.AddWithValue("@date4", date4);
            cmdCommandesClient.Parameters.AddWithValue("@nationalite", nationalite);

            MySqlDataReader readerCommandes = cmdCommandesClient.ExecuteReader();

            if (!readerCommandes.HasRows)
            {
                Console.WriteLine("Aucune commande trouvée pour le client {0} avec des plats d'origine '{1}' entre {2} et {3}.",
                                  id, nationalite, date3.ToString("yyyy-MM-dd HH:mm:ss"), date4.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            else
            {
                while (readerCommandes.Read())
                {
                    try
                    {
                        int idCommande = Convert.ToInt32(readerCommandes["id_commande"]);
                        DateTime dateCommande = Convert.ToDateTime(readerCommandes["date_commande"]);
                        int idClient = Convert.ToInt32(readerCommandes["id_client"]);
                        string nomClient = readerCommandes["nom_client"].ToString();
                        string prenomClient = readerCommandes["prenom_client"].ToString();
                        string origine = readerCommandes["origine"].ToString();

                        Console.WriteLine("Commande {0} pour le client {1} {2} (ID: {3}) le {4:d}, Plat d'origine: {5}",
                                          idCommande, nomClient, prenomClient, idClient, dateCommande, origine);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Erreur lors de la lecture d'une colonne : " + ex.Message);
                    }
                }
            }
            readerCommandes.Close();





            if (maConnexion != null && maConnexion.State == System.Data.ConnectionState.Open)
            {
                maConnexion.Close();

            }
            Console.WriteLine();
        }


        public (string metroClient, string metroCuisinier) Affichage_commande(int idCommande)
        {
            string metro1 = "", metro2 = "";
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;DATABASE=LivInParis;UID=root;PASSWORD=" + mdp;
                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();

                // Récupérer métro client
                string queryClient = @"SELECT metro FROM utilisateur WHERE id_utilisateur = (
                                  SELECT id_utilisateur FROM client WHERE id_client = (
                                      SELECT id_client FROM commande WHERE id_commande = @id))";
                MySqlCommand cmd1 = new MySqlCommand(queryClient, maConnexion);
                cmd1.Parameters.AddWithValue("@id", idCommande);
                metro1 = cmd1.ExecuteScalar()?.ToString();

                // Récupérer métro cuisinier
                string queryCuisinier = @"SELECT metro FROM utilisateur WHERE id_utilisateur = (
                                      SELECT id_utilisateur FROM cuisinier WHERE id_cuisinier = (
                                          SELECT id_cuisinier FROM commande WHERE id_commande = @id))";
                MySqlCommand cmd2 = new MySqlCommand(queryCuisinier, maConnexion);
                cmd2.Parameters.AddWithValue("@id", idCommande);
                metro2 = cmd2.ExecuteScalar()?.ToString();

                maConnexion.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur : " + ex.Message);
            }

            return (metro1, metro2);
        }


        public void Autre()
        {
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=LivInParis;" +
                                         "UID=root;PASSWORD=" + mdp;

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
                Console.WriteLine("Connexion réussie.");
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Erreur de connexion : " + e.Message);
                return;
            }


            Console.WriteLine("\nClient ayant dépensé le plus gros montant en une commande :");
            string ajout =
                "SELECT utilisateur.prenom, transaction.montant_total " +
                "FROM transaction " +
                "JOIN transaction_commande ON transaction_commande.id_transaction = transaction.id_transaction " +
                "JOIN commande ON transaction_commande.id_commande = commande.id_commande " +
                "JOIN client ON commande.id_client = client.id_client " +
                "JOIN utilisateur ON utilisateur.id_utilisateur = client.id_utilisateur " +
                "WHERE transaction.montant_total = (SELECT MAX(montant_total) FROM transaction);";

            MySqlCommand command = new MySqlCommand(ajout, maConnexion);
            try
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string prenom = reader.GetString("prenom");
                        decimal montant = reader.GetDecimal("montant_total");
                        Console.WriteLine($"Prenom : {prenom}, Montant total : {montant} €");
                    }
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Erreur : " + e.Message);
            }


            Console.WriteLine("\nListe des plats végétariens disponibles :");
            string ajout2 = "SELECT nom_plat FROM plat WHERE regime='Végétarien';";
            MySqlCommand command2 = new MySqlCommand(ajout2, maConnexion);
            try
            {
                using (MySqlDataReader reader = command2.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string nomPlat = reader.GetString("nom_plat");
                        Console.WriteLine($"- {nomPlat}");
                    }
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Erreur : " + e.Message);
            }


            Console.WriteLine("\nListe des cuisiniers sur Paris :");
            string ajout3 =
                "SELECT cuisinier.id_cuisinier, utilisateur.prenom " +
                "FROM cuisinier " +
                "JOIN utilisateur ON utilisateur.id_utilisateur = cuisinier.id_utilisateur " +
                "WHERE utilisateur.ville = 'Paris';";
            MySqlCommand command3 = new MySqlCommand(ajout3, maConnexion);
            try
            {
                using (MySqlDataReader reader = command3.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int idCuisinier = reader.GetInt32("id_cuisinier");
                        string prenom = reader.GetString("prenom");
                        Console.WriteLine($"Cuisinier #{idCuisinier} : {prenom}");
                    }
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Erreur : " + e.Message);
            }


            Console.WriteLine("\nLivraisons allant à Paris 17 :");
            string ajout4 = "SELECT id_livraison FROM livraison WHERE zone_livraison='Paris 17';";
            MySqlCommand command4 = new MySqlCommand(ajout4, maConnexion);
            try
            {
                using (MySqlDataReader reader = command4.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int idLivraison = reader.GetInt32("id_livraison");
                        Console.WriteLine($"- Livraison #{idLivraison}");
                    }
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Erreur : " + e.Message);
            }


            Console.WriteLine("\nCuisiniers proposant des plats pescétariens :");
            string ajout5 =
                "SELECT utilisateur.prenom, utilisateur.nom " +
                "FROM utilisateur " +
                "JOIN cuisinier ON utilisateur.id_utilisateur = cuisinier.id_utilisateur " +
                "JOIN plat ON plat.id_cuisinier = cuisinier.id_cuisinier " +
                "WHERE plat.regime = 'Pescetarien';";
            MySqlCommand command5 = new MySqlCommand(ajout5, maConnexion);
            try
            {
                using (MySqlDataReader reader = command5.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string prenom = reader.GetString("prenom");
                        string nom = reader.GetString("nom");
                        Console.WriteLine($"- {prenom} {nom}");
                    }
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Erreur : " + e.Message);
            }

            maConnexion.Close();
            Console.WriteLine("\nFin de la méthode.");
        }
        

        public static int LireEntier(string message)
        {
            int valeur;
            while (true)
            {
                Console.WriteLine(message);
                string entree = Console.ReadLine();
                if (int.TryParse(entree, out valeur))
                    return valeur;

                Console.WriteLine("Entrée invalide. Veuillez entrer un entier.");
            }
            
        }

        /// <summary>
        /// Ajoute un nouvel utilisateur
        /// </summary>
        /// <returns>L’identifiant généré pour l’utilisateur
        public int AjouterUtilisateur()
        {
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=LivInParis;" +
                                         "UID=root;PASSWORD=" + mdp;

                this.maConnexion = new MySqlConnection(connexionString);
                this.maConnexion.Open();

            }
            catch (MySqlException e)
            {
                Console.WriteLine("Erreur de connexion : " + e.Message);
            }

            Console.WriteLine("nom : ");
            string nom = Console.ReadLine();
            Console.WriteLine("prenom : ");
            string prenom = Console.ReadLine();
            Console.WriteLine("adresse mail : ");
            string mail = Console.ReadLine();
            Console.WriteLine("mot de passe : ");
            string motdepasse = Console.ReadLine();
            Console.WriteLine("numero de telephone : ");
            string tel = Console.ReadLine();
            int num_rue = LireEntier("numero de rue");
            Console.WriteLine("nom de rue : ");
            string nom_rue = Console.ReadLine();
            int codepostal = LireEntier("code postal : ");
            Console.WriteLine("ville : ");
            string ville = Console.ReadLine();
            Console.WriteLine("metro le plus proche : ");
            string metro = Console.ReadLine();

            int id_utilisateur = 0;
            MySqlConnection maConnexion = null;




            string ajout = "INSERT INTO utilisateur (nom, prenom, email, mot_de_passe, telephone, numero_de_rue, rue, code_postal, ville, metro) " +
                           "VALUES (@nom, @prenom, @mail, @mdp, @tel, @num_rue, @nom_rue, @codepostal, @ville, @metro)";
            MySqlCommand command = new MySqlCommand(ajout, this.maConnexion);
            command.Parameters.AddWithValue("@nom", nom);
            command.Parameters.AddWithValue("@prenom", prenom);
            command.Parameters.AddWithValue("@mail", mail);
            command.Parameters.AddWithValue("@mdp", motdepasse);
            command.Parameters.AddWithValue("@tel", tel);
            command.Parameters.AddWithValue("@num_rue", num_rue);
            command.Parameters.AddWithValue("@nom_rue", nom_rue);
            command.Parameters.AddWithValue("@codepostal", codepostal);
            command.Parameters.AddWithValue("@ville", ville);
            command.Parameters.AddWithValue("@metro", metro);

            try
            {
                command.ExecuteNonQuery();
                id_utilisateur = Convert.ToInt32(command.LastInsertedId);
                Console.WriteLine("Insertion réussie, nouvel id_utilisateur : " + id_utilisateur);
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Echec : " + e.ToString());
            }
            finally
            {
                command.Dispose();
                if (maConnexion != null && maConnexion.State == System.Data.ConnectionState.Open)
                {
                    maConnexion.Close();
                }
            }
            return id_utilisateur;
        }


        public void AjouterClient(int id_utilisateur)
        {
            Console.WriteLine("Type de client : (entreprise ou particulier)");
            string type = Console.ReadLine();
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=LivInParis;" +
                                         "UID=root;PASSWORD=" + mdp;

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
                Console.WriteLine("Connexion réussie.");
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Erreur de connexion : " + e.Message);
            }

            string ajout = "INSERT INTO client (id_utilisateur, type_client)" + $"\r\nVALUES ({id_utilisateur}, '{type}')";
            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = ajout;
            try
            {
                command.ExecuteNonQuery();
                Console.WriteLine("reussi");

            }
            catch (MySqlException e)
            {
                Console.WriteLine("echec : " + e.ToString());
                Console.ReadLine();

            }

            string recupIdClient = "SELECT id_client FROM client WHERE id_utilisateur =@id_utilisateur ";

            MySqlCommand command1 = new MySqlCommand(recupIdClient, maConnexion);
            command1.Parameters.AddWithValue("@id_utilisateur", id_utilisateur);
            object idClient = command1.ExecuteScalar();
            int id_client = Convert.ToInt32(idClient);
            Console.WriteLine("etes-vous une entreprise ? (y/n) :");
            string res = Console.ReadLine();
            if (res == "y")
            {
                Console.WriteLine("nom entreprise : ");
                string nom_entreprise = Console.ReadLine();
                Console.WriteLine("nom_referent : ");
                string nom_referent = Console.ReadLine();
                ajout = "INSERT INTO entreprise (nom_entreprise, nom_referent, id_client)" +
               $"\r\nVALUES ('{nom_entreprise}', '{nom_referent}', {id_client})";
                command = maConnexion.CreateCommand();
                command.CommandText = ajout;
                try
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("reussi");

                }
                catch (MySqlException e)
                {
                    Console.WriteLine("echec : " + e.ToString());
                    Console.ReadLine();

                }
            }
            command.Dispose();

        }

        public void AjouterCuisinier(int id_utilisateur)
        {

            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=LivInParis;" +
                                         "UID=root;PASSWORD=" + mdp;

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
                Console.WriteLine("Connexion réussie.");
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Erreur de connexion : " + e.Message);
            }

            string ajout = "INSERT INTO cuisinier (id_utilisateur)" + $"\r\nVALUES ({id_utilisateur})";
            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = ajout;
            try
            {
                command.ExecuteNonQuery();
                Console.WriteLine("reussi");

            }
            catch (MySqlException e)
            {
                Console.WriteLine("echec : " + e.ToString());
                Console.ReadLine();

            }
            command.Dispose();

        }

        public void ModifierUtilisateur()
        {


            Console.WriteLine("Entrez l'ID de l'utilisateur que vous souhaitez modifier : ");
            int id_utilisateur;
            while (!int.TryParse(Console.ReadLine(), out id_utilisateur))
            {
                Console.WriteLine("ID invalide. Veuillez entrer un entier.");
            }

            Console.WriteLine("Quel champ voulez-vous modifier ?");
            Console.WriteLine("1. Nom\n2. Prénom\n3. Email\n4. Mot de passe\n5. Téléphone\n6. Numéro de rue\n7. Rue\n8. Code postal\n9. Ville\n10. Métro");
            int choixChamp;
            while (!int.TryParse(Console.ReadLine(), out choixChamp) || choixChamp < 1 || choixChamp > 10)
            {
                Console.WriteLine("Choix invalide. Réessayez.");
            }

            string[] champs = { "nom", "prenom", "email", "mot_de_passe", "telephone", "numero_de_rue", "rue", "code_postal", "ville", "metro" };
            string champModifie = champs[choixChamp - 1];

            Console.WriteLine($"Entrez la nouvelle valeur pour {champModifie} :");
            string nouvelleValeur = Console.ReadLine();

            string connexionString = "SERVER=localhost;PORT=3306;DATABASE=LivInParis;UID=root;PASSWORD=" + mdp;
            using (MySqlConnection connexion = new MySqlConnection(connexionString))
            {
                try
                {
                    connexion.Open();
                    string requete = $"UPDATE utilisateur SET {champModifie} = @valeur WHERE id_utilisateur = @id";
                    MySqlCommand cmd = new MySqlCommand(requete, connexion);
                    cmd.Parameters.AddWithValue("@valeur", champModifie == "numero_de_rue" || champModifie == "code_postal" ? Convert.ToInt32(nouvelleValeur) : (object)nouvelleValeur);
                    cmd.Parameters.AddWithValue("@id", id_utilisateur);

                    int lignesAffectees = cmd.ExecuteNonQuery();
                    if (lignesAffectees > 0)
                        Console.WriteLine("Utilisateur modifié avec succès.");
                    else
                        Console.WriteLine("Aucun utilisateur trouvé avec cet ID.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur lors de la modification : " + ex.Message);
                }
            }
        }

        public void SupprimerUtilisateur()
        {
            Console.WriteLine("Entrez l'ID de l'utilisateur que vous souhaitez supprimer :");
            int id_utilisateur;
            while (!int.TryParse(Console.ReadLine(), out id_utilisateur))
            {
                Console.WriteLine("Entrée invalide. Veuillez entrer un ID entier.");
            }

            string connexionString = "SERVER=localhost;PORT=3306;DATABASE=LivInParis;UID=root;PASSWORD=" + mdp;
            using (MySqlConnection connexion = new MySqlConnection(connexionString))
            {
                try
                {
                    connexion.Open();

                    // Vérifie si l'utilisateur existe
                    MySqlCommand verifCmd = new MySqlCommand("SELECT COUNT(*) FROM utilisateur WHERE id_utilisateur = @id", connexion);
                    verifCmd.Parameters.AddWithValue("@id", id_utilisateur);
                    int count = Convert.ToInt32(verifCmd.ExecuteScalar());

                    if (count == 0)
                    {
                        Console.WriteLine("Aucun utilisateur trouvé avec cet ID.");
                        return;
                    }

                    // Supprimer l'utilisateur
                    MySqlCommand deleteUserCmd = new MySqlCommand("DELETE FROM utilisateur WHERE id_utilisateur = @id", connexion);
                    deleteUserCmd.Parameters.AddWithValue("@id", id_utilisateur);
                    int lignes = deleteUserCmd.ExecuteNonQuery();

                    if (lignes > 0)
                        Console.WriteLine("Utilisateur supprimé avec succès.");
                    else
                        Console.WriteLine("La suppression a échoué.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur lors de la suppression : " + ex.Message);
                }
            }
        }

        public void AjouterClientDepuisUtilisateurExistant()
        {
            Console.WriteLine("Entrez l'ID de l'utilisateur que vous souhaitez lier à un client :");
            int id_utilisateur;
            while (!int.TryParse(Console.ReadLine(), out id_utilisateur))
            {
                Console.WriteLine("ID invalide. Veuillez entrer un entier.");
            }

            string connexionString = "SERVER=localhost;PORT=3306;DATABASE=LivInParis;UID=root;PASSWORD=" + mdp;
            using (MySqlConnection connexion = new MySqlConnection(connexionString))
            {
                try
                {
                    connexion.Open();

                    
                    string checkUser = "SELECT COUNT(*) FROM utilisateur WHERE id_utilisateur = @id";
                    using (MySqlCommand checkCmd = new MySqlCommand(checkUser, connexion))
                    {
                        checkCmd.Parameters.AddWithValue("@id", id_utilisateur);
                        int exists = Convert.ToInt32(checkCmd.ExecuteScalar());
                        if (exists == 0)
                        {
                            Console.WriteLine("Aucun utilisateur trouvé avec cet ID.");
                            return;
                        }
                    }

                    Console.WriteLine("Type de client (entreprise ou particulier) :");
                    string type_client = Console.ReadLine().ToLower();

                   
                    string insertClient = "INSERT INTO client (id_utilisateur, type_client) VALUES (@id, @type)";
                    using (MySqlCommand insertCmd = new MySqlCommand(insertClient, connexion))
                    {
                        insertCmd.Parameters.AddWithValue("@id", id_utilisateur);
                        insertCmd.Parameters.AddWithValue("@type", type_client);
                        insertCmd.ExecuteNonQuery();
                        Console.WriteLine("Client ajouté avec succès.");
                    }

                    if (type_client == "entreprise")
                    {
                        Console.WriteLine("Nom de l'entreprise :");
                        string nom_entreprise = Console.ReadLine();

                        Console.WriteLine("Nom du référent :");
                        string nom_referent = Console.ReadLine();

                        string getClientId = "SELECT id_client FROM client WHERE id_utilisateur = @id";
                        int id_client;
                        using (MySqlCommand getCmd = new MySqlCommand(getClientId, connexion))
                        {
                            getCmd.Parameters.AddWithValue("@id", id_utilisateur);
                            id_client = Convert.ToInt32(getCmd.ExecuteScalar());
                        }

                        string insertEntreprise = "INSERT INTO entreprise (nom_entreprise, nom_referent, id_client) VALUES (@nom, @referent, @id_client)";
                        using (MySqlCommand insertCmd = new MySqlCommand(insertEntreprise, connexion))
                        {
                            insertCmd.Parameters.AddWithValue("@nom", nom_entreprise);
                            insertCmd.Parameters.AddWithValue("@referent", nom_referent);
                            insertCmd.Parameters.AddWithValue("@id_client", id_client);
                            insertCmd.ExecuteNonQuery();
                            Console.WriteLine("Entreprise ajoutée avec succès.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur : " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Modifie le type d’un client existant 
        /// </summary>
        public void ModifierClient()
        {
            Console.WriteLine("Entrez l'ID du client que vous souhaitez modifier : ");
            int id_client;
            while (!int.TryParse(Console.ReadLine(), out id_client))
            {
                Console.WriteLine("ID invalide. Veuillez entrer un entier.");
            }

            string connexionString = "SERVER=localhost;PORT=3306;DATABASE=LivInParis;UID=root;PASSWORD=" + mdp;
            using (MySqlConnection connexion = new MySqlConnection(connexionString))
            {
                try
                {
                    connexion.Open();

                   
                    string checkClient = "SELECT COUNT(*) FROM client WHERE id_client = @id";
                    using (MySqlCommand checkCmd = new MySqlCommand(checkClient, connexion))
                    {
                        checkCmd.Parameters.AddWithValue("@id", id_client);
                        int exists = Convert.ToInt32(checkCmd.ExecuteScalar());
                        if (exists == 0)
                        {
                            Console.WriteLine("Aucun client trouvé avec cet ID.");
                            return;
                        }
                    }

                    Console.WriteLine("Quel champ voulez-vous modifier ?");
                    Console.WriteLine("1. Type de client");
                    int choixChamp;
                    while (!int.TryParse(Console.ReadLine(), out choixChamp) || choixChamp != 1)
                    {
                        Console.WriteLine("Entrée invalide. Seul '1' (Type de client) est modifiable ici.");
                    }

                    Console.WriteLine("Entrez la nouvelle valeur (ex: 'particulier' ou 'entreprise') :");
                    string nouvelleValeur = Console.ReadLine();

                    string updateQuery = "UPDATE client SET type_client = @valeur WHERE id_client = @id";
                    using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, connexion))
                    {
                        updateCmd.Parameters.AddWithValue("@valeur", nouvelleValeur);
                        updateCmd.Parameters.AddWithValue("@id", id_client);
                        int lignes = updateCmd.ExecuteNonQuery();
                        if (lignes > 0)
                            Console.WriteLine("Client modifié avec succès.");
                        else
                            Console.WriteLine("La modification a échoué.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur lors de la modification : " + ex.Message);
                }
            }
        }

        public void SupprimerClient()
        {
            Console.WriteLine("Entrez l'ID du client que vous souhaitez supprimer : ");
            int id_client;
            while (!int.TryParse(Console.ReadLine(), out id_client))
            {
                Console.WriteLine("ID invalide. Veuillez entrer un entier.");
            }

            string connexionString = "SERVER=localhost;PORT=3306;DATABASE=LivInParis;UID=root;PASSWORD=" + mdp;
            using (MySqlConnection connexion = new MySqlConnection(connexionString))
            {
                try
                {
                    connexion.Open();

                    
                    string verif = "SELECT COUNT(*) FROM client WHERE id_client = @id";
                    using (MySqlCommand cmdVerif = new MySqlCommand(verif, connexion))
                    {
                        cmdVerif.Parameters.AddWithValue("@id", id_client);
                        int count = Convert.ToInt32(cmdVerif.ExecuteScalar());
                        if (count == 0)
                        {
                            Console.WriteLine("Aucun client trouvé avec cet ID.");
                            return;
                        }
                    }

                    
                    string deleteEntreprise = "DELETE FROM entreprise WHERE id_client = @id";
                    using (MySqlCommand cmdEnt = new MySqlCommand(deleteEntreprise, connexion))
                    {
                        cmdEnt.Parameters.AddWithValue("@id", id_client);
                        cmdEnt.ExecuteNonQuery();
                    }

                    
                    string deleteClient = "DELETE FROM client WHERE id_client = @id";
                    using (MySqlCommand cmdClient = new MySqlCommand(deleteClient, connexion))
                    {
                        cmdClient.Parameters.AddWithValue("@id", id_client);
                        int lignes = cmdClient.ExecuteNonQuery();
                        if (lignes > 0)
                            Console.WriteLine("Client supprimé avec succès.");
                        else
                            Console.WriteLine("La suppression a échoué.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur lors de la suppression : " + ex.Message);
                }
            }
        }
        public void AfficherClientsParRueEtNumero()
        {
            string connexionString = "SERVER=localhost;PORT=3306;DATABASE=LivInParis;UID=root;PASSWORD=" + mdp;
            using (MySqlConnection connexion = new MySqlConnection(connexionString))
            {
                try
                {
                    connexion.Open();

                    string query = @"
                SELECT u.nom, u.prenom, u.numero_de_rue, u.rue, u.ville, c.type_client 
                FROM client c
                JOIN utilisateur u ON c.id_utilisateur = u.id_utilisateur
                ORDER BY u.rue ASC, u.numero_de_rue ASC;";

                    using (MySqlCommand cmd = new MySqlCommand(query, connexion))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine("Liste des clients triés par rue (A-Z) puis par numéro croissant :\n");

                        while (reader.Read())
                        {
                            string nom = reader["nom"].ToString();
                            string prenom = reader["prenom"].ToString();
                            int numero = Convert.ToInt32(reader["numero_de_rue"]);
                            string rue = reader["rue"].ToString();
                            string ville = reader["ville"].ToString();
                            string type = reader["type_client"].ToString();

                            Console.WriteLine($"- {prenom} {nom}, {numero} {rue}, {ville} ({type})");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur : " + ex.Message);
                }
            }
        }
        public void AfficherClientsOrdreAlphabetique()
        {
            string connexionString = "SERVER=localhost;PORT=3306;DATABASE=LivInParis;UID=root;PASSWORD=" + mdp;
            using (MySqlConnection connexion = new MySqlConnection(connexionString))
            {
                try
                {
                    connexion.Open();

                    string query = @"
                SELECT u.nom, u.prenom, u.numero_de_rue, u.rue, u.ville, c.type_client 
                FROM client c
                JOIN utilisateur u ON c.id_utilisateur = u.id_utilisateur
                ORDER BY u.nom ASC, u.prenom ASC;";

                    using (MySqlCommand cmd = new MySqlCommand(query, connexion))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine("Liste des clients par ordre alphabétique (nom puis prénom) :\n");

                        while (reader.Read())
                        {
                            string nom = reader["nom"].ToString();
                            string prenom = reader["prenom"].ToString();
                            int numero = Convert.ToInt32(reader["numero_de_rue"]);
                            string rue = reader["rue"].ToString();
                            string ville = reader["ville"].ToString();
                            string type = reader["type_client"].ToString();

                            Console.WriteLine($"- {prenom} {nom}, {numero} {rue}, {ville} ({type})");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur : " + ex.Message);
                }
            }
        }
        public void AfficherClientsParMontantCumule()
        {
            string connexionString = "SERVER=localhost;PORT=3306;DATABASE=LivInParis;UID=root;PASSWORD=" + mdp;
            using (MySqlConnection connexion = new MySqlConnection(connexionString))
            {
                try
                {
                    connexion.Open();

                    string query = @"
                SELECT cl.id_client, u.nom, u.prenom, SUM(t.montant_total) AS montant_cumule
                FROM client cl
                JOIN utilisateur u ON cl.id_utilisateur = u.id_utilisateur
                JOIN commande c ON cl.id_client = c.id_client
                JOIN transaction_commande tc ON c.id_commande = tc.id_commande
                JOIN transaction t ON tc.id_transaction = t.id_transaction
                GROUP BY cl.id_client, u.nom, u.prenom
                ORDER BY montant_cumule DESC;";

                    using (MySqlCommand cmd = new MySqlCommand(query, connexion))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine("Clients triés par montant cumulé d’achats :\n");

                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["id_client"]);
                            string nom = reader["nom"].ToString();
                            string prenom = reader["prenom"].ToString();
                            decimal montant = Convert.ToDecimal(reader["montant_cumule"]);

                            Console.WriteLine($"- {prenom} {nom} (ID: {id}) → {montant} €");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur : " + ex.Message);
                }
            }
        }


        /// <summary>
        /// Transforme un utilisateur existant en cuisinier
        /// </summary>
        public void AjouterCuisinierDepuisUtilisateurExistant()
        {
            Console.WriteLine("Entrez l'ID de l'utilisateur que vous souhaitez lier comme cuisinier :");
            int id_utilisateur;
            while (!int.TryParse(Console.ReadLine(), out id_utilisateur))
            {
                Console.WriteLine("ID invalide. Veuillez entrer un entier.");
            }

            string connexionString = "SERVER=localhost;PORT=3306;DATABASE=LivInParis;UID=root;PASSWORD=" + mdp;
            using (MySqlConnection connexion = new MySqlConnection(connexionString))
            {
                try
                {
                    connexion.Open();


                    string checkUser = "SELECT COUNT(*) FROM utilisateur WHERE id_utilisateur = @id";
                    using (MySqlCommand checkCmd = new MySqlCommand(checkUser, connexion))
                    {
                        checkCmd.Parameters.AddWithValue("@id", id_utilisateur);
                        int exists = Convert.ToInt32(checkCmd.ExecuteScalar());
                        if (exists == 0)
                        {
                            Console.WriteLine("Aucun utilisateur trouvé avec cet ID.");
                            return;
                        }
                    }

                
                    string insert = "INSERT INTO cuisinier (id_utilisateur) VALUES (@id)";
                    using (MySqlCommand insertCmd = new MySqlCommand(insert, connexion))
                    {
                        insertCmd.Parameters.AddWithValue("@id", id_utilisateur);
                        insertCmd.ExecuteNonQuery();
                        Console.WriteLine("Cuisinier ajouté avec succès.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur : " + ex.Message);
                }
            }
        }
        public void ModifierCuisinier()
        {
            Console.WriteLine("Entrez l'ID du cuisinier que vous souhaitez modifier : ");
            int id_cuisinier;
            while (!int.TryParse(Console.ReadLine(), out id_cuisinier))
            {
                Console.WriteLine("ID invalide. Veuillez entrer un entier.");
            }

            string connexionString = "SERVER=localhost;PORT=3306;DATABASE=LivInParis;UID=root;PASSWORD=" + mdp;
            using (MySqlConnection connexion = new MySqlConnection(connexionString))
            {
                try
                {
                    connexion.Open();

                    
                    string check = "SELECT COUNT(*) FROM cuisinier WHERE id_cuisinier = @id";
                    using (MySqlCommand cmd = new MySqlCommand(check, connexion))
                    {
                        cmd.Parameters.AddWithValue("@id", id_cuisinier);
                        int exists = Convert.ToInt32(cmd.ExecuteScalar());
                        if (exists == 0)
                        {
                            Console.WriteLine("Aucun cuisinier trouvé avec cet ID.");
                            return;
                        }
                    }

                    Console.WriteLine("Quel champ voulez-vous modifier ?");
                    Console.WriteLine("1. Nombre d’étoiles (nb_etoile)");
                    Console.WriteLine("2. Avis cuisinier (avis_cuisinier)");
                    int choix;
                    while (!int.TryParse(Console.ReadLine(), out choix) || (choix != 1 && choix != 2))
                    {
                        Console.WriteLine("Entrée invalide. Choisissez 1 ou 2.");
                    }

                    string champ = (choix == 1) ? "nb_etoile" : "avis_cuisinier";
                    Console.WriteLine($"Entrez la nouvelle valeur pour {champ} :");
                    string nouvelleValeur = Console.ReadLine();

                    string updateQuery = $"UPDATE cuisinier SET {champ} = @valeur WHERE id_cuisinier = @id";
                    using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, connexion))
                    {
                        if (champ == "nb_etoile")
                            updateCmd.Parameters.AddWithValue("@valeur", int.Parse(nouvelleValeur));
                        else
                            updateCmd.Parameters.AddWithValue("@valeur", nouvelleValeur);

                        updateCmd.Parameters.AddWithValue("@id", id_cuisinier);
                        int rows = updateCmd.ExecuteNonQuery();

                        if (rows > 0)
                            Console.WriteLine("Cuisinier modifié avec succès.");
                        else
                            Console.WriteLine("La modification a échoué.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur : " + ex.Message);
                }
            }
        }

        public void SupprimerCuisinier()
        {
            Console.WriteLine("Entrez l'ID du cuisinier que vous souhaitez supprimer : ");
            int id_cuisinier;
            while (!int.TryParse(Console.ReadLine(), out id_cuisinier))
            {
                Console.WriteLine("ID invalide. Veuillez entrer un entier.");
            }

            string connexionString = "SERVER=localhost;PORT=3306;DATABASE=LivInParis;UID=root;PASSWORD=" + mdp;
            using (MySqlConnection connexion = new MySqlConnection(connexionString))
            {
                try
                {
                    connexion.Open();

                    
                    string check = "SELECT COUNT(*) FROM cuisinier WHERE id_cuisinier = @id";
                    using (MySqlCommand checkCmd = new MySqlCommand(check, connexion))
                    {
                        checkCmd.Parameters.AddWithValue("@id", id_cuisinier);
                        int exists = Convert.ToInt32(checkCmd.ExecuteScalar());
                        if (exists == 0)
                        {
                            Console.WriteLine("Aucun cuisinier trouvé avec cet ID.");
                            return;
                        }
                    }

                   
                    string delete = "DELETE FROM cuisinier WHERE id_cuisinier = @id";
                    using (MySqlCommand deleteCmd = new MySqlCommand(delete, connexion))
                    {
                        deleteCmd.Parameters.AddWithValue("@id", id_cuisinier);
                        int rows = deleteCmd.ExecuteNonQuery();

                        if (rows > 0)
                            Console.WriteLine("Cuisinier supprimé avec succès.");
                        else
                            Console.WriteLine("La suppression a échoué.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur lors de la suppression : " + ex.Message);
                }
            }
        }

        public void AfficherPlatsDuCuisinierDepuisInscription()
        {
            Console.WriteLine("Entrez l'ID du cuisinier :");
            int id_cuisinier;
            while (!int.TryParse(Console.ReadLine(), out id_cuisinier))
            {
                Console.WriteLine("ID invalide. Veuillez entrer un entier.");
            }

            string connexionString = "SERVER=localhost;PORT=3306;DATABASE=LivInParis;UID=root;PASSWORD=" + mdp;
            using (MySqlConnection connexion = new MySqlConnection(connexionString))
            {
                try
                {
                    connexion.Open();

                   
                    string check = "SELECT COUNT(*) FROM cuisinier WHERE id_cuisinier = @id";
                    using (MySqlCommand checkCmd = new MySqlCommand(check, connexion))
                    {
                        checkCmd.Parameters.AddWithValue("@id", id_cuisinier);
                        int exists = Convert.ToInt32(checkCmd.ExecuteScalar());
                        if (exists == 0)
                        {
                            Console.WriteLine("Aucun cuisinier trouvé avec cet ID.");
                            return;
                        }
                    }

                    
                    string query = @"
                SELECT nom_plat, type_plat, date_fabrication, regime, origine
                FROM plat
                WHERE id_cuisinier = @id
                ORDER BY date_fabrication ASC;";

                    using (MySqlCommand cmd = new MySqlCommand(query, connexion))
                    {
                        cmd.Parameters.AddWithValue("@id", id_cuisinier);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            Console.WriteLine($"\nPlats réalisés par le cuisinier #{id_cuisinier} :\n");

                            if (!reader.HasRows)
                            {
                                Console.WriteLine("Aucun plat trouvé pour ce cuisinier.");
                                return;
                            }

                            while (reader.Read())
                            {
                                string nom = reader["nom_plat"].ToString();
                                string type = reader["type_plat"].ToString();
                                DateTime date = Convert.ToDateTime(reader["date_fabrication"]);
                                string regime = reader["regime"].ToString();
                                string origine = reader["origine"].ToString();

                                Console.WriteLine($"- {nom} ({type}) | {date:d} | {regime}, origine : {origine}");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur : " + ex.Message);
                }
            }
        }

        public void AfficherPlatsDuCuisinierParPeriode()
        {
            Console.WriteLine("Entrez l'ID du cuisinier :");
            int id_cuisinier;
            while (!int.TryParse(Console.ReadLine(), out id_cuisinier))
            {
                Console.WriteLine("ID invalide. Veuillez entrer un entier.");
            }

            Console.WriteLine("Entrez la date de début (format AAAA-MM-JJ) :");
            DateTime dateDebut;
            while (!DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateDebut))
            {
                Console.WriteLine("Format invalide. Réessayez (AAAA-MM-JJ) :");
            }

            Console.WriteLine("Entrez la date de fin (format AAAA-MM-JJ) :");
            DateTime dateFin;
            while (!DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateFin))
            {
                Console.WriteLine("Format invalide. Réessayez (AAAA-MM-JJ) :");
            }

            string connexionString = "SERVER=localhost;PORT=3306;DATABASE=LivInParis;UID=root;PASSWORD=" + mdp;
            using (MySqlConnection connexion = new MySqlConnection(connexionString))
            {
                try
                {
                    connexion.Open();

                    
                    string check = "SELECT COUNT(*) FROM cuisinier WHERE id_cuisinier = @id";
                    using (MySqlCommand cmd = new MySqlCommand(check, connexion))
                    {
                        cmd.Parameters.AddWithValue("@id", id_cuisinier);
                        int exists = Convert.ToInt32(cmd.ExecuteScalar());
                        if (exists == 0)
                        {
                            Console.WriteLine("Aucun cuisinier trouvé avec cet ID.");
                            return;
                        }
                    }

                   
                    string query = @"
                SELECT nom_plat, type_plat, date_fabrication, regime, origine
                FROM plat
                WHERE id_cuisinier = @id
                AND date_fabrication BETWEEN @dateDebut AND @dateFin
                ORDER BY date_fabrication ASC;";

                    using (MySqlCommand cmd = new MySqlCommand(query, connexion))
                    {
                        cmd.Parameters.AddWithValue("@id", id_cuisinier);
                        cmd.Parameters.AddWithValue("@dateDebut", dateDebut);
                        cmd.Parameters.AddWithValue("@dateFin", dateFin);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            Console.WriteLine($"\nPlats du cuisinier #{id_cuisinier} entre {dateDebut:yyyy-MM-dd} et {dateFin:yyyy-MM-dd} :\n");

                            if (!reader.HasRows)
                            {
                                Console.WriteLine("Aucun plat trouvé dans cette période.");
                                return;
                            }

                            while (reader.Read())
                            {
                                string nom = reader["nom_plat"].ToString();
                                string type = reader["type_plat"].ToString();
                                DateTime date = Convert.ToDateTime(reader["date_fabrication"]);
                                string regime = reader["regime"].ToString();
                                string origine = reader["origine"].ToString();

                                Console.WriteLine($"- {nom} ({type}) | {date:d} | {regime}, origine : {origine}");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur : " + ex.Message);
                }
            }
        }

        public void AfficherPlatsParFrequencePourCuisinier()
        {
            Console.WriteLine("Entrez l'ID du cuisinier :");
            int id_cuisinier;
            while (!int.TryParse(Console.ReadLine(), out id_cuisinier))
            {
                Console.WriteLine("ID invalide. Veuillez entrer un entier.");
            }

            string connexionString = "SERVER=localhost;PORT=3306;DATABASE=LivInParis;UID=root;PASSWORD=" + mdp;
            using (MySqlConnection connexion = new MySqlConnection(connexionString))
            {
                try
                {
                    connexion.Open();

                   
                    string check = "SELECT COUNT(*) FROM cuisinier WHERE id_cuisinier = @id";
                    using (MySqlCommand cmd = new MySqlCommand(check, connexion))
                    {
                        cmd.Parameters.AddWithValue("@id", id_cuisinier);
                        int exists = Convert.ToInt32(cmd.ExecuteScalar());
                        if (exists == 0)
                        {
                            Console.WriteLine("Aucun cuisinier trouvé avec cet ID.");
                            return;
                        }
                    }

                   
                    string query = @"
                SELECT nom_plat, COUNT(*) AS nb_preparations,
                       (COUNT(*) / total.total_count) AS frequence
                FROM plat
                JOIN (
                    SELECT id_cuisinier, COUNT(*) AS total_count
                    FROM plat
                    WHERE id_cuisinier = @id
                    GROUP BY id_cuisinier
                ) AS total ON plat.id_cuisinier = total.id_cuisinier
                WHERE plat.id_cuisinier = @id
                GROUP BY nom_plat, total.total_count
                ORDER BY frequence DESC;";

                    using (MySqlCommand cmd = new MySqlCommand(query, connexion))
                    {
                        cmd.Parameters.AddWithValue("@id", id_cuisinier);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            Console.WriteLine($"\nPlats du cuisinier #{id_cuisinier} par fréquence :\n");

                            if (!reader.HasRows)
                            {
                                Console.WriteLine("Aucun plat trouvé pour ce cuisinier.");
                                return;
                            }

                            while (reader.Read())
                            {
                                string nom = reader["nom_plat"].ToString();
                                int nb = Convert.ToInt32(reader["nb_preparations"]);
                                double freq = Convert.ToDouble(reader["frequence"]);

                                Console.WriteLine($"- {nom} : {nb} fois ({freq:P0})");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur : " + ex.Message);
                }
            }
        }

        public bool AuthentifierUtilisateur(int idUtilisateur, string motDePasse)
        {
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=LivInParis;" +
                                         "UID=root;PASSWORD=" + mdp;

                using (MySqlConnection connexion = new MySqlConnection(connexionString))
                {
                    connexion.Open();

                    string requete = "SELECT COUNT(*) FROM utilisateur WHERE id_utilisateur = @Id AND mot_de_passe = @MotDePasse";

                    using (MySqlCommand cmd = new MySqlCommand(requete, connexion))
                    {
                        cmd.Parameters.AddWithValue("@Id", idUtilisateur);
                        cmd.Parameters.AddWithValue("@MotDePasse", motDePasse);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de l'authentification : " + ex.Message);
                return false;
            }
        }

        public bool EstClient(int idUtilisateur)
        {
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;DATABASE=LivInParis;UID=root;PASSWORD=" + mdp;

                using (MySqlConnection connexion = new MySqlConnection(connexionString))
                {
                    connexion.Open();
                    string query = "SELECT COUNT(*) FROM client WHERE id_utilisateur = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, connexion))
                    {
                        cmd.Parameters.AddWithValue("@id", idUtilisateur);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la vérification client : " + ex.Message);
                return false;
            }
        }

        public bool EstCuisinier(int idUtilisateur)
        {
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;DATABASE=LivInParis;UID=root;PASSWORD=" + mdp;

                using (MySqlConnection connexion = new MySqlConnection(connexionString))
                {
                    connexion.Open();
                    string query = "SELECT COUNT(*) FROM cuisinier WHERE id_utilisateur = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, connexion))
                    {
                        cmd.Parameters.AddWithValue("@id", idUtilisateur);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la vérification cuisinier : " + ex.Message);
                return false;
            }
        }
        public void AfficherPlatsDisponiblesAujourdHui()
        {
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;DATABASE=LivInParis;UID=root;PASSWORD=" + mdp;

                using (MySqlConnection connexion = new MySqlConnection(connexionString))
                {
                    connexion.Open();

                    string query = @"
                SELECT p.id_plat, p.nom_plat, p.prix, p.quantite, p.date_fabrication, p.date_peremption,
                       u.nom AS nom_cuisinier, u.prenom
                FROM plat p
                JOIN cuisinier c ON p.id_cuisinier = c.id_cuisinier
                JOIN utilisateur u ON c.id_utilisateur = u.id_utilisateur
                WHERE CURDATE() BETWEEN DATE(p.date_fabrication) AND DATE(p.date_peremption)
                      AND p.quantite > 0;";

                    using (MySqlCommand cmd = new MySqlCommand(query, connexion))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine("Plats disponibles aujourd'hui :\n");
                        while (reader.Read())
                        {
                            int idPlat = Convert.ToInt32(reader["id_plat"]);
                            string nomPlat = reader["nom_plat"].ToString();
                            decimal prix = Convert.ToDecimal(reader["prix"]);
                            int quantite = Convert.ToInt32(reader["quantite"]);
                            DateTime dateFab = Convert.ToDateTime(reader["date_fabrication"]);
                            DateTime datePer = Convert.ToDateTime(reader["date_peremption"]);
                            string nomCuisinier = reader["nom_cuisinier"].ToString();
                            string prenom = reader["prenom"].ToString();

                            Console.WriteLine($"ID Plat : {idPlat}, Nom : {nomPlat}, Prix : {prix}€, Quantité : {quantite}");
                            Console.WriteLine($"   Cuisinier : {prenom} {nomCuisinier} | Fabriqué le {dateFab:d}, expire le {datePer:d}");
                            Console.WriteLine();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de l'affichage des plats : " + ex.Message);
            }
        }

        public void PasserCommande(int idUtilisateur)
        {
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;DATABASE=LivInParis;UID=root;PASSWORD=" + mdp;

                using (MySqlConnection connexion = new MySqlConnection(connexionString))
                {
                    connexion.Open();

                    
                    string queryClient = "SELECT id_client FROM client WHERE id_utilisateur = @idUtil";
                    int idClient;

                    using (MySqlCommand cmd = new MySqlCommand(queryClient, connexion))
                    {
                        cmd.Parameters.AddWithValue("@idUtil", idUtilisateur);
                        object result = cmd.ExecuteScalar();
                        if (result == null)
                        {
                            Console.WriteLine("Cet utilisateur n'a pas de compte client.");
                            return;
                        }
                        idClient = Convert.ToInt32(result);
                    }

                    Console.WriteLine("Entrez l'ID du plat que vous souhaitez commander :");
                    int idPlat = Convert.ToInt32(Console.ReadLine());

                 
                    string queryCuisinier = "SELECT id_cuisinier, quantite FROM plat WHERE id_plat = @idPlat";
                    int idCuisinier = -1;
                    int quantite = 0;

                    using (MySqlCommand cmd = new MySqlCommand(queryCuisinier, connexion))
                    {
                        cmd.Parameters.AddWithValue("@idPlat", idPlat);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                idCuisinier = Convert.ToInt32(reader["id_cuisinier"]);
                                quantite = Convert.ToInt32(reader["quantite"]);
                            }
                            else
                            {
                                Console.WriteLine("Plat non trouvé.");
                                return;
                            }
                        }
                    }

                    if (quantite <= 0)
                    {
                        Console.WriteLine("Ce plat n'est plus disponible.");
                        return;
                    }

                    
                    string insertCommande = @"INSERT INTO commande (id_cuisinier, id_client, statut, date_commande, id_plat)
                                      VALUES (@idCuisinier, @idClient, 'en attente', NOW(), @idPlat)";
                    using (MySqlCommand cmdInsert = new MySqlCommand(insertCommande, connexion))
                    {
                        cmdInsert.Parameters.AddWithValue("@idCuisinier", idCuisinier);
                        cmdInsert.Parameters.AddWithValue("@idClient", idClient);
                        cmdInsert.Parameters.AddWithValue("@idPlat", idPlat);

                        int rows = cmdInsert.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            Console.WriteLine("Commande enregistrée avec succès.");
                        }
                        else
                        {
                            Console.WriteLine("Erreur lors de l'enregistrement de la commande.");
                            return;
                        }
                    }

                   
                    string updateQuantite = "UPDATE plat SET quantite = quantite - 1 WHERE id_plat = @idPlat";
                    using (MySqlCommand cmdUpdate = new MySqlCommand(updateQuantite, connexion))
                    {
                        cmdUpdate.Parameters.AddWithValue("@idPlat", idPlat);
                        cmdUpdate.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la commande : " + ex.Message);
            }
        }

        public void AfficherCommandesEnAttenteDuCuisinier(int idUtilisateurCuisinier)
        {
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;DATABASE=LivInParis;UID=root;PASSWORD=" + mdp;

                using (MySqlConnection connexion = new MySqlConnection(connexionString))
                {
                    connexion.Open();

                   
                    string queryId = "SELECT id_cuisinier FROM cuisinier WHERE id_utilisateur = @idUtil";
                    int idCuisinier;

                    using (MySqlCommand cmd = new MySqlCommand(queryId, connexion))
                    {
                        cmd.Parameters.AddWithValue("@idUtil", idUtilisateurCuisinier);
                        object result = cmd.ExecuteScalar();
                        if (result == null)
                        {
                            Console.WriteLine("Cuisinier non trouvé.");
                            return;
                        }
                        idCuisinier = Convert.ToInt32(result);
                    }

                   
                    string query = @"
                SELECT co.id_commande, co.date_commande, u.nom, u.prenom, p.nom_plat
                FROM commande co
                JOIN client cl ON co.id_client = cl.id_client
                JOIN utilisateur u ON cl.id_utilisateur = u.id_utilisateur
                JOIN plat p ON co.id_plat = p.id_plat
                WHERE co.id_cuisinier = @idCuisinier AND co.statut = 'en attente'
                ORDER BY co.date_commande DESC;";

                    using (MySqlCommand cmd = new MySqlCommand(query, connexion))
                    {
                        cmd.Parameters.AddWithValue("@idCuisinier", idCuisinier);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            Console.WriteLine("Commandes EN ATTENTE sur vos plats :\n");

                            if (!reader.HasRows)
                            {
                                Console.WriteLine("Aucune commande en attente actuellement.");
                                return;
                            }

                            while (reader.Read())
                            {
                                int idCommande = Convert.ToInt32(reader["id_commande"]);
                                DateTime dateCommande = Convert.ToDateTime(reader["date_commande"]);
                                string prenom = reader["prenom"].ToString();
                                string nom = reader["nom"].ToString();
                                string plat = reader["nom_plat"].ToString();

                                Console.WriteLine($"Commande #{idCommande} - {plat}");
                                Console.WriteLine($"   Client : {prenom} {nom} | Date : {dateCommande:g}");
                                Console.WriteLine();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de l'affichage des commandes en attente : " + ex.Message);
            }
        }

        private void ModifierStatutCommande(int idUtilisateurCuisinier, int idCommande, string nouveauStatut)
        {
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;DATABASE=LivInParis;UID=root;PASSWORD=" + mdp;

                using (MySqlConnection connexion = new MySqlConnection(connexionString))
                {
                    connexion.Open();

                    
                    string requete = @"
                SELECT COUNT(*) FROM commande c
                JOIN cuisinier cu ON c.id_cuisinier = cu.id_cuisinier
                WHERE c.id_commande = @idCommande AND cu.id_utilisateur = @idUtilisateur";

                    using (MySqlCommand cmdCheck = new MySqlCommand(requete, connexion))
                    {
                        cmdCheck.Parameters.AddWithValue("@idCommande", idCommande);
                        cmdCheck.Parameters.AddWithValue("@idUtilisateur", idUtilisateurCuisinier);

                        int count = Convert.ToInt32(cmdCheck.ExecuteScalar());
                        if (count == 0)
                        {
                            Console.WriteLine("Cette commande ne vous appartient pas ou n'existe pas.");
                            return;
                        }
                    }

                    
                    string update = "UPDATE commande SET statut = @statut WHERE id_commande = @idCommande";

                    using (MySqlCommand cmd = new MySqlCommand(update, connexion))
                    {
                        cmd.Parameters.AddWithValue("@statut", nouveauStatut);
                        cmd.Parameters.AddWithValue("@idCommande", idCommande);
                        cmd.ExecuteNonQuery();

                        Console.WriteLine($"Commande #{idCommande} mise à jour avec le statut : {nouveauStatut.ToUpper()}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la modification de la commande : " + ex.Message);
            }
        }

        public int ValidationCommandeParCuisinier(int idUtilisateurCuisinier)
        {
            int chiffre;
            while (true)
            {
                Console.WriteLine("Que voulez-vous faire ? \n1.Valider un commande\n2.Refuser une commande\n3.Ne rien faire");
                string entre = Console.ReadLine();
                if (int.TryParse(entre, out chiffre) && chiffre >= 1 && chiffre <= 3)
                {
                    break;
                }
                Console.WriteLine("Entrée invalide. Veuillez choisir un numéro entre 1 et 3.");
            }
            int idcommande = 0;
            switch (chiffre)
            {
                case 1:
                    Console.WriteLine("Entrez l'ID de la commande à valider :");
                    idcommande = Convert.ToInt32(Console.ReadLine());
                    

                    ModifierStatutCommande(idUtilisateurCuisinier, idcommande, "validée");
                    break;
                case 2:
                    Console.WriteLine("Entrez l'ID de la commande à refuser :");
                     idcommande = Convert.ToInt32(Console.ReadLine());

                    ModifierStatutCommande(idUtilisateurCuisinier, idcommande, "refusée");
                    break;
                case 3:
                    break;

            }

            return idcommande;
        }
        public void AfficherCommandesClient(int idUtilisateur)
        {
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;DATABASE=LivInParis;UID=root;PASSWORD=" + mdp;

                using (MySqlConnection connexion = new MySqlConnection(connexionString))
                {
                    connexion.Open();

                   
                    string queryClient = "SELECT id_client FROM client WHERE id_utilisateur = @idUtil";
                    int idClient;

                    using (MySqlCommand cmd = new MySqlCommand(queryClient, connexion))
                    {
                        cmd.Parameters.AddWithValue("@idUtil", idUtilisateur);
                        object result = cmd.ExecuteScalar();

                        if (result == null)
                        {
                            Console.WriteLine("Aucun compte client lié à cet utilisateur.");
                            return;
                        }

                        idClient = Convert.ToInt32(result);
                    }

                   
                    string queryCommandes = @"
                SELECT c.id_commande, c.date_commande, c.statut,
                       p.nom_plat, u.nom AS nom_cuisinier, u.prenom AS prenom_cuisinier
                FROM commande c
                JOIN plat p ON c.id_plat = p.id_plat
                JOIN cuisinier cu ON c.id_cuisinier = cu.id_cuisinier
                JOIN utilisateur u ON cu.id_utilisateur = u.id_utilisateur
                WHERE c.id_client = @idClient
                ORDER BY c.date_commande DESC;";

                    using (MySqlCommand cmd = new MySqlCommand(queryCommandes, connexion))
                    {
                        cmd.Parameters.AddWithValue("@idClient", idClient);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            Console.WriteLine("\nHistorique des commandes :\n");

                            if (!reader.HasRows)
                            {
                                Console.WriteLine("Aucune commande enregistrée.");
                                return;
                            }

                            while (reader.Read())
                            {
                                int idCommande = Convert.ToInt32(reader["id_commande"]);
                                string plat = reader["nom_plat"].ToString();
                                string statut = reader["statut"].ToString();
                                string nomCuisinier = reader["nom_cuisinier"].ToString();
                                string prenomCuisinier = reader["prenom_cuisinier"].ToString();
                                DateTime date = Convert.ToDateTime(reader["date_commande"]);

                                Console.WriteLine($"Commande #{idCommande} | Plat : {plat} | Cuisinier : {prenomCuisinier} {nomCuisinier}");
                                Console.WriteLine($"Date : {date:g} | Statut : {statut.ToUpper()}");
                                Console.WriteLine();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de l'affichage des commandes : " + ex.Message);
            }
        }
        public void AfficherClientsServisParCuisinier()
        {
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;DATABASE=LivInParis;UID=root;PASSWORD=" + mdp;

                using (MySqlConnection connexion = new MySqlConnection(connexionString))
                {
                    connexion.Open();

                   
                    Console.WriteLine("Entrez l'ID du cuisinier :");
                    int idCuisinier;
                    while (!int.TryParse(Console.ReadLine(), out idCuisinier))
                    {
                        Console.WriteLine("Entrée invalide. Veuillez entrer un entier.");
                    }

                  
                    string check = "SELECT COUNT(*) FROM cuisinier WHERE id_cuisinier = @id";
                    using (MySqlCommand cmd = new MySqlCommand(check, connexion))
                    {
                        cmd.Parameters.AddWithValue("@id", idCuisinier);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        if (count == 0)
                        {
                            Console.WriteLine("Aucun cuisinier trouvé avec cet ID.");
                            return;
                        }
                    }

                   
                    string queryClients = @"
                SELECT DISTINCT u.id_utilisateur, u.nom, u.prenom, u.email
                FROM commande c
                JOIN client cl ON c.id_client = cl.id_client
                JOIN utilisateur u ON cl.id_utilisateur = u.id_utilisateur
                WHERE c.id_cuisinier = @idCuisinier
                ORDER BY u.nom, u.prenom;";

                    using (MySqlCommand cmd = new MySqlCommand(queryClients, connexion))
                    {
                        cmd.Parameters.AddWithValue("@idCuisinier", idCuisinier);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            Console.WriteLine("\nClients servis par ce cuisinier :\n");

                            if (!reader.HasRows)
                            {
                                Console.WriteLine("Aucun client servi pour le moment.");
                                return;
                            }

                            while (reader.Read())
                            {
                                int idUtilisateur = Convert.ToInt32(reader["id_utilisateur"]);
                                string nom = reader["nom"].ToString();
                                string prenom = reader["prenom"].ToString();
                                string email = reader["email"].ToString();

                                Console.WriteLine($"ID: {idUtilisateur} | Nom: {prenom} {nom} | Email: {email}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de l'affichage des clients servis : " + ex.Message);
            }
        }

        public void SupprimerCommande()
        {
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;DATABASE=LivInParis;UID=root;PASSWORD=" + mdp;

                using (MySqlConnection connexion = new MySqlConnection(connexionString))
                {
                    connexion.Open();

                    Console.WriteLine("Entrez l'ID de la commande à supprimer :");
                    int idCommande;
                    while (!int.TryParse(Console.ReadLine(), out idCommande))
                    {
                        Console.WriteLine("Entrée invalide. Veuillez entrer un entier.");
                    }

                   
                    string checkCommande = "SELECT COUNT(*) FROM commande WHERE id_commande = @id";
                    using (MySqlCommand cmdCheck = new MySqlCommand(checkCommande, connexion))
                    {
                        cmdCheck.Parameters.AddWithValue("@id", idCommande);
                        int count = Convert.ToInt32(cmdCheck.ExecuteScalar());
                        if (count == 0)
                        {
                            Console.WriteLine("Aucune commande trouvée avec cet ID.");
                            return;
                        }
                    }

                  
                    string deleteTransCommande = "DELETE FROM transaction_commande WHERE id_commande = @id";
                    string deleteLivCommande = "DELETE FROM livraison_commande WHERE id_commande = @id";

                    using (var cmd1 = new MySqlCommand(deleteTransCommande, connexion))
                    {
                        cmd1.Parameters.AddWithValue("@id", idCommande);
                        cmd1.ExecuteNonQuery();
                    }

                    using (var cmd2 = new MySqlCommand(deleteLivCommande, connexion))
                    {
                        cmd2.Parameters.AddWithValue("@id", idCommande);
                        cmd2.ExecuteNonQuery();
                    }

                   
                    string deleteCommande = "DELETE FROM commande WHERE id_commande = @id";
                    using (MySqlCommand cmdDelete = new MySqlCommand(deleteCommande, connexion))
                    {
                        cmdDelete.Parameters.AddWithValue("@id", idCommande);
                        int rows = cmdDelete.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            Console.WriteLine("Commande supprimée avec succès.");
                        }
                        else
                        {
                            Console.WriteLine("Échec de la suppression de la commande.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la suppression de la commande : " + ex.Message);
            }
        }

        public void CreerCommandeAdmin()
        {
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;DATABASE=LivInParis;UID=root;PASSWORD=" + mdp;

                using (MySqlConnection connexion = new MySqlConnection(connexionString))
                {
                    connexion.Open();

                   
                    Console.WriteLine("Entrez l'ID du client :");
                    int idClient;
                    while (!int.TryParse(Console.ReadLine(), out idClient))
                    {
                        Console.WriteLine("Entrée invalide. Veuillez entrer un entier.");
                    }

                   
                    string checkClient = "SELECT COUNT(*) FROM client WHERE id_client = @id";
                    using (MySqlCommand cmdCheck = new MySqlCommand(checkClient, connexion))
                    {
                        cmdCheck.Parameters.AddWithValue("@id", idClient);
                        int count = Convert.ToInt32(cmdCheck.ExecuteScalar());
                        if (count == 0)
                        {
                            Console.WriteLine("Aucun client trouvé avec cet ID.");
                            return;
                        }
                    }

                    
                    Console.WriteLine("Entrez l'ID du plat :");
                    int idPlat;
                    while (!int.TryParse(Console.ReadLine(), out idPlat))
                    {
                        Console.WriteLine("Entrée invalide. Veuillez entrer un entier.");
                    }

                   
                    string queryPlat = "SELECT id_cuisinier, quantite FROM plat WHERE id_plat = @id";
                    int idCuisinier = -1;
                    int quantite = 0;

                    using (MySqlCommand cmd = new MySqlCommand(queryPlat, connexion))
                    {
                        cmd.Parameters.AddWithValue("@id", idPlat);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                idCuisinier = Convert.ToInt32(reader["id_cuisinier"]);
                                quantite = Convert.ToInt32(reader["quantite"]);
                            }
                            else
                            {
                                Console.WriteLine("Aucun plat trouvé avec cet ID.");
                                return;
                            }
                        }
                    }

                    if (quantite <= 0)
                    {
                        Console.WriteLine("Ce plat est en rupture de stock.");
                        return;
                    }

                   
                    string insertCommande = @"INSERT INTO commande (id_cuisinier, id_client, statut, date_commande, id_plat)
                                      VALUES (@idCuisinier, @idClient, 'en attente', NOW(), @idPlat)";
                    using (MySqlCommand cmdInsert = new MySqlCommand(insertCommande, connexion))
                    {
                        cmdInsert.Parameters.AddWithValue("@idCuisinier", idCuisinier);
                        cmdInsert.Parameters.AddWithValue("@idClient", idClient);
                        cmdInsert.Parameters.AddWithValue("@idPlat", idPlat);

                        int rows = cmdInsert.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            Console.WriteLine("Commande créée avec succès.");
                        }
                        else
                        {
                            Console.WriteLine("Erreur lors de la création de la commande.");
                            return;
                        }
                    }

               
                    string updateQuantite = "UPDATE plat SET quantite = quantite - 1 WHERE id_plat = @idPlat";
                    using (MySqlCommand cmdUpdate = new MySqlCommand(updateQuantite, connexion))
                    {
                        cmdUpdate.Parameters.AddWithValue("@idPlat", idPlat);
                        cmdUpdate.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la création de la commande : " + ex.Message);
            }
        }




    }
}


