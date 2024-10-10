using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMercadoYa.DTO
{
    public class ProductoDTO
    {
        public int IdProducto { get; set; }

        public string? Nombre { get; set; }

        public int? IdSubCategoria { get; set; }

        public string? DescripcionSubCategoria { get; set; }

        public int? Stock { get; set; }

        public string? PrecioNormalTexto { get; set; }

        public string? FotoPrincipal { get; set; }

        public string? Foto1 { get; set; }

        public string? Foto2 { get; set; }

        public string? Foto3 { get; set; }

        public string? Foto4 { get; set; }

        public string? DescripcionCorta { get; set; }

        public string? DescripcionLarga { get; set; }

        public string? Etiqueta { get; set; }

        public string? PrecioDescuentoTexto { get; set; }

        public string? Precio1Texto { get; set; }

        public string? Precio2Texto { get; set; }

        public string? Precio3Texto { get; set; }

        public int? EsActivo { get; set; }

        public string? FechaRegistro { get; set; }

        public virtual ICollection<DetalleVentaDTO> DetalleVenta { get; set; }

        public virtual ICollection<DivisaProductoDTO> Divisa { get; set; }

        public virtual ICollection<SedeProductoDTO> Sede { get; set; }

    }
}
