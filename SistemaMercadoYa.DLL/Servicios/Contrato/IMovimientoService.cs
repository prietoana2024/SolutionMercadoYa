using SistemaMercadoYa.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMercadoYa.DLL.Servicios.Contrato
{
    public interface IMovimientoService
    {
        Task<List<MovimientoDTO>> Lista();
        Task<MovimientoDTO> Crear(MovimientoDTO modelo);
        Task<bool> Editar(MovimientoDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
