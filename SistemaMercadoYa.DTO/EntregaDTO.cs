using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMercadoYa.DTO
{
    public class EntregaDTO
    {
        public int IdEntrega { get; set; }

        public string? Tipo { get; set; }

        public string? Sede { get; set; }

        public int? Km { get; set; }

        public int? TiempoAproximado { get; set; }

        public string? Entrega1 { get; set; }


        public int? IdDomicilio { get; set; }

        public string? DescripcionDomicilio { get; set; }

        public int? IdSede { get; set; }

        public string? DescripcionSede { get; set; }

        public int? IdEstado { get; set; }

        public string? DescripcionEstado { get; set; }

        public string? PrecioTexto { get; set; }

        public string? Evidencia { get; set; }

        public string? FechaRegistro { get; set; }


    }
}