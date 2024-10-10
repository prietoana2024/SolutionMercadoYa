using SistemaMercadoYa.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMercadoYa.DLL.Servicios.Contrato
{
    public interface ITipoPersonaService
    {
        Task<List<TipoPersonaDTO>> Lista();
        Task<TipoPersonaDTO> Crear(TipoPersonaDTO modelo);
        Task<bool> Editar(TipoPersonaDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
