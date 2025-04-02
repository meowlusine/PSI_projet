namespace PSI;

public class AffichageConsole
{
    public static void AfficherConsole(){

        string texte = "Bienvenue sur Liv'In Paris";
        int largeurConsole = Console.WindowWidth;
        int hauteurConsole = Console.WindowHeight;

        int x = (largeurConsole / 2) - (texte.Length / 2);
        int y = hauteurConsole / 2;

        Console.SetCursorPosition(x, y);
        Console.Clear();
        Console.Write(texte);
        Console.ReadKey();

        Console.WriteLine("Avez-vous déjà un compte ? (o/n)");
        char reponse = Char.ToLower(Console.ReadKey().KeyChar);
        Console.WriteLine();

        if (reponse == 'y')
        {
            
            Console.Write("Identifiant : ");
            string identifiant = Console.ReadLine();

            Console.Write("Mot de passe : ");
            string motDePasse = Console.ReadLine();
            Console.WriteLine("Authentification en cours...");
        }
        else if (reponse == 'n')
        {
            Console.Write("Nom : ");
            string nom = Console.ReadLine();

            Console.Write("Prénom: ");
            string prenom = Console.ReadLine();

            Console.Write("Mot de passe: ");
            string motDePasse = Console.ReadLine();

            Console.Write("E-mail: ");
            string email = Console.ReadLine();

            Console.Write("Numéro de téléphone: ");
            string numeroTelephone = Console.ReadLine();

            Console.Write("Numéro de rue: ");
            string numeroRue = Console.ReadLine();

            Console.Write("Rue : ");
            string rue = Console.ReadLine();

            Console.Write("Ville: ");
            string ville = Console.ReadLine();

            Console.Write("Code postal: ");
            string codePostal = Console.ReadLine();

            Console.Write("Station de métro la plus proche: ");
            string stationMetro = Console.ReadLine();

            Console.WriteLine("Création du compte en cours...");
        }
        else
        {
            Console.WriteLine("Réponse invalide. Veuillez répondre par 'y' ou 'n'.");
        }

        Console.ReadKey(); 
        

       


    }

}