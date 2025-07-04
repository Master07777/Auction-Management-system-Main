using System;
using System.Collections.Generic;

namespace Factory.DatabaseLayer.Models;

public partial class User
{
    public long UserId { get; set; }

    public string Status { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
