using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using Org.BouncyCastle.Tls.Crypto;
using SkiaSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Net.Sockets;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Text.RegularExpressions;

namespace PSI
{

    public class PSI_Mysql_C_Data
    {
        private MySqlConnection maConnexion;


        public void Peuplement()
        {

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
                // Gérer l'exception selon les besoins
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
                Console.WriteLine("Peuplement reussi");

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
                Console.WriteLine("Peuplement cuisiniers reussi");

            }
            catch (MySqlException e)
            {
                Console.WriteLine(" Peuplement cuisisniers echec : " + e.ToString());
                Console.ReadLine();
                return;
            }
            command3.Dispose();





            string Peuplement_plat = "INSERT INTO plat (nom_plat, prix, quantite, type_plat, date_fabrication, date_peremption, regime, origine, description_recette, id_cuisinier)" +
                "\r\nVALUES ('Raclette', 10.00, 6, 'plat', '2025-01-10', '2025-01-15', 'Française', 'France', 'raclette, pommes de terre, jambon, cornichon', 1), " +
                "\r\n('Salade de fruits', 5.00, 6, 'dessert', '2025-01-10', '2025-01-15', 'Végétarien', 'Indifférent', 'fraise, kiwi, sucre', 1),\r\n" +
                "('Pizza Margherita', 8.50, 10, 'plat', '2025-02-01', '2025-02-05', 'Italienne', 'Italie', 'pâte, sauce tomate, mozzarella, basilic', 2)," +
                "\r\n('Boeuf Bourguignon', 12.00, 5, 'plat', '2025-02-02', '2025-02-10', 'Française', 'France', 'bœuf, vin rouge, champignons, carottes, oignons', 3)," +
                "\r\n('Tarte aux pommes', 6.00, 8, 'dessert', '2025-02-03', '2025-02-07', 'Végétarien', 'France', 'pommes, pâte brisée, cannelle, sucre', 1)," +
                "\r\n('Quiche Lorraine', 7.50, 7, 'plat', '2025-02-04', '2025-02-08', 'Française', 'France', 'pâte, lardons, crème, œufs, fromage', 2)," +
                "\r\n('Crème brûlée', 5.50, 10, 'dessert', '2025-02-05', '2025-02-12', 'Végétarien', 'France', 'crème, sucre, œufs, vanille', 3)," +
                "\r\n('Sushi', 12.00, 8, 'plat', '2025-03-10', '2025-03-15', 'Pescetarien', 'Japon', 'riz, poisson cru, algues, wasabi', 4)," +
                "\r\n('Ratatouille', 9.00, 10, 'plat', '2025-03-12', '2025-03-18', 'Végétarien', 'France', 'aubergine, courgette, tomate, poivron, herbes de Provence', 2)," +
                "\r\n('Falafel', 7.00, 12, 'plat', '2025-03-11', '2025-03-17', 'Végétarien', 'Moyen-Orient', 'pois chiches, épices, tahini, pita', 5)," +
                "\r\n('Tacos', 8.00, 9, 'plat', '2025-03-13', '2025-03-20', 'Omnivore', 'Mexique', 'tortilla, viande assaisonnée, salsa, fromage, guacamole', 3)," +
                "\r\n('Panna Cotta', 6.50, 8, 'dessert', '2025-03-14', '2025-03-21', 'Végétarien', 'Italie', 'crème, sucre, gélatine, vanille, coulis de fruits', 4)," +
                "\r\n('Biryani', 11.00, 6, 'plat', '2025-03-15', '2025-03-22', 'Omnivore', 'Inde', 'riz, épices, poulet, yaourt, coriandre', 6)," +
                "\r\n('Pad Thaï', 10.50, 7, 'plat', '2025-03-16', '2025-03-23', 'Omnivore', 'Thaïlande', 'nouilles de riz, crevettes, tofu, cacahuètes, citron vert', 5)," +
                "\r\n('Baklava', 5.00, 10, 'dessert', '2025-03-17', '2025-03-24', 'Végétarien', 'Turquie', 'pâte filo, noix, miel, sirop', 7)," +
                "\r\n('Ceviche', 13.00, 5, 'plat', '2025-03-18', '2025-03-25', 'Pescetarien', 'Pérou', 'poisson cru, citron vert, oignon, coriandre, piment', 4)," +
                "\r\n('Goulash', 9.50, 8, 'plat', '2025-03-19', '2025-03-26', 'Omnivore', 'Hongrie', 'bœuf, paprika, oignon, tomate, bouillon', 3);";

