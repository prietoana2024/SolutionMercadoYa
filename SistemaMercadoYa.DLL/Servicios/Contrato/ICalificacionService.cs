using SistemaMercadoYa.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMercadoYa.DLL.Servicios.Contrato
{
    public interface ICalificacionService
    {
        Task<List<CalificacionDTO>> Lista();
        Task<CalificacionDTO> Crear(CalificacionDTO modelo);
        Task<bool> Editar(CalificacionDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
