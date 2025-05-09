namespace PSI;

public class Plat
{
    public int Id_Plat { get; set; }
    public string Nom_Plat { get; set; }
    public double Prix { get; set; }
    public int Quantite { get; set; }
    public string Type_Plat { get; set; }
    public DateTime Date_Fabrication { get; set; }
    public DateTime Date_Peremption { get; set; }
    public string Regime { get; set; }
    public string Origine { get; set; }
    public string Description_Recette { get; set; }
    public int Id_Cuisinier { get; set; }
    public byte[] Photo { get; set; }
    public int Id_Recette { get; set; }
    public Plat() { }
}