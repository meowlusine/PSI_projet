using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace PSI;

public class BddJson
{
    private static string mdp = "kakawete";

    string connectionString = "Server=localhost;Database=LivInParis;Uid=root;PASSWORD=" + mdp;

    public static void LectureTokenJson(string nomFichier)
    {
        using (StreamReader reader = new StreamReader(nomFichier))
        using (JsonTextReader jreader = new JsonTextReader(reader))
        {
            int compteur = 1;
            while (jreader.Read())
            {
                Console.Write("Token n°" + compteur++ + " => ");
                if (jreader.Value != null)
                    Console.WriteLine(jreader.TokenType + " : " + jreader.Value);
                else
                    Console.WriteLine(jreader.TokenType + " : ");
            }
        }
    }


    public static void AfficherPrettyJson(string nomFichier)
    {
        string json = File.ReadAllText(nomFichier);
        var parsedJson = JsonConvert.DeserializeObject(json);
        string pretty = JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
        Console.WriteLine(pretty);
    }


    public void ExporterPlatsEnJson()
    {
        List<Plat> plats = new List<Plat>();



        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT * FROM Plat";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            using (MySqlDataReader reader = command.ExecuteReader())


                while (reader.Read())
                {
                    Plat plat = new Plat();
                    plat.Id_Plat = reader.GetInt32(reader.GetOrdinal("id_plat"));
                    plat.Nom_Plat = reader.GetString(reader.GetOrdinal("nom_plat"));

                    int prixIndex = reader.GetOrdinal("prix");
                    if (!reader.IsDBNull(prixIndex))
                        plat.Prix = reader.GetDouble(prixIndex);
                    else
                        plat.Prix = 0.0;

                    int quantiteIndex = reader.GetOrdinal("quantite");
                    if (!reader.IsDBNull(quantiteIndex))
                        plat.Quantite = reader.GetInt32(quantiteIndex);
                    else
                        plat.Quantite = 0;

                    int typePlatIndex = reader.GetOrdinal("type_plat");
                    if (!reader.IsDBNull(typePlatIndex))
                        plat.Type_Plat = reader.GetString(typePlatIndex);
                    else
                        plat.Type_Plat = "";

                    int fabricationIndex = reader.GetOrdinal("date_fabrication");
                    if (!reader.IsDBNull(fabricationIndex))
                        plat.Date_Fabrication = reader.GetDateTime(fabricationIndex);
                    else
                        plat.Date_Fabrication = new DateTime(1900, 1, 1);

                    int peremptionIndex = reader.GetOrdinal("date_peremption");
                    if (!reader.IsDBNull(peremptionIndex))
                        plat.Date_Peremption = reader.GetDateTime(peremptionIndex);
                    else
                        plat.Date_Peremption = new DateTime(1900, 1, 1);

                    int regimeIndex = reader.GetOrdinal("regime");
                    if (!reader.IsDBNull(regimeIndex))
                        plat.Regime = reader.GetString(regimeIndex);
                    else
                        plat.Regime = "";

                    int origineIndex = reader.GetOrdinal("origine");
                    if (!reader.IsDBNull(origineIndex))
                        plat.Origine = reader.GetString(origineIndex);
                    else
                        plat.Origine = "";

                    int descIndex = reader.GetOrdinal("description_recette");
                    if (!reader.IsDBNull(descIndex))
                        plat.Description_Recette = reader.GetString(descIndex);
                    else
                        plat.Description_Recette = "";

                    int cuisinierIndex = reader.GetOrdinal("id_cuisinier");
                    if (!reader.IsDBNull(cuisinierIndex))
                        plat.Id_Cuisinier = reader.GetInt32(cuisinierIndex);
                    else
                        plat.Id_Cuisinier = 0;

                    int recetteIndex = reader.GetOrdinal("id_recette");
                    if (!reader.IsDBNull(recetteIndex))
                        plat.Id_Recette = reader.GetInt32(recetteIndex);
                    else
                        plat.Id_Recette = 0;

                    int photoIndex = reader.GetOrdinal("photo");
                    if (!reader.IsDBNull(photoIndex))
                        plat.Photo = (byte[])reader["photo"];
                    else
                        plat.Photo = new byte[0];

                    plats.Add(plat);
                }
        }

