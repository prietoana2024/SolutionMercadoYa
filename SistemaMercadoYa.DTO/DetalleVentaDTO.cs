using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMercadoYa.DTO
{
    public class DetalleVentaDTO
    {
        public int IdDetalleVenta { get; set; }

        public int? IdVenta { get; set; }

        public int? IdProducto { get; set; }

        public string? DescripcionProducto { get; set; }

        public int? IdEstado { get; set; }

        public string? DescripcionEstado { get; set; }

        public int? Cantidad { get; set; }

        public string? PrecioTexto { get; set; }

        public string? ImpuestoTexto { get; set; }

        public string? DomicilioTexto { get; set; }

        public string? TotalTexto { get; set; }
    }
}
