using System;
using System.ComponentModel.DataAnnotations;

public class AccountActivity
{
    public int ActivityID { get; set; }
    public int AccountID { get; set; }
    public DateTime ActivityDate { get; set; }
    public string ActivityType { get; set; }
    public decimal Amount { get; set; }
}
