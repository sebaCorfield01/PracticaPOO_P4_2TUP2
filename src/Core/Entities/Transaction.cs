namespace Core.Entities;

public class Transaction
{
    public int Id { get; set; }
    public decimal Amount { get; private set; }
    public DateTime Date { get; private set; }
    public string Notes { get; private set; }

    /* Foreign Key a Bank Account */
    

    private Transaction()
    {

    }

    public Transaction(decimal amount, DateTime date, string note)
    {
        Amount = amount;
        Date = date;
        Notes = note;
    }
}