using System;
using System.Collections.Generic;

namespace FoodtekAPI.Models;

public partial class RatingsAndReview
{
    public int ReviewId { get; set; }

    public int ClientId { get; set; }

    public int OrderId { get; set; }

    public int? ItemId { get; set; }

    public int? CaptainId { get; set; }

    public int? RatingValue { get; set; }

    public string? ReviewText { get; set; }

    public virtual Client Client { get; set; } = null!;
}
