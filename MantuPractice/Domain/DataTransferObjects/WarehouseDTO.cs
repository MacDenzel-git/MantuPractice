using System;
using System.Collections.Generic;

namespace MantuPractice.Domain.Models;

public partial class WarehouseDTO
{
    public int WarehouseId { get; set; }

    public string Name { get; set; } = null!;

    public string? Location { get; set; }

}
