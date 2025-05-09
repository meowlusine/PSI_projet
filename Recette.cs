namespace PSI;

public class Recette
{
    public int Id_Recette { get; set; }
    public string Nom_Recette { get; set; }
    public string Description_Recette { get; set; }
    public DateTime Date_Creation { get; set; }
    public int Id_Cuisinier { get; set; }
    public int? Id_Recette_Origine { get; set; }
    public Recette() { }
}