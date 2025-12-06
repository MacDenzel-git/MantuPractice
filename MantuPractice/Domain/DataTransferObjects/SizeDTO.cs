using System;
using System.Collections.Generic;

namespace MantuPractice.Domain.Models;

public partial class SizeDTO
{
    public int SizeId { get; set; }

    public string Code { get; set; } = null!;

    public string? Description { get; set; }

}
