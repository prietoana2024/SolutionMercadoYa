using System;
using System.Collections.Generic;

namespace SistemaMercadoYa.MODELS;

public partial class DomicilioUsuario
{
    public int IdDomicilioUsuario { get; set; }

    public int? IdDomicilio { get; set; }

    public int? IdUsuario { get; set; }

    public virtual Domicilio? IdDomicilioNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
