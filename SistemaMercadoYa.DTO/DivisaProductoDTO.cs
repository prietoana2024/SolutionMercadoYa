using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMercadoYa.DTO
{
    public  class DivisaProductoDTO
    {
        public int IdDivisaProducto { get; set; }

        public int? IdDivisa { get; set; }


        public string? DescripcionDivisa { get; set; }

        public int? IdProducto { get; set; }

        public string? DescripcionProducto { get; set; }
    }
}
