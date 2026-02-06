using System;
using System.Collections.Generic;

namespace MantuPractice.Domain.Models;

public class CartDto
{
    public int CartId { get; set; }
    public int? UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? LastUpdatedAt { get; set; }
    public List<CartItemDto> Items { get; set; } = new();
    public decimal Total => Items.Sum(i => i.UnitPrice * i.Quantity);
}
