using System;
using System.Collections.Generic;

namespace MantuPractice.Domain.Models;

public partial class ProductVariant
{
    public int VariantId { get; set; }

    public int ProductId { get; set; }

    public int? SizeId { get; set; }

    public string? Sku { get; set; }

    public decimal? Price { get; set; }

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual Product Product { get; set; } = null!;

    public virtual Size? Size { get; set; }
}
