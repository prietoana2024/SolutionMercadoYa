using System;
using System.Collections.Generic;

namespace SistemaMercadoYa.MODELS;

public partial class Factura
{
    public int IdFactura { get; set; }

    public string? Descripcion { get; set; }

    public string? Documento { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Venta> Venta { get; } = new List<Venta>();
}
