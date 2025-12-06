using System;
using System.Collections.Generic;

namespace MantuPractice.Domain.Models;

public partial class OrderDTO
{
    public int OrderId { get; set; }

    public int? UserId { get; set; }

    public string OrderReference { get; set; } = null!;

    public DateTime OrderDate { get; set; }

    public string Status { get; set; } = null!;

    public int? ShippingAddressId { get; set; }

    public int? BillingAddressId { get; set; }

    public decimal TotalAmount { get; set; }

    public decimal ShippingAmount { get; set; }

    public string? PaymentMethod { get; set; }

    public string? PaymentStatus { get; set; }

    public int? CourierId { get; set; }

    public string? TrackingNumber { get; set; }

 
}
