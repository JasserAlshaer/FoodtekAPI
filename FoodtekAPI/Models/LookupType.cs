using System;
using System.Collections.Generic;

namespace FoodtekAPI.Models;

public partial class LookupType
{
    public int LookupTypeId { get; set; }

    public string LookupTypeName { get; set; } = null!;

    public virtual ICollection<LookupItem> LookupItems { get; set; } = new List<LookupItem>();
}
