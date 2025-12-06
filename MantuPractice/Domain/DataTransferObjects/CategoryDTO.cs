using System;
using System.Collections.Generic;

namespace MantuPractice.Domain.Models;

public  class CategoryDTO
{
    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public int? ParentCategoryId { get; set; }

    public string? Description { get; set; }

    public int? SortOrder { get; set; }

    public bool? IsActive { get; set; }

  


 
}
