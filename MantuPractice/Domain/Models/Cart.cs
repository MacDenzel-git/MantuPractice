using System;
using System.Collections.Generic;

namespace MantuPractice.Domain.Models;

public partial class Cart
{
    public int CartId { get; set; }
    public int? UserId { get; set; }               // null for anonymous carts (optional)
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? LastUpdatedAt { get; set; }

    public virtual ICollection<CartItem> Items { get; set; } = new List<CartItem>();
    public virtual User? User { get; set; }
}
