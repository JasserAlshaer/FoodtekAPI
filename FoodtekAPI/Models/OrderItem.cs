using FoodtekAPI.Entites;
using System;
using System.Collections.Generic;

namespace FoodtekAPI.Models;

public partial class OrderItem : MainEntity
{
    public int OrderId { get; set; }

    public int ItemId { get; set; }

    public int? Quantity { get; set; }

    public virtual Item Item { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
