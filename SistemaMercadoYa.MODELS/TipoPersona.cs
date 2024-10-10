using System;
using System.Collections.Generic;

namespace SistemaMercadoYa.MODELS;

public partial class TipoPersona
{
    public int IdTipoPersona { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; } = new List<Usuario>();
}
