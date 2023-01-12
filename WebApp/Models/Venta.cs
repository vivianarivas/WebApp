using System;
using System.Collections.Generic;

namespace WebApp.Models;

public partial class Venta
{
    public decimal IdVenta { get; set; }

    public decimal IdInmueble { get; set; }

    public decimal IdCliente { get; set; }

    public decimal IdCondicion { get; set; }

    public decimal IdFormaPago { get; set; }

    public string? DescVenta { get; set; }

    public decimal? TotalVenta { get; set; }

    public decimal? TotalIva { get; set; }

    public decimal? TotalVentas { get; set; }

    public decimal? TotalGral { get; set; }

    public DateTime? FechaVenta { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

   public virtual Condicion IdCondicionNavigation { get; set; } = null!;

   public virtual FormaPago IdFormaPagoNavigation { get; set; } = null!;

    public virtual Inmueble IdInmuebleNavigation { get; set; } = null!;
}
