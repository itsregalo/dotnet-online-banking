using System;
using System.ComponentModel.DataAnnotations;

public class PaymentHistory
{
    public int PaymentID { get; set; }
    public int CustomerID { get; set; }
    public int PayeeID { get; set; }
    public DateTime PaymentDate { get; set; }
    public decimal Amount { get; set; }
}
