namespace PSI;

public class Transaction
{
    public int Id_Transaction { get; set; }
    public decimal Montant_Total { get; set; }
    public DateTime Date_Paiement { get; set; }
    public string Moyen_Paiement { get; set; }
    public Transaction() { }
}