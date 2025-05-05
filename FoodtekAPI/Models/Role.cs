using FoodtekAPI.Entites;
using System;
using System.Collections.Generic;

namespace FoodtekAPI.Models;

public partial class Role : MainEntity
{
    public int RoleId { get; set; }

    public string RoleNameEn { get; set; } = null!;

    public string RoleNameAr { get; set; } = null!;

    public virtual ICollection<Admin> Admins { get; set; } = new List<Admin>();

    public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();
}
