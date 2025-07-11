﻿using System;
using System.Collections.Generic;

namespace Factory.DatabaseLayer.Models;

public partial class Category
{
    public long CategoryId { get; set; }

    public string? CategoryName { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
