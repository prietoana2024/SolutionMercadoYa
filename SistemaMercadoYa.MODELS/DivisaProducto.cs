using System;
using System.Collections.Generic;

namespace SistemaMercadoYa.MODELS;

public partial class DivisaProducto
{
    public int IdDivisaProducto { get; set; }

    public int? IdDivisa { get; set; }

    public int? IdProducto { get; set; }

    public virtual Divisa? IdDivisaNavigation { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }
}
