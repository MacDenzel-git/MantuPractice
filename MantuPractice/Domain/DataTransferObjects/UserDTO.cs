using System;
using System.Collections.Generic;

namespace MantuPractice.Domain.Models;

public partial class UserDTO
{
    public int UserId { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public string? PasswordHash { get; set; }

    public int RoleId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? LastLogin { get; set; }

  
}
