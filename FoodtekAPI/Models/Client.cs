using System;
using System.Collections.Generic;

namespace FoodtekAPI.Models;

public partial class Client
{
    public int ClientId { get; set; }

    public DateOnly? BirthDate { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual User ClientNavigation { get; set; } = null!;

    public virtual ICollection<FavoriteItem> FavoriteItems { get; set; } = new List<FavoriteItem>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<PaymentMethod> PaymentMethods { get; set; } = new List<PaymentMethod>();

    public virtual ICollection<RatingsAndReview> RatingsAndReviews { get; set; } = new List<RatingsAndReview>();

    public virtual ICollection<ReportedIssue> ReportedIssues { get; set; } = new List<ReportedIssue>();
}
