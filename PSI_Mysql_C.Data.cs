using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace PSI;

public class PSI_Mysql_C_Data
{
    private MySqlConnection maConnexion;

    public PSI_Mysql_C_Data()
    {
        try
        {
            string connexionString = "SERVER=localhost;PORT=3306;" +
                                     "DATABASE=LivInParis;" +
                                     "UID=root;PASSWORD=1234qwerty";

            maConnexion = new MySqlConnection(connexionString);
            maConnexion.Open();
            Console.WriteLine("Connexion réussie.");
        }
        catch (MySqlException e)
        {
            Console.WriteLine("Erreur de connexion : " + e.Message);
            // Gérer l'exception selon les besoins
        }
    }

    // N'oubliez pas de fermer la connexion lorsque vous avez terminé
    public void FermerConnexion()
    {
        if (maConnexion != null && maConnexion.State == System.Data.ConnectionState.Open)
        {
            maConnexion.Close();
            Console.WriteLine("Connexion fermée.");
        }
    }
}