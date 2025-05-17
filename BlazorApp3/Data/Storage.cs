using System;
using System.Collections.Generic;

namespace BlazorApp3.Data;

public partial class Storage
{
    public int Id { get; set; }

    public int TypeStorageId { get; set; }

    public virtual ICollection<ProductInStorage> ProductInStorages { get; set; } = new List<ProductInStorage>();

    public virtual TypeStorage TypeStorage { get; set; } = null!;
}
