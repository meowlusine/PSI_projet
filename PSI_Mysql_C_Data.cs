using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Sockets;
using System.Reflection.PortableExecutable;

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

            string Peuplement_commande = "INSERT INTO commande (id_cuisinier, id_client,date_commande)" +
               "\r\nVALUES (1, 6,'2020-03-05 08:15:54'),(2, 7,'2021-06-09 17:54:21'),(3, 8,'2025-01-18 21:16:04'), (1, 9,'2024-12-26 09:04:43'),(2, 10,'2024-10-14 16:31:57');";
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

                    break;
            }

            break;

    }

        public void Affichage_client()
        {
            string Affichage_client = "SELECT * FROM utilisateur ORDER BY nom ASC, prenom, numero_de_rue  ASC;";


            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = Affichage_client;
            try
            {
                command.ExecuteNonQuery();
                Console.WriteLine("Peuplement entreprise reussi");

            }
            catch (MySqlException e)
            {
                Console.WriteLine(" Peuplement entreprise echec : " + e.ToString());
                Console.ReadLine();
                return;
            }
            command.Dispose();
        }

        public void Affichage_cuisinier()
        {



            MySqlCommand command12 = maConnexion.CreateCommand();
            command12.CommandText = "SELECT DISTINCT u.id_utilisateur AS id_utilisateur, u.nom AS nom, u.prenom AS prenom, u.email AS email " +
                           "FROM commande c " +
                           "JOIN client cl ON c.id_client = cl.id_client " +
                           "JOIN utilisateur u ON cl.id_utilisateur = u.id_utilisateur " +
                           "WHERE c.id_cuisinier = 1";
            Console.WriteLine("les clients que le cuisinier 1 a pu servir depuis son inscription à la plateforme");
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

            Console.WriteLine("depuis quand voulez-vous savoir les plats que le cuisinier a préparé ? sous le format AAAA-MM-JJ HH:MM:SS");
            DateTime date = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("les clients que le cuisinier 1 a pu servir depuis le " + Convert.ToString(date));
            MySqlCommand command13 = maConnexion.CreateCommand();
            command13.CommandText = "SELECT DISTINCT u.id_utilisateur, u.nom, u.prenom, u.email " +
                "FROM commande c JOIN client cl ON c.id_client = cl.id_client JOIN utilisateur u" +
                " ON cl.id_utilisateur = u.id_utilisateur WHERE c.id_cuisinier = 1 " +
                "AND c.date_commande BETWEEN '" + date + "' AND CURDATE(); ";

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





            if (maConnexion != null && maConnexion.State == System.Data.ConnectionState.Open)
            {
                maConnexion.Close();
                Console.WriteLine("Connexion fermée.");
            }
        }





    }
}
