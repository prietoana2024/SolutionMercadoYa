using System;
using System.Collections.Generic;

namespace SistemaMercadoYa.MODELS;

public partial class Divisa
{
    public int IdDivisa { get; set; }

    public string? Nombre { get; set; }

    public bool? EsActivo { get; set; }

    public virtual ICollection<DivisaProducto> DivisaProductos { get; } = new List<DivisaProducto>();
}
