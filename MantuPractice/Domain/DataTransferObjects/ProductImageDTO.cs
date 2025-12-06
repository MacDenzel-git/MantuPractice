using System;
using System.Collections.Generic;

namespace MantuPractice.Domain.Models;

public partial class ProductImageDTO
{
    public int ImageId { get; set; }

    public int ProductId { get; set; }

    public string ImageUrl { get; set; } = null!;

    public string? AltText { get; set; }

    public int? SortOrder { get; set; }

}
