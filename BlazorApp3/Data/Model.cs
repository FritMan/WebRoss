using System;
using System.Collections.Generic;

namespace BlazorApp3.Data;

public partial class Model
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? MarkId { get; set; }

    public virtual Mark? Mark { get; set; }

    public virtual ICollection<Vending> Vendings { get; set; } = new List<Vending>();
}
