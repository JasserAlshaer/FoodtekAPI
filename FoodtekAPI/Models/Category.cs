using System;
using System.Collections.Generic;

namespace FoodtekAPI.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string NameEn { get; set; } = null!;

    public string NameAr { get; set; } = null!;

    public string? ImagePath { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
