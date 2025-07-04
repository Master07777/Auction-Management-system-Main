using System;
using System.Collections.Generic;

namespace Factory.DatabaseLayer.Models;

public partial class Auction
{
    public long AuctionId { get; set; }

    public long ProductId { get; set; }

    public DateTime StartDateTime { get; set; }

    public DateTime EndDateTime { get; set; }

    public long CurrentBid { get; set; }

    public string Status { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual ICollection<Settlement> Settlements { get; set; } = new List<Settlement>();
}
