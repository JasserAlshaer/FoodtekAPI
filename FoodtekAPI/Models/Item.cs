using System;
using System.Collections.Generic;

namespace FoodtekAPI.Models;

public partial class Item
{
    public int ItemId { get; set; }

    public int CategoryId { get; set; }

    public string EnglishName { get; set; } = null!;

    public string ArabicName { get; set; } = null!;

    public string? DescriptionEn { get; set; }

    public string? DescriptionAr { get; set; }

    public string? ImagePath { get; set; }

    public decimal Price { get; set; }

    public int? StockQuantity { get; set; }

    public bool? IsActive { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<FavoriteItem> FavoriteItems { get; set; } = new List<FavoriteItem>();

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
