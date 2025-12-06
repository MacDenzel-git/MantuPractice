using System;
using System.Collections.Generic;

namespace MantuPractice.Domain.Models;

public partial class RoleDTO
{
    public int RoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public string? Description { get; set; }

}
