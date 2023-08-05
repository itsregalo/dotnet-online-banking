using System.ComponentModel.DataAnnotations;

public class Account
{
    public int AccountID { get; set; }
    public int CustomerID { get; set; }
    public string AccountType { get; set; }
    public string AccountNumber { get; set; }
    public decimal Balance { get; set; }
}
