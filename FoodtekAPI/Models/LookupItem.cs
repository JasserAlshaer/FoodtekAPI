using System;
using System.Collections.Generic;

namespace FoodtekAPI.Models;

public partial class LookupItem
{
    public int LookupItemId { get; set; }

    public int LookupTypeId { get; set; }

    public string NameEn { get; set; } = null!;

    public string NameAr { get; set; } = null!;

    public bool? IsActive { get; set; }

    public virtual ICollection<Admin> Admins { get; set; } = new List<Admin>();

    public virtual ICollection<Delivery> Deliveries { get; set; } = new List<Delivery>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual LookupType LookupType { get; set; } = null!;

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<User> UserStatuses { get; set; } = new List<User>();

    public virtual ICollection<User> UserUserTypes { get; set; } = new List<User>();
}
