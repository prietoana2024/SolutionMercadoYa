using SistemaMercadoYa.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMercadoYa.DLL.Servicios.Contrato
{
    public interface IBarrioService
    {
        Task<List<BarrioDTO>> Lista();
        Task<BarrioDTO> Crear(BarrioDTO modelo);
        Task<bool> Editar(BarrioDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
