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
    public class BarrioService:IBarrioService
    {
        private readonly IGenericRepository<Barrio> _barrioRepositorio;


        private readonly IMapper _mapper;

        public BarrioService(IGenericRepository<Barrio> barrioRepositorio, IMapper mapper)
        {
            _barrioRepositorio = barrioRepositorio;
            _mapper = mapper;
        }


        public async Task<List<BarrioDTO>> Lista()
        {
            try
            {

                var queryCategoria = await _barrioRepositorio.Consultar();
                return _mapper.Map<List<BarrioDTO>>(queryCategoria).ToList();

            }
            catch
            {
                throw;
            }
        }
        public async Task<BarrioDTO> Crear(BarrioDTO modelo)
        {
            try
            {
                var categoriaCreado = await _barrioRepositorio.Crear(_mapper.Map<Barrio>(modelo));
                if (categoriaCreado.IdBarrio == 0)
                {
                    throw new TaskCanceledException("No se pudo crear el categoria");
                }
                return _mapper.Map<BarrioDTO>(categoriaCreado);

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(BarrioDTO modelo)
        {
            try
            {
                var categoriaModelo = _mapper.Map<Barrio>(modelo);
                var categoriaEncontrado = await _barrioRepositorio.Obtener(u => u.IdBarrio == categoriaModelo.IdBarrio);
                if (categoriaEncontrado == null)
                {
                    throw new TaskCanceledException("No existe el barrio");
                }
                categoriaEncontrado.Nombre = categoriaModelo.Nombre;

                bool respuesta = await _barrioRepositorio.Editar(categoriaEncontrado);
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
                var productoEncontrado = await _barrioRepositorio.Obtener(p => p.IdBarrio == id);
                if (productoEncontrado == null)
                {
                    throw new TaskCanceledException("El Barrio no existe");
                }
                bool respuesta = await _barrioRepositorio.Eliminar(productoEncontrado);
                if (respuesta == false)
                {
                    throw new TaskCanceledException("El barrio no se elimino con exito");
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
