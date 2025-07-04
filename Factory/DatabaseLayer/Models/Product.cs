using System;
using System.Collections.Generic;

namespace Factory.DatabaseLayer.Models;

public partial class Product
{
    public long ProductId { get; set; }

    public string Name { get; set; } = null!;

    public long? CategoryId { get; set; }

    public long? SellerId { get; set; }

    public string? BasePrice { get; set; }

    public string? ExpectedPrice { get; set; }

    public virtual ICollection<Auction> Auctions { get; set; } = new List<Auction>();

    public virtual Category? Category { get; set; }

    public virtual User? Seller { get; set; }
}
