using System;
using System.Collections.Generic;

namespace SistemaMercadoYa.MODELS;

public partial class Categoria
{
    public int IdCategoria { get; set; }

    public string? Nombre { get; set; }

    public bool? EsActivo { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<SubCategoria> SubCategoria { get; } = new List<SubCategoria>();
}
