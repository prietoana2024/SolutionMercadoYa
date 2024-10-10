using SistemaMercadoYa.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMercadoYa.DLL.Servicios.Contrato
{
    public interface ICuentaService
    {
        Task<List<CuentaDTO>> Lista();
        Task<CuentaDTO> Crear(CuentaDTO modelo);
        Task<bool> Editar(CuentaDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
