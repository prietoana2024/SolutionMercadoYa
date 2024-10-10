using System;
using System.Collections.Generic;

namespace SistemaMercadoYa.MODELS;

public partial class Cuenta
{
    public int IdCuenta { get; set; }

    public decimal? Saldo { get; set; }

    public int? IdMovimiento { get; set; }

    public virtual Movimiento? IdMovimientoNavigation { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; } = new List<Usuario>();
}
