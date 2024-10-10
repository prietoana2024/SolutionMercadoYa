using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMercadoYa.DTO
{
    public class DashBoardDTO
    {
        public int? TotalVentas { get; set; }

        public string? TotalIngresos { get; set; }

        public int? TotalProductos { get; set; }

        public int? TotalCerradas { get; set; }

        public int? TotalCotizaciones { get; set; }

        public int? TotalEntregas { get; set; }

        public List<VentasSemanaDTO> VentasUltimaSemana { get; set; }

        public List<DomiciliosSemanaDTO> DomiciliosUltimaSemana { get; set; }
    }
}
