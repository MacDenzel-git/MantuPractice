using System;
using System.Collections.Generic;

namespace MantuPractice.Domain.Models;

public  class BrandDTO
{
    public int BrandId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

 }
