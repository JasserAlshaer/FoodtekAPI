using FoodtekAPI.Entites;
using System;
using System.Collections.Generic;

namespace FoodtekAPI.Models;

public partial class Employee : MainEntity
{
    public int EmployeeId { get; set; }

    public int RoleId { get; set; }

    public DateOnly JoinDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public virtual User EmployeeNavigation { get; set; } = null!;

    public virtual LookupItem Role { get; set; } = null!;
}
