using FoodtekAPI.Entites;
using System;
using System.Collections.Generic;

namespace FoodtekAPI.Models;

public partial class Permission : MainEntity
{
    public int PermissionId { get; set; }

    public string PermissionName { get; set; } = null!;

    public string? PermissionDescription { get; set; }

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
