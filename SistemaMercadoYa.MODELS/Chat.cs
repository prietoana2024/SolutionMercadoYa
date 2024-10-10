using System;
using System.Collections.Generic;

namespace SistemaMercadoYa.MODELS;

public partial class Chat
{
    public int IdChat { get; set; }

    public string? Numero { get; set; }

    public string? Titulo { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<UsuarioChat> UsuarioChats { get; } = new List<UsuarioChat>();
}
