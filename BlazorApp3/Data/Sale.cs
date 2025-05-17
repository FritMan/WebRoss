using System;
using System.Collections.Generic;

namespace BlazorApp3.Data;

public partial class Sale
{
    public int Id { get; set; }

    public int VendingId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public DateTime DatetimeSale { get; set; }

    public int PaymentId { get; set; }

    public virtual PaymentType Payment { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual Vending Vending { get; set; } = null!;
}
