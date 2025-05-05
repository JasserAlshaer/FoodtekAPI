using System;
using System.Collections.Generic;

namespace FoodtekAPI.Models;

public partial class OrdersTracking
{
    public int TrackingId { get; set; }

    public int? OrderId { get; set; }

    public int CaptainId { get; set; }

    public string? CurrentStatus { get; set; }

    public string? LastUpdatedLocation { get; set; }

    public DateTime? EstimatedArrivalTime { get; set; }

    public virtual Delivery Captain { get; set; } = null!;

    public virtual Order? Order { get; set; }
}
