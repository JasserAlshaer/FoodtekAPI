using FoodtekAPI.Entites;
using System;
using System.Collections.Generic;

namespace FoodtekAPI.Models;

public partial class PaymentMethod : MainEntity
{
    public int PaymentMethodId { get; set; }

    public int ClientId { get; set; }

    public int CardTypeId { get; set; }

    public string Last4Digits { get; set; } = null!;

    public DateOnly ExpiryDate { get; set; }

    public bool? IsDefault { get; set; }

    public virtual Client Client { get; set; } = null!;
}
