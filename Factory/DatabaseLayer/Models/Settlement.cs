using System;
using System.Collections.Generic;

namespace Factory.DatabaseLayer.Models;

public partial class Settlement
{
    public long SettlementId { get; set; }

    public long SellerId { get; set; }

    public long BuyerId { get; set; }

    public DateTime? DateTime { get; set; }

    public string? SettlementStatus { get; set; }

    public long AuctionId { get; set; }

    public long NumberOfDaysOfSettlement { get; set; }

    public long RemainingMoney { get; set; }

    public virtual Auction Auction { get; set; } = null!;
}
