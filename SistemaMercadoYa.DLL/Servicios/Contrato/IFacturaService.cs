using SistemaMercadoYa.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMercadoYa.DLL.Servicios.Contrato
{
    public interface IFacturaService
    {
        Task<List<FacturaDTO>> Lista();
        Task<FacturaDTO> Crear(FacturaDTO modelo);
        Task<bool> Editar(FacturaDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
