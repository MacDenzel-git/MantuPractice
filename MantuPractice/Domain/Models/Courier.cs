using System;
using System.Collections.Generic;

namespace MantuPractice.Domain.Models;

public partial class Courier
{
    public int CourierId { get; set; }

    public string? Name { get; set; }

    public string? ApiEndpoint { get; set; }

    public string? ApiToken { get; set; }

    public bool? ProvidesTracking { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
