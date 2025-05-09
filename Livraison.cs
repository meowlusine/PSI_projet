namespace PSI;

public class Livraison
{
    public int Id_Livraison { get; set; }
    public int Id_Cuisinier { get; set; }
    public DateTime Date_Livraison { get; set; }
    public string Zone_Livraison { get; set; }
    public Livraison() { }
}