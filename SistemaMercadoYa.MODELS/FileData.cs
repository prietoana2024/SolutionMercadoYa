using System;
using System.Collections.Generic;

namespace SistemaMercadoYa.MODELS;

public partial class FileData
{
    public int IdFile { get; set; }

    public string? Name { get; set; }

    public string? Extension { get; set; }

    public string? MimeType { get; set; }

    public string? Path { get; set; }

    public int? IdImagen { get; set; }

    public virtual Imagen? IdImagenNavigation { get; set; }
}
