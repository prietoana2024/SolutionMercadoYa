using System;
using System.Collections.Generic;

namespace SistemaMercadoYa.MODELS;

public partial class Movimiento
{
    public int IdMovimiento { get; set; }

    public string? Nombre { get; set; }

    public decimal? Valor { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Cuenta> Cuenta { get; } = new List<Cuenta>();
}
