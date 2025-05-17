using System;
using System.Collections.Generic;

namespace BlazorApp3.Data;

public partial class ProductInVending
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int VendingId { get; set; }

    public int MinQuantity { get; set; }

    public int Quantity { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Vending Vending { get; set; } = null!;
}