            MySqlCommand command2 = maConnexion.CreateCommand();
            command2.CommandText = Peuplement_plat;
            try
            {
                command2.ExecuteNonQuery();
                Console.WriteLine("Peuplement plats reussi");

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
                Console.WriteLine("Peuplement clients reussi");

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
                Console.WriteLine("Peuplement entreprise reussi");

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
                Console.WriteLine("Peuplement recette reussi");

            }
            catch (MySqlException e)
            {
                Console.WriteLine(" Peuplement recette echec : " + e.ToString());
                Console.ReadLine();
                return;
            }
            command6.Dispose();

            string Peuplement_commande = "INSERT INTO commande (id_cuisinier, id_client,date_commande, id_plat)" +
               "\r\nVALUES (1, 6,'2020-03-05 08:15:54',8),(2, 7,'2021-06-09 17:54:21',7),(3, 8,'2025-01-18 21:16:04',2), (1, 9,'2024-12-26 09:04:43',4),(2, 10,'2024-10-14 16:31:57',11);";
            MySqlCommand command7 = maConnexion.CreateCommand();
            command7.CommandText = Peuplement_commande;
            try
            {
                command7.ExecuteNonQuery();
                Console.WriteLine("Peuplement commande reussi");

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
                Console.WriteLine("Peuplement transaction reussi");

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
                Console.WriteLine("Peuplement livraison reussi");

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
                Console.WriteLine("Peuplement transaction_commande reussi");

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
                Console.WriteLine("Peuplement livraison_commande reussi");

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
                                         "UID=root;PASSWORD=kakawete";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
                Console.WriteLine("Connexion réussie.");
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Erreur de connexion : " + e.Message);
                // Gérer l'exception selon les besoins
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

                    Console.WriteLine($"ID Client: {idClient}, ID Utilisateur: {idUtilisateur}, Type Client: {typeClient}, Nom: {nom}, Prénom: {prenom}, Email: {email}, Mot de passe: {motDePasse}, Téléphone: {telephone}, Numéro de rue: {numeroDeRue}, Rue: {rue}, Code Postal: {codePostal}, Ville: {ville}, Métro: {metro}");
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
                Console.WriteLine("Connexion fermée.");
            }

        }

        public void Affichage_cuisinier()
        {
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
                // Gérer l'exception selon les besoins
            }
            MySqlCommand command12 = maConnexion.CreateCommand();
            Console.WriteLine("Donnez l'id du cuisisnier");
            int id = Convert.ToInt32(Console.ReadLine());
            command12.CommandText = "SELECT DISTINCT u.id_utilisateur AS id_utilisateur, u.nom AS nom, u.prenom AS prenom, u.email AS email " +
                           "FROM commande c " +
                           "JOIN client cl ON c.id_client = cl.id_client " +
                           "JOIN utilisateur u ON cl.id_utilisateur = u.id_utilisateur " +
                           "WHERE c.id_cuisinier = "+id;
            Console.WriteLine("les clients que le cuisinier "+id+" a pu servir depuis son inscription à la plateforme");
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



            Console.WriteLine("depuis quand voulez-vous savoir les plats que le cuisinier a préparé ? sous le format AAAA-MM-JJ HH:MM:SS");
            DateTime date = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("les clients que le cuisinier "+id+" a pu servir depuis le " + Convert.ToString(date));
            MySqlCommand command13 = maConnexion.CreateCommand();
            command13.CommandText = "SELECT DISTINCT u.id_utilisateur, u.nom, u.prenom, u.email " +
                "FROM commande c JOIN client cl ON c.id_client = cl.id_client JOIN utilisateur u" +
                " ON cl.id_utilisateur = u.id_utilisateur WHERE c.id_cuisinier =  " +id+
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

