using System;
using System.Collections.Generic;

namespace SistemaMercadoYa.MODELS;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string? Nombre { get; set; }

    public int? IdSubCategoria { get; set; }

    public int? Stock { get; set; }

    public decimal? PrecioNormal { get; set; }

    public string? FotoPrincipal { get; set; }

    public string? Foto1 { get; set; }

    public string? Foto2 { get; set; }

    public string? Foto3 { get; set; }

    public string? Foto4 { get; set; }

    public string? DescripcionCorta { get; set; }

    public string? DescripcionLarga { get; set; }

    public string? Etiqueta { get; set; }

    public decimal? PrecioDescuento { get; set; }

    public decimal? Precio1 { get; set; }

    public decimal? Precio2 { get; set; }

    public decimal? Precio3 { get; set; }

    public bool? EsActivo { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<DetalleVenta> DetalleVenta { get; } = new List<DetalleVenta>();

    public virtual ICollection<DivisaProducto> DivisaProductos { get; } = new List<DivisaProducto>();

    public virtual SubCategoria? IdSubCategoriaNavigation { get; set; }

    public virtual ICollection<SedeProducto> SedeProductos { get; } = new List<SedeProducto>();
}
