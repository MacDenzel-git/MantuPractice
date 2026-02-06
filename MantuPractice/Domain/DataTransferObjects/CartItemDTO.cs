using System;
using System.Collections.Generic;

namespace MantuPractice.Domain.Models;

public class CartItemDto
{
    public int CartItemId { get; set; }      // optional for Add
    public int VariantId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }   // returned in responses
    public string ProductName { get; set; } = string.Empty; // for UI
}