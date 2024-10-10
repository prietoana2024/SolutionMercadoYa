using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMercadoYa.DTO
{
    public class MensajeDTO
    {
        public int IdMensaje { get; set; }

        public string? Texto { get; set; }

        public int? IdUsuario { get; set; }

        public string? FechaRegistro { get; set; }
    }
}
