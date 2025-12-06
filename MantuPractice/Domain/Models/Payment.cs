using System;
using System.Collections.Generic;

namespace MantuPractice.Domain.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int OrderId { get; set; }

    public DateTime PaymentDate { get; set; }

    public decimal Amount { get; set; }

    public string? Provider { get; set; }

    public string? ProviderReference { get; set; }

    public string? Status { get; set; }

    public string? RawResponse { get; set; }

    public virtual Order Order { get; set; } = null!;
}
