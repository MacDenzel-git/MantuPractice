using System;
using System.Collections.Generic;

namespace MantuPractice.Domain.Models;

public partial class ProductDTO
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string Sku { get; set; } = null!;

    public decimal Price { get; set; }

    public decimal? Cost { get; set; }

    public int CategoryId { get; set; }

    public int? BrandId { get; set; }

    public bool? IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    
}
