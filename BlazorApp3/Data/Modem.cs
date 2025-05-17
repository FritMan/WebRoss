using System;
using System.Collections.Generic;

namespace BlazorApp3.Data;

public partial class Modem
{
    public int Id { get; set; }

    public int Name { get; set; }

    public virtual ICollection<Vending> Vendings { get; set; } = new List<Vending>();
}
