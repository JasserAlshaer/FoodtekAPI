using FoodtekAPI.Entites;
using System;
using System.Collections.Generic;

namespace FoodtekAPI.Models;

public partial class Notification : MainEntity
{
    public int NotificationId { get; set; }

    public int ReceiverId { get; set; }

    public string? Title { get; set; }

    public string? Message { get; set; }

    public int NotificationTypeId { get; set; }

    public bool? IsRead { get; set; }

    public virtual LookupItem NotificationType { get; set; } = null!;

    public virtual User Receiver { get; set; } = null!;
}
