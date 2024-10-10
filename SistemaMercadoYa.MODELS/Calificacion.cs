using System;
using System.Collections.Generic;

namespace SistemaMercadoYa.MODELS;

public partial class Calificacion
{
    public int IdCalificacion { get; set; }

    public int? Numero { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<UsuarioCalificacion> UsuarioCalificacions { get; } = new List<UsuarioCalificacion>();
}
