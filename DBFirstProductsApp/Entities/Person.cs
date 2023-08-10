using System;
using System.Collections.Generic;

namespace DBFirstProductsApp.Entities;

public partial class Person
{
    public int PersonId { get; set; }

    public string? Name { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Supplier? Supplier { get; set; }
}
