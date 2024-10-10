using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMercadoYa.DTO
{
    public class UsuarioDTO
    {
        public int IdUsuario { get; set; }

        public string? Nombre { get; set; }

        public string? Apellido { get; set; }

        public string? TipoIdentificacion { get; set; }

        public string? Identificacion { get; set; }

        public string? Celular { get; set; }

        public string? Correo { get; set; }

        public string? Whatsapp { get; set; }

        public int? IdRol { get; set; }

        public string? RolDescripcion{ get; set; }

        public string? Clave { get; set; }

        public int? IdTipoPersona { get; set; }

        public string? TipoPersonaDescripcion { get; set; }

        public string? NombreOrganizacion { get; set; }

        public string? RazonSocial { get; set; }

        public string? Nit { get; set; }

        public string? Rut { get; set; }

        public int? EsActivo { get; set; }

        public int? IdCuenta { get; set; }

        public string? CuentaDescripcion { get; set; }

        public virtual ICollection<DomicilioDTO> DomiciliosDTO { get; set; }
    }
}
