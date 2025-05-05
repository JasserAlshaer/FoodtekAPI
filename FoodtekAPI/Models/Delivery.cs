using FoodtekAPI.Entites;
using System;
using System.Collections.Generic;

namespace FoodtekAPI.Models;

public partial class Delivery : MainEntity
{
    public int CaptainId { get; set; }

    public int VehicleTypeId { get; set; }

    public int? NumOfCompletedDeliveries { get; set; }

    public virtual User Captain { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<OrdersTracking> OrdersTrackings { get; set; } = new List<OrdersTracking>();

    public virtual LookupItem VehicleType { get; set; } = null!;
}
