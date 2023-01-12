using System;
using System.Collections.Generic;

namespace WebApp.Models;

public partial class Cliente
{
    public decimal IdCliente { get; set; }

    public string? NombreCliente { get; set; }

    public string? DirCliente { get; set; }

    public string? CorreoCliente { get; set; }

    public decimal? TelefonoCliente { get; set; }

    public virtual ICollection<Venta> Venta { get; } = new List<Venta>();
}
