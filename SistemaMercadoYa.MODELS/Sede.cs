using System;
using System.Collections.Generic;

namespace SistemaMercadoYa.MODELS;

public partial class Sede
{
    public int IdSede { get; set; }

    public string? Nombre { get; set; }

    public string? Direccion { get; set; }

    public string? Fachada { get; set; }

    public virtual ICollection<Entrega> Entregas { get; } = new List<Entrega>();

    public virtual ICollection<SedeProducto> SedeProductos { get; } = new List<SedeProducto>();
}
