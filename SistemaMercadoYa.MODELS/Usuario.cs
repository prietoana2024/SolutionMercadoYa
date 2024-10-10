using System;
using System.Collections.Generic;

namespace SistemaMercadoYa.MODELS;

public partial class Usuario
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

    public string? Clave { get; set; }

    public int? IdTipoPersona { get; set; }

    public string? NombreOrganizacion { get; set; }

    public string? RazonSocial { get; set; }

    public string? Nit { get; set; }

    public string? Rut { get; set; }

    public bool? EsActivo { get; set; }

    public int? IdCuenta { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<DomicilioUsuario> DomicilioUsuarios { get; } = new List<DomicilioUsuario>();

    public virtual Cuenta? IdCuentaNavigation { get; set; }

    public virtual Rol? IdRolNavigation { get; set; }

    public virtual TipoPersona? IdTipoPersonaNavigation { get; set; }

    public virtual ICollection<UsuarioCalificacion> UsuarioCalificacions { get; } = new List<UsuarioCalificacion>();

    public virtual ICollection<UsuarioChat> UsuarioChats { get; } = new List<UsuarioChat>();
}
