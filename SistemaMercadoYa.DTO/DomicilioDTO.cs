using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMercadoYa.DTO
{
    public class DomicilioDTO
    {
        public int IdDomicilio { get; set; }

        public string? Nombre { get; set; }

        public string? Direccion { get; set; }

        public string? Recibe { get; set; }

        public string? Fachada { get; set; }

        public string? Referencia { get; set; }

        public string? Fijo { get; set; }

        public string? Whatsapp { get; set; }

        public string? Celular1 { get; set; }

        public string? Celular2 { get; set; }

        public string? Notas { get; set; }

        public string? FotoRecibe { get; set; }

        public string? Coordenadas { get; set; }

        public int? IdBarrio { get; set; }

        public string? DescripcionBarrio { get; set; }

        public int? IdSector { get; set; }

        public string? DescripcionSector { get; set; }

        public string? PrecioTexto { get; set; }

        public int? EsActivo { get; set; }

        public string? FechaRegistro { get; set; }


    }
}
