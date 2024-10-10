using AutoMapper;
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
    public class SubCategoriaService : ISubCategoriaService
    {
        private readonly IGenericRepository<SubCategoria> _subCategoriaRepositorio;

        private readonly IGenericRepository<Categoria> _categoriaRepositorio;

        private readonly IGenericRepository<Producto> _productoRepositorio;

        private readonly IMapper _mapper;

        public SubCategoriaService(IGenericRepository<SubCategoria> subCategoriaRepositorio, IGenericRepository<Categoria> categoriaRepositorio, IGenericRepository<Producto> productoRepositorio, IMapper mapper)
        {
            _subCategoriaRepositorio = subCategoriaRepositorio;
            _categoriaRepositorio = categoriaRepositorio;
            _productoRepositorio = productoRepositorio;
            _mapper = mapper;
        }
        public async Task<List<SubCategoriaDTO>> Lista()
        {
            try
            {
                var listaSubCategorias = await _subCategoriaRepositorio.Consultar();
                return _mapper.Map<List<SubCategoriaDTO>>(listaSubCategorias.ToList());
            }
            catch
            {
                throw;
            }
        }
        public async Task<SubCategoriaDTO> Crear(SubCategoriaDTO modelo)
        {
            try
            {
                var subCategoriaCreado = await _subCategoriaRepositorio.Crear(_mapper.Map<SubCategoria>(modelo));
                if (subCategoriaCreado.IdsubCategoria == 0)
                {
                    throw new TaskCanceledException("No se pudo crear la subcategoria");
                }
                return _mapper.Map<SubCategoriaDTO>(subCategoriaCreado);

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(SubCategoriaDTO modelo)
        {

            try
            {
                var subCategoriaModelo = _mapper.Map<SubCategoria>(modelo);
                var subCategoriaEncontrado = await _subCategoriaRepositorio.Obtener(u => u.IdsubCategoria == subCategoriaModelo.IdsubCategoria);
                if (subCategoriaEncontrado == null)
                {
                    throw new TaskCanceledException("No existe la subcategoria");
                }
                subCategoriaEncontrado.Nombre = subCategoriaModelo.Nombre;

                bool respuesta = await _subCategoriaRepositorio.Editar(subCategoriaEncontrado);
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
                var subCategoriaEncontrado = await _subCategoriaRepositorio.Obtener(p => p.IdsubCategoria == id);
                if (subCategoriaEncontrado == null)
                {
                    throw new TaskCanceledException("La subcategoria no existe");
                }
                bool respuesta = await _subCategoriaRepositorio.Eliminar(subCategoriaEncontrado);
                if (respuesta == false)
                {
                    throw new TaskCanceledException("La subcategoria  no se elimino con exito");
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
