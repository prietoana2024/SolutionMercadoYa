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
    public class SedeService : ISedeService
    {
        private readonly IGenericRepository<Sede> _sedeRepositorio;


        private readonly IMapper _mapper;

        public SedeService(IGenericRepository<Sede> sedeRepositorio, IMapper mapper)
        {
            _sedeRepositorio = sedeRepositorio;
            _mapper = mapper;
        }


        public async Task<List<SedeDTO>> Lista()
        {
            try
            {

                var querySede = await _sedeRepositorio.Consultar();
                var listaSedes = querySede.ToList();
                return _mapper.Map<List<SedeDTO>>(listaSedes).ToList();

            }
            catch
            {
                throw;
            }
        }
        public async Task<SedeDTO> Crear(SedeDTO modelo)
        {
            try
            {
                var SedeCreado = await _sedeRepositorio.Crear(_mapper.Map<Sede>(modelo));
                if (SedeCreado.IdSede == 0)
                {
                    throw new TaskCanceledException("No se pudo crear el Sede");
                }
                return _mapper.Map<SedeDTO>(SedeCreado);

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(SedeDTO modelo)
        {
            try
            {
                var SedeModelo = _mapper.Map<Sede>(modelo);
                var SedeEncontrado = await _sedeRepositorio.Obtener(u => u.IdSede == SedeModelo.IdSede);
                if (SedeEncontrado == null)
                {
                    throw new TaskCanceledException("No existe el Sede");
                }
                SedeEncontrado.Nombre = SedeModelo.Nombre;

                bool respuesta = await _sedeRepositorio.Editar(SedeEncontrado);
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
                var productoEncontrado = await _sedeRepositorio.Obtener(p => p.IdSede == id);
                if (productoEncontrado == null)
                {
                    throw new TaskCanceledException("El Sede no existe");
                }
                bool respuesta = await _sedeRepositorio.Eliminar(productoEncontrado);
                if (respuesta == false)
                {
                    throw new TaskCanceledException("El Sede no se elimino con exito");
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
