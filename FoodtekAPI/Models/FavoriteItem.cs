using System;
using System.Collections.Generic;

namespace FoodtekAPI.Models;

public partial class FavoriteItem
{
    public int ClientId { get; set; }

    public int ItemId { get; set; }

    public int Id { get; set; }

    public string? CreatedBy { get; set; }

    public DateOnly? CreatedDate { get; set; }

    public DateOnly? UpdateDate { get; set; }

    public string? UpdatedBy { get; set; }

    public bool? IsActive { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual Item Item { get; set; } = null!;
}
