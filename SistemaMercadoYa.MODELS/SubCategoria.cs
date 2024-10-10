using System;
using System.Collections.Generic;

namespace SistemaMercadoYa.MODELS;

public partial class SubCategoria
{
    public int IdsubCategoria { get; set; }

    public string? Nombre { get; set; }

    public int? IdCategoria { get; set; }

    public bool? EsActivo { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual Categoria? IdCategoriaNavigation { get; set; }

    public virtual ICollection<Producto> Productos { get; } = new List<Producto>();
}
