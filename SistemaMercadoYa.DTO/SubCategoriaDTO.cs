using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMercadoYa.DTO
{
    public class SubCategoriaDTO
    {
        public int IdsubCategoria { get; set; }

        public string? Nombre { get; set; }

        public int? IdCategoria { get; set; }

        public string? CategoriaDescripcion { get; set; }

        public int? EsActivo { get; set; }

        public string? FechaRegistro { get; set; }

    }
}
