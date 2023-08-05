using System.ComponentModel.DataAnnotations;

public class Payee
{
    public int PayeeID { get; set; }
    public int CustomerID { get; set; }
    public string PayeeName { get; set; }
    public string PayeeAddress { get; set; }
    public string PayeeCity { get; set; }
    public string PayeeState { get; set; }
    public string PayeeZipCode { get; set; }
    public string PayeeAccountNumber { get; set; }
}
