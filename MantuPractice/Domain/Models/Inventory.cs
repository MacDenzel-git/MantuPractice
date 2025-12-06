using System;
using System.Collections.Generic;

namespace MantuPractice.Domain.Models;

public partial class Inventory
{
    public int InventoryId { get; set; }

    public int VariantId { get; set; }

    public int WarehouseId { get; set; }

    public int QuantityOnHand { get; set; }

    public int? ReorderLevel { get; set; }

    public virtual ProductVariant Variant { get; set; } = null!;

    public virtual Warehouse Warehouse { get; set; } = null!;
}
