using System;
using System.Collections.Generic;

namespace MantuPractice.Domain.Models;

public partial class CartItem
{
    public int CartItemId { get; set; }
    public int CartId { get; set; }
    public virtual Cart Cart { get; set; } = null!;

    public int VariantId { get; set; }            // ties to ProductVariant from your model
    public virtual ProductVariant Variant { get; set; } = null!;

    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }        // snapshot price when added
    public DateTime AddedAt { get; set; } = DateTime.UtcNow;
}