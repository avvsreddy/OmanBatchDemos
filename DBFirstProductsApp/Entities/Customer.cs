using System;
using System.Collections.Generic;

namespace DBFirstProductsApp.Entities;

public partial class Customer
{
    public int PersonId { get; set; }

    public int Discount { get; set; }

    public virtual Person Person { get; set; } = null!;
}
