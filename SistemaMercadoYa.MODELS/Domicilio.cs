using System;
using System.Collections.Generic;

namespace SistemaMercadoYa.MODELS;

public partial class Domicilio
{
    public int IdDomicilio { get; set; }

    public string? Nombre { get; set; }

    public string? Direccion { get; set; }

    public string? Recibe { get; set; }

    public string? Fachada { get; set; }

    public string? Referencia { get; set; }

    public string? Fijo { get; set; }

    public string? Whatsapp { get; set; }

    public string? Celular1 { get; set; }

    public string? Celular2 { get; set; }

    public string? Notas { get; set; }

    public string? FotoRecibe { get; set; }

    public string? Coordenadas { get; set; }

    public int? IdBarrio { get; set; }

    public int? IdSector { get; set; }

    public decimal? Precio { get; set; }

    public bool? EsActivo { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<DomicilioUsuario> DomicilioUsuarios { get; } = new List<DomicilioUsuario>();

    public virtual ICollection<Entrega> Entregas { get; } = new List<Entrega>();

    public virtual Barrio? IdBarrioNavigation { get; set; }

    public virtual Sector? IdSectorNavigation { get; set; }
}
