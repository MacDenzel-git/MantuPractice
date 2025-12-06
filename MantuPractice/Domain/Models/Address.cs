using System;
using System.Collections.Generic;

namespace MantuPractice.Domain.Models;

public partial class Address
{
    public int AddressId { get; set; }

    public int? UserId { get; set; }

    public string? RecipientName { get; set; }

    public string? Phone { get; set; }

    public string? AddressLine1 { get; set; }

    public string? AddressLine2 { get; set; }

    public string? City { get; set; }

    public string? Region { get; set; }

    public string? PostalCode { get; set; }

    public string? Country { get; set; }

    public string? Type { get; set; }

    public virtual ICollection<Order> OrderBillingAddresses { get; set; } = new List<Order>();

    public virtual ICollection<Order> OrderShippingAddresses { get; set; } = new List<Order>();

    public virtual User? User { get; set; }
}
