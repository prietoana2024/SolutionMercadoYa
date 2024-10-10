using System;
using System.Collections.Generic;

namespace SistemaMercadoYa.MODELS;

public partial class Estado
{
    public int IdEstado { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<DetalleVenta> DetalleVenta { get; } = new List<DetalleVenta>();

    public virtual ICollection<Entrega> Entregas { get; } = new List<Entrega>();
}