        string json = JsonConvert.SerializeObject(plats, Formatting.Indented);
        File.WriteAllText("plats_from_db.json", json);

    }

    public void ExporterClientsEnJson()
    {
        List<Client> clients = new List<Client>();

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT * FROM client";
            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var client = new Client
                    {
                        Id_Client = reader.GetInt32(reader.GetOrdinal("Id_Client")),
                        Id_Utilisateur = reader.GetInt32(reader.GetOrdinal("Id_Utilisateur")),
                        Type_Client = reader["Type_Client"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Type_Client")) : null
                    };
                    clients.Add(client);
                }
            }
        }

        string json = JsonConvert.SerializeObject(clients, Formatting.Indented);
        File.WriteAllText("clients_from_db.json", json);
    }

    public void ExporterCommandesEnJson()
    {
        var commandes = new List<Commande2>();

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            var query = "SELECT * FROM commande;";
            using var cmd = new MySqlCommand(query, connection);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var commande = new Commande2
                {
                    Id_Commande = reader.GetInt32(reader.GetOrdinal("Id_Commande")),
                    Id_Cuisinier = reader.GetInt32(reader.GetOrdinal("Id_Cuisinier")),
                    Id_Client = reader.GetInt32(reader.GetOrdinal("Id_Client")),
                    Date_Commande = reader.GetDateTime(reader.GetOrdinal("Date_Commande")),
                    Id_Plat = reader.GetInt32(reader.GetOrdinal("Id_Plat"))
                };

                commandes.Add(commande);
            }
        }

        var json = JsonConvert.SerializeObject(commandes, Formatting.Indented);
        File.WriteAllText("commandes_from_db.json", json);
    }

    public void ExporterCuisiniersEnJson()
    {

        var cuisiniers = new List<Cuisinier>();

        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            var query = "SELECT * FROM cuisinier;";
            using var cmd = new MySqlCommand(query, connection);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var cuisinier = new Cuisinier
                {
                    Id_Cuisinier = reader.GetInt32(reader.GetOrdinal("Id_Cuisinier")),
                    Id_Utilisateur = reader.GetInt32(reader.GetOrdinal("Id_Utilisateur")),
                    Nb_Etoile = reader.GetInt32(reader.GetOrdinal("Nb_Etoile")),
                    Avis_Cuisinier = reader.GetString(reader.GetOrdinal("Avis_Cuisinier"))
                };

                cuisiniers.Add(cuisinier);
            }
        }

        var json = JsonConvert.SerializeObject(cuisiniers, Formatting.Indented);
        File.WriteAllText("cuisiniers_from_db.json", json);
    }

    public void ExporterEntreprisesEnJson()
    {

        var entreprises = new List<Entreprise>();

        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            var query = "SELECT * FROM entreprise;";
            using var cmd = new MySqlCommand(query, connection);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var entreprise = new Entreprise
                {
                    Id_Entreprise = reader.GetInt32(reader.GetOrdinal("Id_Entreprise")),
                    Nom_Entreprise = reader.GetString(reader.GetOrdinal("Nom_Entreprise")),
                    Nom_Referent = reader.GetString(reader.GetOrdinal("Nom_Referent")),
                    Id_Client = reader.GetInt32(reader.GetOrdinal("Id_Client"))
                };

                entreprises.Add(entreprise);
            }
        }

        var json = JsonConvert.SerializeObject(entreprises, Formatting.Indented);
        File.WriteAllText("entreprises_from_db.json", json);
    }

    public void ExporterLivraisonsEnJson()
    {

        var livraisons = new List<Livraison>();

        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            var query = "SELECT * FROM livraison;";
            using var cmd = new MySqlCommand(query, connection);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var livraison = new Livraison
                {
                    Id_Livraison = reader.GetInt32(reader.GetOrdinal("Id_Livraison")),
                    Id_Cuisinier = reader.GetInt32(reader.GetOrdinal("Id_Cuisinier")),
                    Date_Livraison = reader.GetDateTime(reader.GetOrdinal("Date_Livraison")),
                    Zone_Livraison = reader.GetString(reader.GetOrdinal("Zone_Livraison"))
                };

                livraisons.Add(livraison);
            }
        }

        var json = JsonConvert.SerializeObject(livraisons, Formatting.Indented);
        File.WriteAllText("livraisons_from_db.json", json);
    }

    public void ExporterLivraisonCommandesEnJson()
    {

        var livCmdList = new List<LivraisonCommande>();

        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            var query = "SELECT * FROM livraison_commande;";
            using var cmd = new MySqlCommand(query, connection);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var livCmd = new LivraisonCommande
                {
                    Id_Livraison = reader.GetInt32(reader.GetOrdinal("Id_Livraison")),
                    Id_Commande = reader.GetInt32(reader.GetOrdinal("Id_Commande"))
                };

                livCmdList.Add(livCmd);
            }
        }

        var json = JsonConvert.SerializeObject(livCmdList, Formatting.Indented);
        File.WriteAllText("livraison_commandes_from_db.json", json);
    }

    public void ExporterRecettesEnJson()
    {

        var recettes = new List<Recette>();

        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            var query = "SELECT * FROM recette;";
            using var cmd = new MySqlCommand(query, connection);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var recette = new Recette
                {
                    Id_Recette = reader.GetInt32(reader.GetOrdinal("Id_Recette")),
                    Nom_Recette = reader.GetString(reader.GetOrdinal("Nom_Recette")),
                    Description_Recette = reader.GetString(reader.GetOrdinal("Description_Recette")),
                    Date_Creation = reader.GetDateTime(reader.GetOrdinal("Date_Creation")),
                    Id_Cuisinier = reader.GetInt32(reader.GetOrdinal("Id_Cuisinier")),
                    Id_Recette_Origine = reader["Id_Recette_Origine"] != DBNull.Value
                        ? reader.GetInt32(reader.GetOrdinal("Id_Recette_Origine"))
                        : null
                };

                recettes.Add(recette);
            }
        }

        var json = JsonConvert.SerializeObject(recettes, Formatting.Indented);
        File.WriteAllText("recettes_from_db.json", json);
    }

    public void ExporterTransactionsEnJson()
    {

        var transactions = new List<Transaction>();

        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            var query = "SELECT * FROM transaction;";
            using var cmd = new MySqlCommand(query, connection);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var transaction = new Transaction
                {
                    Id_Transaction = reader.GetInt32(reader.GetOrdinal("Id_Transaction")),
                    Montant_Total = reader.GetDecimal(reader.GetOrdinal("Montant_Total")),
                    Date_Paiement = reader.GetDateTime(reader.GetOrdinal("Date_Paiement")),
                    Moyen_Paiement = reader.GetString(reader.GetOrdinal("Moyen_Paiement"))
                };

                transactions.Add(transaction);
            }
        }

        var json = JsonConvert.SerializeObject(transactions, Formatting.Indented);
        File.WriteAllText("transactions_from_db.json", json);
    }


    public void ExporterTransactionCommandesEnJson()
    {

        var transactionCommandes = new List<TransactionCommande>();

        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            var query = "SELECT * FROM transaction_commande;";
            using var cmd = new MySqlCommand(query, connection);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var tc = new TransactionCommande
                {
                    Id_Transaction = reader.GetInt32(reader.GetOrdinal("Id_Transaction")),
                    Id_Commande = reader.GetInt32(reader.GetOrdinal("Id_Commande"))
                };

                transactionCommandes.Add(tc);
            }
        }

        var json = JsonConvert.SerializeObject(transactionCommandes, Formatting.Indented);
        File.WriteAllText("transactioncommandes_from_db.json", json);
    }

    public void ExporterUtilisateursEnJson()
    {

        var utilisateurs = new List<Utilisateur2>();

        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            var query = "SELECT * FROM utilisateur;";
            using var cmd = new MySqlCommand(query, connection);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var u = new Utilisateur2
                {
                    id_utilisateur = reader.GetInt32(reader.GetOrdinal("id_utilisateur")),
                    nom = reader.GetString(reader.GetOrdinal("nom")),
                    prenom = reader.GetString(reader.GetOrdinal("prenom")),
                    email = reader.GetString(reader.GetOrdinal("email")),
                    mot_de_passe = reader.GetString(reader.GetOrdinal("mot_de_passe")),
                    telephone = reader.GetString(reader.GetOrdinal("telephone")),
                    numero_de_rue = reader.GetInt32(reader.GetOrdinal("numero_de_rue")),
                    rue = reader.GetString(reader.GetOrdinal("rue")),
                    code_postal = reader.GetInt32(reader.GetOrdinal("code_postal")),
                    ville = reader.GetString(reader.GetOrdinal("ville")),
                    metro = reader.GetString(reader.GetOrdinal("metro"))
                };

                utilisateurs.Add(u);
            }
        }

        var json = JsonConvert.SerializeObject(utilisateurs, Formatting.Indented);
        File.WriteAllText("utilisateurs_from_db.json", json);
    }


}