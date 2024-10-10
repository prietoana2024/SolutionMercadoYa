using SistemaMercadoYa.DTO;
using SistemaMercadoYa.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMercadoYa.DLL.Servicios.Contrato
{
    public interface IImageService
    {
        Task<List<Imagen>> Lista();
        Task<ImagenDTO> Crear(ImagenDTO modelo);
        Task<bool> Editar(ImagenDTO modelo);
        Task<bool> Eliminar(int id);

        Task<bool> Add(ImagenDTO modelo);
    }
}
