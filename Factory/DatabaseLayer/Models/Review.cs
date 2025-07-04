using System;
using System.Collections.Generic;

namespace Factory.DatabaseLayer.Models;

public partial class Review
{
    public long ReviewId { get; set; }

    public long Rating { get; set; }

    public long UserId { get; set; }

    public string? Comment { get; set; }

    public long ProductId { get; set; }

    public virtual User User { get; set; } = null!;
}
