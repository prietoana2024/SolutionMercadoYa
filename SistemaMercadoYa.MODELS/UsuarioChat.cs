using System;
using System.Collections.Generic;

namespace SistemaMercadoYa.MODELS;

public partial class UsuarioChat
{
    public int IdUsuarioChat { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdChat { get; set; }

    public virtual Chat? IdChatNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
