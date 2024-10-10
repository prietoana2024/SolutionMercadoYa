using SistemaMercadoYa.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMercadoYa.DLL.Servicios.Contrato
{
    public interface IChatService
    {
        Task<List<ChatDTO>> Lista();
        Task<ChatDTO> Crear(ChatDTO modelo);
        Task<bool> Editar(ChatDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
