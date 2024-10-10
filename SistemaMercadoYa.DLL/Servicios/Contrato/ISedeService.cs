using SistemaMercadoYa.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMercadoYa.DLL.Servicios.Contrato
{
    public interface ISedeService
    {
        Task<List<SedeDTO>> Lista();
        Task<SedeDTO> Crear(SedeDTO modelo);
        Task<bool> Editar(SedeDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
