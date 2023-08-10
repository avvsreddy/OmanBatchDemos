using System;
using System.Collections.Generic;

namespace DBFirstProductsApp.Entities;

public partial class Supplier
{
    public int PersonId { get; set; }

    public int Ratings { get; set; }

    public virtual Person Person { get; set; } = null!;
}
