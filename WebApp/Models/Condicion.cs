using System;
using System.Collections.Generic;

namespace WebApp.Models;

public partial class Condicion
{
    public decimal IdCondicion { get; set; }

    public string? DescCondicion { get; set; }

    public virtual ICollection<Venta> Venta { get; } = new List<Venta>();
}
