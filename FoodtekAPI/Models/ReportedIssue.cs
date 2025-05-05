using System;
using System.Collections.Generic;

namespace FoodtekAPI.Models;

public partial class ReportedIssue
{
    public int IssueId { get; set; }

    public int ClientId { get; set; }

    public int OrderId { get; set; }

    public int IssueTypeId { get; set; }

    public string? Description { get; set; }

    public string? Status { get; set; }

    public string? AdminResponse { get; set; }

    public virtual Client Client { get; set; } = null!;
}
