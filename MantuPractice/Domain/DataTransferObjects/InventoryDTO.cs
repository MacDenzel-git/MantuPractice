using System;
using System.Collections.Generic;

namespace MantuPractice.Domain.Models;

public partial class InventoryDTO
{
    public int InventoryId { get; set; }

    public int VariantId { get; set; }

    public int WarehouseId { get; set; }

    public int QuantityOnHand { get; set; }

    public int? ReorderLevel { get; set; }

   
}
