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
    public  class CalificacionService:ICalificacionService
    {
        private readonly IGenericRepository<Calificacion> _calificacionRepositorio;


        private readonly IMapper _mapper;

        public CalificacionService(IGenericRepository<Calificacion> calificacionRepositorio, IMapper mapper)
        {
            _calificacionRepositorio = calificacionRepositorio;
            _mapper = mapper;
        }


        public async Task<List<CalificacionDTO>> Lista()
        {
            try
            {

                var queryCategoria = await _calificacionRepositorio.Consultar();
                var listaCategorias = queryCategoria.ToList();
                return _mapper.Map<List<CalificacionDTO>>(listaCategorias).ToList();

            }
            catch
            {
                throw;
            }
        }
        public async Task<CalificacionDTO> Crear(CalificacionDTO modelo)
        {
            try
            {
                var categoriaCreado = await _calificacionRepositorio.Crear(_mapper.Map<Calificacion>(modelo));
                if (categoriaCreado.IdCalificacion == 0)
                {
                    throw new TaskCanceledException("No se pudo crear el categoria");
                }
                return _mapper.Map<CalificacionDTO>(categoriaCreado);

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(CalificacionDTO modelo)
        {
            try
            {
                var categoriaModelo = _mapper.Map<Calificacion>(modelo);
                var categoriaEncontrado = await _calificacionRepositorio.Obtener(u => u.IdCalificacion == categoriaModelo.IdCalificacion);
                if (categoriaEncontrado == null)
                {
                    throw new TaskCanceledException("No existe el calificacion");
                }
                categoriaEncontrado.Numero = categoriaModelo.Numero;

                bool respuesta = await _calificacionRepositorio.Editar(categoriaEncontrado);
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
                var productoEncontrado = await _calificacionRepositorio.Obtener(p => p.IdCalificacion == id);
                if (productoEncontrado == null)
                {
                    throw new TaskCanceledException("El calificacion no existe");
                }
                bool respuesta = await _calificacionRepositorio.Eliminar(productoEncontrado);
                if (respuesta == false)
                {
                    throw new TaskCanceledException("El calificacion no se elimino con exito");
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
