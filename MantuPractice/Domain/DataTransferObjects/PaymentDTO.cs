using System;
using System.Collections.Generic;

namespace MantuPractice.Domain.Models;

public class PaymentDTO
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public decimal Amount { get; set; }
    public string Provider { get; set; } // PayPal, Airtel Money, Bank, Visa etc.
    public string Status { get; set; } // Pending, Paid, Failed
    public DateTime CreatedAt { get; set; }
}
