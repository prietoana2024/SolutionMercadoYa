using SistemaMercadoYa.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMercadoYa.DLL.Servicios.Contrato
{
    public interface ISectorService
    {
        Task<List<SectorDTO>> Lista();
        Task<SectorDTO> Crear(SectorDTO modelo);
        Task<bool> Editar(SectorDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
