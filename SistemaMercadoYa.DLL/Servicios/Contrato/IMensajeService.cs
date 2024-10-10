using SistemaMercadoYa.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMercadoYa.DLL.Servicios.Contrato
{
    public interface IMensajeService
    {
        Task<List<MensajeDTO>> Lista();
        Task<MensajeDTO> Crear(MensajeDTO modelo);
        Task<bool> Editar(MensajeDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
