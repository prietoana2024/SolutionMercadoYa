using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaMercadoYa.DAL.Repositorios.Contrato;
using SistemaMercadoYa.DLL.Servicios.Contrato;
using SistemaMercadoYa.DTO;
using SistemaMercadoYa.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMercadoYa.DLL.Servicios
{
    public class ProductoService:IProductoService
    {
        private readonly IGenericRepository<SubCategoria> _subCategoriaRepositorio;

        private readonly IGenericRepository<Producto> _productoRepositorio;

        private readonly IMapper _mapper;

        public ProductoService(IGenericRepository<SubCategoria> subCategoriaRepositorio, IGenericRepository<Producto> productoRepositorio, IMapper mapper)
        {
            _subCategoriaRepositorio = subCategoriaRepositorio;
            _productoRepositorio = productoRepositorio;
            _mapper = mapper;
        }
        public async Task<List<ProductoDTO>> Lista()
        {
            try
            {
                var queryProducto = await _productoRepositorio.Consultar();
                var listaProductos = queryProducto.Include(subcat =>subcat.IdSubCategoriaNavigation).Include(cat=>cat.SedeProductos).ToList();
                return _mapper.Map<List<ProductoDTO>>(listaProductos).ToList();
            }
            catch
            {
                throw;
            }
        }
        public async Task<ProductoDTO> Crear(ProductoDTO modelo)
        {
            try
            {
                var productoCreado = await _productoRepositorio.Crear(_mapper.Map<Producto>(modelo));
                if (productoCreado.IdProducto == 0)
                {
                    throw new TaskCanceledException("No se pudo crear el Servicio");
                }
                return _mapper.Map<ProductoDTO>(productoCreado);

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(ProductoDTO modelo)
        {
            try
            {
                var productoModelo = _mapper.Map<Producto>(modelo);
                var productoEncontrado = await _productoRepositorio.Obtener(u => u.IdProducto == productoModelo.IdProducto);
                if (productoEncontrado == null)
                {
                    throw new TaskCanceledException("No existe el Producto");
                }
                productoEncontrado.Nombre = productoModelo.Nombre;
                productoEncontrado.FotoPrincipal= productoModelo.FotoPrincipal;
                productoEncontrado.IdSubCategoria = productoModelo.IdSubCategoria;
                productoEncontrado.PrecioNormal = productoModelo.PrecioNormal;
                productoEncontrado.PrecioDescuento = productoModelo.PrecioDescuento;
                productoEncontrado.Precio1 = productoModelo.Precio1;
                productoEncontrado.Precio2 = productoModelo.Precio2;
                productoEncontrado.Precio3 = productoModelo.Precio3;
                productoEncontrado.EsActivo = productoModelo.EsActivo;

                bool respuesta = await _productoRepositorio.Editar(productoEncontrado);
                if (respuesta == false)
                {
                    throw new TaskCanceledException("No se pudo editar");
                }
                return respuesta;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                var productoEncontrado = await _productoRepositorio.Obtener(p => p.IdProducto == id);
                if (productoEncontrado == null)
                {
                    throw new TaskCanceledException("El producto no existe");
                }
                bool respuesta = await _productoRepositorio.Eliminar(productoEncontrado);
                if (respuesta == false)
                {
                    throw new TaskCanceledException("El producto no se elimino con exito");
                }
                return respuesta;
            }
            catch
            {
                throw;
            }
        }

       
    }
}
