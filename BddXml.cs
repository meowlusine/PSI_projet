using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Data;
using MySql.Data.MySqlClient;

namespace PSI;


public class ExportXMLHandler
{
    private static string mdp = "kakawete";

    string connectionString = "server=localhost;database=LivInParis;uid=root;pwd=" + mdp;

    /// <summary>
    /// Exporter la table utilisateur de la bdd en fichier xml
    /// </summary>
    /// <param name="fichierDestination"></param>
    public void ExportUtilisateursToXML(string fichierDestination)
    {
        List<Utilisateur2> utilisateurs = new List<Utilisateur2>();


        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT * FROM utilisateur";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Utilisateur2 u = new Utilisateur2
                    {
                        id_utilisateur = reader.GetInt32("id_utilisateur"),
                        nom = reader.GetString("nom"),
                        prenom = reader.GetString("prenom"),
                        email = reader.GetString("email"),
                        mot_de_passe = reader.GetString("mot_de_passe"),
                        telephone = reader.GetString("telephone"),
                        numero_de_rue = reader.GetInt32("numero_de_rue"),
                        rue = reader.GetString("rue"),
                        code_postal = reader.GetInt32("code_postal"),
                        ville = reader.GetString("ville"),
                        metro = reader.GetString("metro")
                    };
                    utilisateurs.Add(u);
                }
            }



        }


        XmlSerializer serializer = new XmlSerializer(typeof(List<Utilisateur2>));
        using (TextWriter writer = new StreamWriter(fichierDestination))
        {
            serializer.Serialize(writer, utilisateurs);
        }

    }

    /// <summary>
    /// Exporter la table cuisinier de la bdd en fichier xml
    /// </summary>
    /// <param name="fichierDestination"></param>
    public void ExportCuisiniersToXML(string fichierDestination)
    {
        List<Cuisinier> cuisiniers = new List<Cuisinier>();

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT * FROM cuisinier";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Cuisinier c = new Cuisinier
                    {
                        Id_Cuisinier = reader.GetInt32("id_cuisinier"),
                        Id_Utilisateur = reader.GetInt32("id_utilisateur"),
                        
                       
                    };
                    cuisiniers.Add(c);
                }
            }
        }
        XmlSerializer serializer2 = new XmlSerializer(typeof(List<Cuisinier>));

        using (TextWriter writer = new StreamWriter(fichierDestination))
        {
            serializer2.Serialize(writer, cuisiniers);
        }

    }


    public void ExportClientsToXML(string fichierDestination)
    {
        List<Client> clients = new List<Client>();

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT * FROM client";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Client c = new Client
                    {
                        Id_Client = reader.GetInt32("id_client"),
                        Id_Utilisateur = reader.GetInt32("id_utilisateur"),
                        Type_Client = reader.GetString("type_client")
                    };
                    clients.Add(c);
                }
            }
        }

        XmlSerializer serializer = new XmlSerializer(typeof(List<Client>));

        using (TextWriter writer = new StreamWriter(fichierDestination))
        {
            serializer.Serialize(writer, clients);
        }

    }


    public void ExportRecettesToXML(string fichierDestination)
    {
        List<Recette> recettes = new List<Recette>();

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT * FROM recette";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Recette r = new Recette
                    {
                        Id_Recette = reader.GetInt32("id_recette"),
                        Nom_Recette = reader.GetString("nom_recette"),
                        Description_Recette = reader.GetString("description_recette"),
                        Date_Creation = reader.GetDateTime("date_creation"),
                        Id_Cuisinier = reader.GetInt32("id_cuisinier"),
                        Id_Recette_Origine = reader.IsDBNull(reader.GetOrdinal("id_recette_origine")) ? null : (int?)reader.GetInt32("id_recette_origine")
                    };
                    recettes.Add(r);
                }
            }
        }

        XmlSerializer serializer = new XmlSerializer(typeof(List<Recette>));

        using (TextWriter writer = new StreamWriter(fichierDestination))
        {
            serializer.Serialize(writer, recettes);
        }
    }


    public void ExportCommandesToXML(string fichierDestination)
    {
        List<Commande2> commandes = new List<Commande2>();

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT * FROM commande";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Commande2 c = new Commande2
                    {
                        Id_Commande = reader.GetInt32("id_commande"),
                        Id_Cuisinier = reader.GetInt32("id_cuisinier"),
                        Id_Client = reader.GetInt32("id_client"),
                        Date_Commande = reader.GetDateTime("date_commande"),
                        Id_Plat = reader.GetInt32("id_plat")
                    };
                    commandes.Add(c);
                }
            }
        }

        XmlSerializer serializer = new XmlSerializer(typeof(List<Commande2>));

        using (TextWriter writer = new StreamWriter(fichierDestination))
        {
            serializer.Serialize(writer, commandes);
        }

    }


    public void ExportEntreprisesToXML(string fichierDestination)
    {
        List<Entreprise> entreprises = new List<Entreprise>();

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT * FROM entreprise";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Entreprise e = new Entreprise
                    {
                        Id_Entreprise = reader.GetInt32("id_entreprise"),
                        Nom_Entreprise = reader.GetString("nom_entreprise"),
                        Nom_Referent = reader.GetString("nom_referent"),
                        Id_Client = reader.GetInt32("id_client")
                    };
                    entreprises.Add(e);
                }
            }
        }

        XmlSerializer serializer = new XmlSerializer(typeof(List<Entreprise>));

        using (TextWriter writer = new StreamWriter(fichierDestination))
        {
            serializer.Serialize(writer, entreprises);
        }

    }


    public void ExportLivraisonsToXML(string fichierDestination)
    {
        List<Livraison> livraisons = new List<Livraison>();

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT * FROM livraison";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Livraison l = new Livraison
                    {
                        Id_Livraison = reader.GetInt32("id_livraison"),
                        Id_Cuisinier = reader.GetInt32("id_cuisinier"),
                        Date_Livraison = reader.GetDateTime("date_livraison"),
                        Zone_Livraison = reader.GetString("zone_livraison")
                    };
                    livraisons.Add(l);
                }
            }
        }

        XmlSerializer serializer = new XmlSerializer(typeof(List<Livraison>));

        using (TextWriter writer = new StreamWriter(fichierDestination))
        {
            serializer.Serialize(writer, livraisons);
        }

    }

    public void ExportLivraisonCommandesToXML(string fichierDestination)
    {
        List<LivraisonCommande> livraisonCommandes = new List<LivraisonCommande>();

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT * FROM livraison_commande";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    LivraisonCommande lc = new LivraisonCommande
                    {
                        Id_Livraison = reader.GetInt32("id_livraison"),
                        Id_Commande = reader.GetInt32("id_commande")
                    };
                    livraisonCommandes.Add(lc);
                }
            }
        }

        XmlSerializer serializer = new XmlSerializer(typeof(List<LivraisonCommande>));

        using (TextWriter writer = new StreamWriter(fichierDestination))
        {
            serializer.Serialize(writer, livraisonCommandes);
        }

    }

    public void ExportPlatsToXML(string fichierDestination)
    {
        List<Plat> plats = new List<Plat>();

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT * FROM plat";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            using (MySqlDataReader reader = command.ExecuteReader())
            {
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
        }

        XmlSerializer serializer = new XmlSerializer(typeof(List<Plat>));
        using (TextWriter writer = new StreamWriter(fichierDestination))
        {
            serializer.Serialize(writer, plats);
        }

    }


    public void ExportTransactionsToXML(string fichierDestination)
    {
        List<Transaction> transactions = new List<Transaction>();

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT * FROM transaction";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Transaction t = new Transaction();

                    int idIndex = reader.GetOrdinal("id_transaction");
                    if (!reader.IsDBNull(idIndex))
                        t.Id_Transaction = reader.GetInt32(idIndex);
                    else
                        t.Id_Transaction = 0;

                    int montantIndex = reader.GetOrdinal("montant_total");
                    if (!reader.IsDBNull(montantIndex))
                        t.Montant_Total = reader.GetDecimal(montantIndex);
                    else
                        t.Montant_Total = 0m;

                    int dateIndex = reader.GetOrdinal("date_paiement");
                    if (!reader.IsDBNull(dateIndex))
                        t.Date_Paiement = reader.GetDateTime(dateIndex);
                    else
                        t.Date_Paiement = new DateTime(1900, 1, 1);

                    int moyenIndex = reader.GetOrdinal("moyen_paiement");
                    if (!reader.IsDBNull(moyenIndex))
                        t.Moyen_Paiement = reader.GetString(moyenIndex);
                    else
                        t.Moyen_Paiement = "";

                    transactions.Add(t);
                }
            }
        }

        XmlSerializer serializer = new XmlSerializer(typeof(List<Transaction>));
        using (TextWriter writer = new StreamWriter(fichierDestination))
        {
            serializer.Serialize(writer, transactions);
        }

    }

    public void ExportTransactionCommandesToXML(string fichierDestination)
    {
        List<TransactionCommande> transactionCommandes = new List<TransactionCommande>();

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT * FROM transaction_commande";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    TransactionCommande tc = new TransactionCommande
                    {
                        Id_Transaction = reader.GetInt32("id_transaction"),
                        Id_Commande = reader.GetInt32("id_commande")
                    };
                    transactionCommandes.Add(tc);
                }
            }
        }

        XmlSerializer serializer = new XmlSerializer(typeof(List<TransactionCommande>));
        using (TextWriter writer = new StreamWriter(fichierDestination))
        {
            serializer.Serialize(writer, transactionCommandes);
        }

    }


}
