using System;
using System.Collections.Generic;

namespace BlazorApp3.Data;

public partial class MobilityType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Vending> Vendings { get; set; } = new List<Vending>();
}
