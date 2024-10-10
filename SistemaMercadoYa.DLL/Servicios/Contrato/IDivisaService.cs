using SistemaMercadoYa.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMercadoYa.DLL.Servicios.Contrato
{
    public interface IDivisaService
    {
        Task<List<DivisaDTO>> Lista();
        Task<DivisaDTO> Crear(DivisaDTO modelo);
        Task<bool> Editar(DivisaDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
