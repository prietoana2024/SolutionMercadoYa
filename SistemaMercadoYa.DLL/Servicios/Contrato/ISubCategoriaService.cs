using SistemaMercadoYa.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMercadoYa.DLL.Servicios.Contrato
{
    public interface ISubCategoriaService
    {
        Task<List<SubCategoriaDTO>> Lista();

        Task<SubCategoriaDTO> Crear(SubCategoriaDTO modelo);
        Task<bool> Editar(SubCategoriaDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
