using FoodtekAPI.Entites;
using System;
using System.Collections.Generic;

namespace FoodtekAPI.Models;

public partial class User : MainEntity
{
    public int UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? ProfileImage { get; set; }

    public int UserTypeId { get; set; }

    public int StatusId { get; set; }

    public string? OTP { get; set; }

    public DateTime? ExpireOTP { get; set; }

    public bool ?IsVerified { get; set; } = false;

    public bool ?IsLoggedIn { get; set; } = false;

    public DateTime ?LastLoggedIn { get; set; }

    public virtual Admin? Admin { get; set; }

    public virtual Client? Client { get; set; }

    public virtual Delivery? Delivery { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual LookupItem Status { get; set; } = null!;

    public virtual LookupItem UserType { get; set; } = null!;
}
