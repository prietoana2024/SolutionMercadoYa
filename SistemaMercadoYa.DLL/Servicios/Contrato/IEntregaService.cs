using SistemaMercadoYa.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMercadoYa.DLL.Servicios.Contrato
{
    public interface IEntregaService
    {

       // Task<EntregaDTO> Registrar(EntregaDTO modelo);
        Task<List<EntregaDTO>> Lista();
        Task<EntregaDTO> Crear(EntregaDTO modelo);
        Task<bool> Editar(EntregaDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
