using System;
using System.Collections.Generic;

namespace SistemaMercadoYa.MODELS;

public partial class Mensaje
{
    public int IdMensaje { get; set; }

    public string? Texto { get; set; }

    public int? IdUsuario { get; set; }

    public DateTime? FechaRegistro { get; set; }
}
