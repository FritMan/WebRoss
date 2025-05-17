using System;
using System.Collections.Generic;

namespace BlazorApp3.Data;

public partial class TypeStorage
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Storage> Storages { get; set; } = new List<Storage>();
}
