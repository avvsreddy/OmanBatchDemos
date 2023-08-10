using System;
using System.Collections.Generic;

namespace DBFirstProductsApp.Entities;

public partial class Catagory
{
    public int CatagoryId { get; set; }

    public string? CatagoryName { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
