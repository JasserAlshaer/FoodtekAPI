using System;
using System.Collections.Generic;

namespace FoodtekAPI.Models;

public partial class Admin
{
    public int AdminId { get; set; }

    public int RoleId { get; set; }

    public DateOnly JoinDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public DateTime? LastLogin { get; set; }

    public virtual User AdminNavigation { get; set; } = null!;

    public virtual LookupItem Role { get; set; } = null!;
}
