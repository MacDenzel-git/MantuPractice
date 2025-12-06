using System;
using System.Collections.Generic;

namespace MantuPractice.Domain.Models;

public partial class Order
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

    public virtual Address? BillingAddress { get; set; }

    public virtual Courier? Courier { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual Address? ShippingAddress { get; set; }

    public virtual User? User { get; set; }
}
