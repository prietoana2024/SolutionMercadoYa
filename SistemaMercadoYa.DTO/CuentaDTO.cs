using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMercadoYa.DTO
{
    public class CuentaDTO
    {
        public int IdCuenta { get; set; }

        public string? SaldoTexto { get; set; }

        public int? IdMovimiento { get; set; }

        public string? MovimientoDescripcion { get; set; }

    }
}
