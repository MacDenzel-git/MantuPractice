using System;
using System.Collections.Generic;

namespace MantuPractice.Domain.Models;

public partial class OrderItemDTO
{
    public int OrderItemId { get; set; }

    public int OrderId { get; set; }

    public int VariantId { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal? Discount { get; set; }

    public decimal? TotalPrice { get; set; }

}