                    // Affichage du ratio en pourcentage par exemple
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
                Console.WriteLine("Connexion fermée.");
            }
        }

        public void Affichage_statistiques()
        {
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
                // Gérer l'exception selon les besoins
            }

            //Console.WriteLine(" le nombre de livraisons effectuées par cuisinier");
            //string requete = "SELECT id_cuisinier, COUNT(*) AS nb_livraisons FROM livraison GROUP BY id_cuisinier;";

            //MySqlCommand cmdLivraison = new MySqlCommand(requete, maConnexion);
            //MySqlDataReader readerLivraison = cmdLivraison.ExecuteReader();

            //while (readerLivraison.Read())
            //{
            //    try
            //    {
            //        int idCuisinier = Convert.ToInt32(readerLivraison["id_cuisinier"]);
            //        int nbLivraisons = Convert.ToInt32(readerLivraison["nb_livraisons"]);
            //        Console.WriteLine($"Cuisinier {idCuisinier} a effectué {nbLivraisons} livraisons.");
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine("Erreur lors de la lecture d'une colonne : " + ex.Message);
            //    }
            //}
            //readerLivraison.Close();

            //Console.WriteLine();


            //Console.WriteLine(" les commandes selon une période de temps");
            //Console.WriteLine("La premiere date de la periode ? sous le format AAAA-MM-JJ HH:MM:SS");
            //DateTime date1 = Convert.ToDateTime(Console.ReadLine());

            //Console.WriteLine("La deuxieme date de la periode ? sous le format AAAA-MM-JJ HH:MM:SS");
            //DateTime date2 = Convert.ToDateTime(Console.ReadLine());

            //string requeteCommande = @" SELECT * FROM commande WHERE date_commande BETWEEN @date1 AND @date2 ORDER BY date_commande;";

            //using (MySqlCommand cmdCommande = new MySqlCommand(requeteCommande, maConnexion))
            //{
            //    // Paramètres
            //    cmdCommande.Parameters.Add("@date1", MySqlDbType.DateTime).Value = date1;
            //    cmdCommande.Parameters.Add("@date2", MySqlDbType.DateTime).Value = date2;

            //    using (MySqlDataReader readerCommande = cmdCommande.ExecuteReader())
            //    {
            //        while (readerCommande.Read())
            //        {
            //            try
            //            {
            //                int idCommande = Convert.ToInt32(readerCommande["id_commande"]);
            //                int idCuisinier = Convert.ToInt32(readerCommande["id_cuisinier"]);
            //                int idClient = Convert.ToInt32(readerCommande["id_client"]);
            //                DateTime dateCommande = Convert.ToDateTime(readerCommande["date_commande"]);

            //                Console.WriteLine($"Commande {idCommande}: Cuisinier {idCuisinier}, Client {idClient}, Date {dateCommande}");
            //            }
            //            catch (Exception ex)
            //            {
            //                Console.WriteLine("Erreur lors de la lecture d'une colonne : " + ex.Message);
            //            }
            //        }
            //    }
            //}

            //Console.WriteLine();



            //string requeteMoyennePrix = " SELECT AVG(t.montant_total) AS moyenne_prix FROM commande c JOIN transaction_commande tc ON c.id_commande = tc.id_commande JOIN `transaction` t ON tc.id_transaction = t.id_transaction;";

            //using (MySqlCommand cmdMoyennePrix = new MySqlCommand(requeteMoyennePrix, maConnexion))
            //{
            //    object resultPrix = cmdMoyennePrix.ExecuteScalar();
            //    if (resultPrix != null && resultPrix != DBNull.Value)
            //    {
            //        decimal moyennePrix = Convert.ToDecimal(resultPrix);
            //        Console.WriteLine($"La moyenne des prix des commandes est : {moyennePrix}");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Aucune donnée disponible pour calculer la moyenne.");
            //    }
            //}
            //Console.WriteLine();

            //Console.WriteLine("moyenne des comptes clients :");
            //string queryMoyenneCommandes = @"SELECT AVG(nb_commandes) AS moyenne_commandes FROM (SELECT id_client, COUNT(*) AS nb_commandes FROM commande GROUP BY id_client) AS sub;";

            //MySqlCommand cmdMoyenneCommandes = new MySqlCommand(queryMoyenneCommandes, maConnexion);
            //object resultMoyenne = cmdMoyenneCommandes.ExecuteScalar();
            //if (resultMoyenne != null)
            //{
            //    decimal moyenneCommandes = Convert.ToDecimal(resultMoyenne);
            //    Console.WriteLine($"La moyenne des commandes par client est : {moyenneCommandes}");
            //}
            //Console.WriteLine();


            int clientId = 6; // Par exemple, à remplacer par l'ID du client recherché
            string origineRecherche = "Française"; // Modifier selon la nationalité recherchée

            string queryCommandesClient = "SELECT DISTINCT c.id_commande, c.date_commande, cl.id_client, u.nom AS nom_client, u.prenom AS prenom_client, p.origine FROM commande c " +
                " JOIN client cl ON c.id_client = cl.id_client JOIN utilisateur u ON cl.id_utilisateur = u.id_utilisateur JOIN plat p ON c.id_cuisinier = p.id_cuisinier " +
                "WHERE cl.id_client = @clientId AND c.date_commande BETWEEN '2020-01-01' AND '2024-12-31' AND p.origine = @origineRecherche ORDER BY c.date_commande;";

            MySqlCommand cmdCommandesClient = new MySqlCommand(queryCommandesClient, maConnexion);
            cmdCommandesClient.Parameters.AddWithValue("@clientId", clientId);
            cmdCommandesClient.Parameters.AddWithValue("@origineRecherche", origineRecherche);

            MySqlDataReader readerCommandes = cmdCommandesClient.ExecuteReader();

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

                    Console.WriteLine($"Commande {idCommande} pour le client {nomClient} {prenomClient} (ID: {idClient}) le {dateCommande:d}, Plat d'origine: {origine}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur lors de la lecture d'une colonne : " + ex.Message);
                }
            }
            readerCommandes.Close();





            if (maConnexion != null && maConnexion.State == System.Data.ConnectionState.Open)
            {
                maConnexion.Close();
                Console.WriteLine("Connexion fermée.");
            }
            Console.WriteLine();
        }

        public void Interface_admin()
        {
            Console.WriteLine("Que voulez-vous faire ? (entrer le numero)");
            Console.WriteLine("1.Modification de la base de donnée\n2.Affichage des données");
            int num = Convert.ToInt32(Console.ReadLine());

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
                // Gérer l'exception selon les besoins
            }
            switch (num)
            {
                case 1:
                    Console.WriteLine("Entrer votre commande : ");
                    string commande = Convert.ToString(Console.ReadLine());
                    MySqlCommand command1 = maConnexion.CreateCommand();
                    command1.CommandText = commande;
                    command1.Dispose();

                    break;
                case 2:
                    Console.WriteLine("1.Clients\n2.Cuisiniers\n3.Commandes");
                    int choix = Convert.ToInt32(Console.ReadLine());
                    switch (choix)
                    {
                        case 1:
                            Affichage_client();
                            break;
                        case 2:
                            Affichage_cuisinier();
                            break;
                        case 3:
                            Affichage_commande();
                            break;
                    }

                    break;

            }
        }
       public (string,string) Affichage_commande()
{
    try
    {
        string connexionString = "SERVER=localhost;PORT=3306;" +
                                 "DATABASE=LivInParis;" +
                                 "UID=root;PASSWORD=1234";

        maConnexion = new MySqlConnection(connexionString);
        maConnexion.Open();
        Console.WriteLine("Connexion réussie.");
    }
    catch (MySqlException e)
    {
        Console.WriteLine("Erreur de connexion : " + e.Message);
        // Gérer l'exception selon les besoins
    }

    Console.WriteLine("Quel est le numéro de commande ? ");
    int numero = Convert.ToInt32(Console.ReadLine());

    // Récupération du montant de la commande
    string commande = "SELECT montant_total FROM transaction WHERE id_transaction = " +
                          "(SELECT id_transaction FROM transaction_commande WHERE id_commande = @numero)";

    MySqlCommand command0 = new MySqlCommand(commande, maConnexion);
    command0.Parameters.AddWithValue("@numero", numero);
    object montant = command0.ExecuteScalar();
    Console.WriteLine($"Montant total : {montant} euros");

    // Récupération de la station de métro du client
    string queryMetroClient = "SELECT metro FROM utilisateur WHERE id_utilisateur = " +
                              "(SELECT id_utilisateur FROM client WHERE id_client = " +
                              "(SELECT id_client FROM commande WHERE id_commande = @numero))";

    MySqlCommand command1 = new MySqlCommand(queryMetroClient, maConnexion);
    command1.Parameters.AddWithValue("@numero", numero);
    object metroClient = command1.ExecuteScalar();
    Console.WriteLine($"Métro client : {metroClient}");
    string metro1 = metroClient.ToString();

    // Récupération de la station de métro du cuisinier
    string queryMetroCuisinier = "SELECT metro FROM utilisateur WHERE id_utilisateur = " +
                                 "(SELECT id_utilisateur FROM cuisinier WHERE id_cuisinier = " +
                                 "(SELECT id_cuisinier FROM commande WHERE id_commande = @numero))";

    MySqlCommand command2 = new MySqlCommand(queryMetroCuisinier, maConnexion);
    command2.Parameters.AddWithValue("@numero", numero);
    object metroCuisinier = command2.ExecuteScalar();
    string metro2 = metroCuisinier.ToString();
    Console.WriteLine($"Métro cuisinier : {metroCuisinier}");

    if (maConnexion != null && maConnexion.State == System.Data.ConnectionState.Open)
    {
        maConnexion.Close();
        Console.WriteLine("Connexion fermée.");
    }
    Console.WriteLine();

    return (metro1, metro2);
}

        public void AjouterUtilisateur()
{
    //nom, prenom, email, mot_de_passe, telephone, numero_de_rue, rue, code_postal, ville, metro
    Console.WriteLine("nom : ");
    string nom = Console.ReadLine();
    Console.WriteLine("prenom : ");
    string prenom = Console.ReadLine();
    Console.WriteLine("adresse mail : ");
    string mail = Console.ReadLine();
    Console.WriteLine("mot de passe : ");
    string mdp = Console.ReadLine();
    Console.WriteLine("numero de telephone : ");
    string tel = Console.ReadLine();
    Console.WriteLine("numero de rue : ");
    int num_rue = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("nom de rue : ");
    string nom_rue = Console.ReadLine();
    Console.WriteLine("code postal : ");
    int codepostal = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("ville : ");
    string ville = Console.ReadLine();
    Console.WriteLine("metro le plus proche : ");
    string metro = Console.ReadLine();

    try
    {
        string connexionString = "SERVER=localhost;PORT=3306;" +
                                 "DATABASE=LivInParis;" +
                                 "UID=root;PASSWORD=1234";

        maConnexion = new MySqlConnection(connexionString);
        maConnexion.Open();
        Console.WriteLine("Connexion réussie.");
    }
    catch (MySqlException e)
    {
        Console.WriteLine("Erreur de connexion : " + e.Message);
        // Gérer l'exception selon les besoins
    }

    string ajout = " INSERT INTO utilisateur (nom, prenom, email, mot_de_passe, telephone, numero_de_rue, rue, code_postal, ville, metro) " +
        $"\r\nVALUES ('{nom}', '{prenom}', '{mail}', '{mdp}', '{tel}', {num_rue}, '{nom_rue}', {codepostal}, '{ville}', '{metro}')";
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
        return;
    }
    command.Dispose();

}

