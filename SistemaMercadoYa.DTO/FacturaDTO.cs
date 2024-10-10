using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMercadoYa.DTO
{
   public class FacturaDTO
    {
        public int IdFactura { get; set; }

        public string? Descripcion { get; set; }

        public string? Documento { get; set; }

        public string? FechaRegistro { get; set; }
    }
}
