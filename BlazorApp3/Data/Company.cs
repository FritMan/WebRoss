using System;
using System.Collections.Generic;

namespace BlazorApp3.Data;

public partial class Company
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? CompanyId { get; set; }

    public string Address { get; set; } = null!;

    public string Contacts { get; set; } = null!;

    public DateTime DateCreate { get; set; }

    public virtual Company? CompanyNavigation { get; set; }

    public virtual ICollection<Company> InverseCompanyNavigation { get; set; } = new List<Company>();

    public virtual ICollection<Vending> Vendings { get; set; } = new List<Vending>();
}
