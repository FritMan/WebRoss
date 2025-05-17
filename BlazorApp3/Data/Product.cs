using System;
using System.Collections.Generic;

namespace BlazorApp3.Data;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Cost { get; set; }

    public string Description { get; set; } = null!;

    public int? UnitId { get; set; }

    public virtual ICollection<ProductInStorage> ProductInStorages { get; set; } = new List<ProductInStorage>();

    public virtual ICollection<ProductInVending> ProductInVendings { get; set; } = new List<ProductInVending>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    public virtual UnitOfMeasurement? Unit { get; set; }
}
