﻿using System;
using System.Collections.Generic;

namespace BlazorApp3.Data;

public partial class PaymentType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
