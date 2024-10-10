using System;
using System.Collections.Generic;

namespace SistemaMercadoYa.MODELS;

public partial class Imagen
{
    public int IdImagen { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<FileData> FileData { get; } = new List<FileData>();
}
