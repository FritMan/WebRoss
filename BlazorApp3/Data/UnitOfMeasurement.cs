using System;
using System.Collections.Generic;

namespace BlazorApp3.Data;

public partial class UnitOfMeasurement
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
