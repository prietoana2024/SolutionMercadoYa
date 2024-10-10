using SistemaMercadoYa.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMercadoYa.DLL.Servicios.Contrato
{
    public interface IDomicilioService
    {
        Task<List<DomicilioDTO>> Lista();
        Task<DomicilioDTO> Crear(DomicilioDTO modelo);
        Task<bool> Editar(DomicilioDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
