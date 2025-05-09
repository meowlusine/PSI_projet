namespace PSI;

public class Commande2
{
    public int Id_Commande { get; set; }
    public int Id_Cuisinier { get; set; }
    public int Id_Client { get; set; }
    public DateTime Date_Commande { get; set; }
    public int Id_Plat { get; set; }
    public Commande2() { }
}