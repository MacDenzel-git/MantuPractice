using System;
using System.Collections.Generic;

namespace MantuPractice.Domain.Models;

public class Payment
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public decimal Amount { get; set; }
    public string Provider { get; set; }
    public string Status { get; set; }
    public DateTime CreatedAt { get; set; }

    public Order Order { get; set; }
}