public void AjouterClient( int id_utilisateur)
{
    Console.WriteLine("Type de client : (entreprise ou particulier)");
    string type = Console.ReadLine();
    try
    {
        string connexionString = "SERVER=localhost;PORT=3306;" +
                                 "DATABASE=LivInParis;" +
                                 "UID=root;PASSWORD=1234";

        maConnexion = new MySqlConnection(connexionString);
        maConnexion.Open();
        Console.WriteLine("Connexion réussie.");
    }
    catch (MySqlException e)
    {
        Console.WriteLine("Erreur de connexion : " + e.Message);
        // Gérer l'exception selon les besoins
    }

    string ajout = "INSERT INTO client (id_utilisateur, type_client)" +$"\r\nVALUES ({id_utilisateur}, '{type}')";
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
        return;
    }

    string recupIdClient = "SELECT id_client FROM client WHERE id_utilisateur =@id_utilisateur ";

    MySqlCommand command1 = new MySqlCommand(recupIdClient, maConnexion);
    command1.Parameters.AddWithValue("@id_utilisateur", id_utilisateur);
    object idClient = command1.ExecuteScalar();
    int id_client =Convert.ToInt32(idClient);
    Console.WriteLine("etes-vous une entreprise ? (y/n) :");
    string res = Console.ReadLine();
    if(res == "y")
    {
        //nom_entreprise, nom_referent, id_client)
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
            return;
        }
    }
    command.Dispose();

}

public void AjouterCuisinier(int id_utilisateur)
{
    //INSERT INTO cuisinier (id_utilisateur, nb_etoile, avis_cuisinier)" +
    // "\r\nVALUES (6, 3, 'Spécialiste en cuisine française'),"

    Console.WriteLine("nombre d'etoile : ");
    int nb_etoile = Convert.ToInt32(Console.ReadLine());

    try
    {
        string connexionString = "SERVER=localhost;PORT=3306;" +
                                 "DATABASE=LivInParis;" +
                                 "UID=root;PASSWORD=1234";

        maConnexion = new MySqlConnection(connexionString);
        maConnexion.Open();
        Console.WriteLine("Connexion réussie.");
    }
    catch (MySqlException e)
    {
        Console.WriteLine("Erreur de connexion : " + e.Message);
        // Gérer l'exception selon les besoins
    }

    string ajout = "INSERT INTO cuisinier (id_utilisateur, nb_etoile)" +$"\r\nVALUES ({id_utilisateur}, {nb_etoile})";
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
        return;
    }
    command.Dispose();

}
    }
}
