using System;
using System.Collections.Generic;

namespace WebApp.Models;

public partial class FormaPago
{
    public decimal IdFormaPago { get; set; }

    public string? DescFormaPago { get; set; }

    public virtual ICollection<Venta> Venta { get; } = new List<Venta>();
}
