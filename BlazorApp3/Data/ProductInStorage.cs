using System;
using System.Collections.Generic;

namespace BlazorApp3.Data;

public partial class ProductInStorage
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int StorageId { get; set; }

    public int Quantaty { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Storage Storage { get; set; } = null!;
}
