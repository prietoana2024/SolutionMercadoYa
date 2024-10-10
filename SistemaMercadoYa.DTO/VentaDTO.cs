using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMercadoYa.DTO
{
    public class VentaDTO
    {
        public int IdVenta { get; set; }

        public string? NumeroDocumento { get; set; }

        public string? TipoPago { get; set; }

        public string? TotalTexto { get; set; }

        public string? Evidencia { get; set; }

        public int? IdEntrega { get; set; }

        public string? EntregaDescripcion { get; set; }

        public int? IdFactura { get; set; }

        public string? FacturaDescripcion { get; set; }

        public string? FechaRegistro { get; set; }

        public virtual ICollection<DetalleVentaDTO> DetalleVenta { get; set; }

    }
}
