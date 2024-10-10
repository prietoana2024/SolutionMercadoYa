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
    public class CategoriaService:ICategoriaService
    {
        private readonly IGenericRepository<Categoria> _categoriaRepositorio;

        private readonly IGenericRepository<SubCategoria> _subCategoriaRepositorio;

        private readonly IMapper _mapper;

        public async Task<List<CategoriaDTO>> Lista()
        {
            try
            {

                var queryCategoria = await _categoriaRepositorio.Consultar();
                var listaCategorias = queryCategoria.Include(subcat => subcat.SubCategoria).ToList();
                return _mapper.Map<List<CategoriaDTO>>(listaCategorias).ToList();

            }
            catch
            {
                throw;
            }
        }
        public async Task<CategoriaDTO> Crear(CategoriaDTO modelo)
        {
            try
            {
                var categoriaCreado = await _categoriaRepositorio.Crear(_mapper.Map<Categoria>(modelo));
                if (categoriaCreado.IdCategoria == 0)
                {
                    throw new TaskCanceledException("No se pudo crear el categoria");
                }
                return _mapper.Map<CategoriaDTO>(categoriaCreado);

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(CategoriaDTO modelo)
        {
            try
            {
                var categoriaModelo = _mapper.Map<Categoria>(modelo);
                var categoriaEncontrado = await _categoriaRepositorio.Obtener(u => u.IdCategoria == categoriaModelo.IdCategoria);
                if (categoriaEncontrado == null)
                {
                    throw new TaskCanceledException("No existe el categoria");
                }
                categoriaEncontrado.Nombre = categoriaModelo.Nombre;

                bool respuesta = await _categoriaRepositorio.Editar(categoriaEncontrado);
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
                var productoEncontrado = await _categoriaRepositorio.Obtener(p => p.IdCategoria == id);
                if (productoEncontrado == null)
                {
                    throw new TaskCanceledException("La categoria no existe");
                }
                bool respuesta = await _categoriaRepositorio.Eliminar(productoEncontrado);
                if (respuesta == false)
                {
                    throw new TaskCanceledException("La categoria no se elimino con exito");
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
