using System;
using System.Collections.Generic;

namespace SistemaMercadoYa.MODELS;

public partial class SedeProducto
{
    public int IdSedeProducto { get; set; }

    public int? IdSede { get; set; }

    public int? IdProducto { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }

    public virtual Sede? IdSedeNavigation { get; set; }
}
