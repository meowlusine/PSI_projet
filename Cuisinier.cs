namespace PSI;

public class Cuisinier
{
    public int Id_Cuisinier { get; set; }
    public int Id_Utilisateur { get; set; }
    public int Nb_Etoile { get; set; }
    public string Avis_Cuisinier { get; set; }
    public Cuisinier() { }
}