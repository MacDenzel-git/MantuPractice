using System;
using System.Collections.Generic;

namespace MantuPractice.Domain.Models;

public partial class ProductVariantDTO
{
    public int VariantId { get; set; }

    public int ProductId { get; set; }

    public int? SizeId { get; set; }

    public string? Sku { get; set; }

    public decimal? Price { get; set; }

    
}
