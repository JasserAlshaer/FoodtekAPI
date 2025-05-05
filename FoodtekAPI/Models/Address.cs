using FoodtekAPI.Entites;
using System;
using System.Collections.Generic;

namespace FoodtekAPI.Models;

public partial class Address: MainEntity
{
    public int AddressId { get; set; }

    public int ClientId { get; set; }

    public int RegionId { get; set; }

    public int ProvinceId { get; set; }

    public string? AddressDetails { get; set; }

    public string? Gpslocation { get; set; }

    public string? Title { get; set; }

    public virtual Client Client { get; set; } = null!;
}
