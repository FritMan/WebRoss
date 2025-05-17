using System;
using System.Collections.Generic;

namespace BlazorApp3.Data;

public partial class Vending
{
    public int Id { get; set; }

    public string Place { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int ModelId { get; set; }

    public int TypeId { get; set; }

    public int StatusId { get; set; }

    public DateTime DateInstall { get; set; }

    public int ModemId { get; set; }

    public int CompanyId { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual Model Model { get; set; } = null!;

    public virtual Modem Modem { get; set; } = null!;

    public virtual ICollection<ProductInVending> ProductInVendings { get; set; } = new List<ProductInVending>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();

    public virtual Status Status { get; set; } = null!;

    public virtual Type Type { get; set; } = null!;
}
