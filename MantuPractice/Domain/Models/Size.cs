using System;
using System.Collections.Generic;

namespace MantuPractice.Domain.Models;

public partial class Size
{
    public int SizeId { get; set; }

    public string Code { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<ProductVariant> ProductVariants { get; set; } = new List<ProductVariant>();
}
