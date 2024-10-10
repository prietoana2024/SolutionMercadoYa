using System;
using System.Collections.Generic;

namespace SistemaMercadoYa.MODELS;

public partial class Sector
{
    public int IdSector { get; set; }

    public string? Nombre { get; set; }

    public string? Url { get; set; }

    public virtual ICollection<Domicilio> Domicilios { get; } = new List<Domicilio>();
}
