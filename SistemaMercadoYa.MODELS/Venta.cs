using System;
using System.Collections.Generic;

namespace SistemaMercadoYa.MODELS;

public partial class Venta
{
    public int IdVenta { get; set; }

    public string? NumeroDocumento { get; set; }

    public string? TipoPago { get; set; }

    public decimal? Total { get; set; }

    public string? Evidencia { get; set; }

    public int? IdEntrega { get; set; }

    public int? IdFactura { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<DetalleVenta> DetalleVenta { get; } = new List<DetalleVenta>();

    public virtual Entrega? IdEntregaNavigation { get; set; }

    public virtual Factura? IdFacturaNavigation { get; set; }
}
