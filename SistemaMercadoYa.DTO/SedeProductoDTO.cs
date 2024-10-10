using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMercadoYa.DTO
{
    public class SedeProductoDTO
    {
        public int IdSedeProducto { get; set; }

        public int? IdSede { get; set; }

        public string? DescripcionSede { get; set; }

        public int? IdProducto { get; set; }

        public string? DescripcionProducto { get; set; }
    }
}
