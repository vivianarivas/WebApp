using System;
using System.Collections.Generic;

namespace WebApp.Models;

public partial class Inmueble
{
    public decimal IdInmueble { get; set; }

    public string? DescInmueble { get; set; }

    public string? UbicacionInmueble { get; set; }

    public decimal? CostoInmueble { get; set; }

    public virtual ICollection<Venta> Venta { get; } = new List<Venta>();
}
