using System;
using System.Collections.Generic;

namespace MantuPractice.Domain.Models;

public partial class CourierDTO
{
    public int CourierId { get; set; }

    public string? Name { get; set; }

    public string? ApiEndpoint { get; set; }

    public string? ApiToken { get; set; }

    public bool? ProvidesTracking { get; set; }


}
