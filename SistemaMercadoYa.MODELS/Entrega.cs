using System;
using System.Collections.Generic;

namespace SistemaMercadoYa.MODELS;

public partial class Entrega
{
    public int IdEntrega { get; set; }

    public string? Tipo { get; set; }

    public string? Sede { get; set; }

    public int? Km { get; set; }

    public int? TiempoAproximado { get; set; }

    public DateTime? Entrega1 { get; set; }

    public int? IdDomicilio { get; set; }

    public int? IdSede { get; set; }

    public int? IdEstado { get; set; }

    public decimal? Precio { get; set; }

    public string? Evidencia { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual Domicilio? IdDomicilioNavigation { get; set; }

    public virtual Estado? IdEstadoNavigation { get; set; }

    public virtual Sede? IdSedeNavigation { get; set; }

    public virtual ICollection<Venta> Venta { get; } = new List<Venta>();
}
