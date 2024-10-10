using SistemaMercadoYa.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMercadoYa.DLL.Servicios.Contrato
{
    public interface IDetalleVentaService
    {
        Task<List<DetalleVentaDTO>> Lista();
        Task<DetalleVentaDTO> Crear(DetalleVentaDTO modelo);
        Task<bool> Editar(DetalleVentaDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
