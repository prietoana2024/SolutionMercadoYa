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
    public class TipoPersonaService:ITipoPersonaService
    {
        private readonly IGenericRepository<TipoPersona> _tipoPersonaRepositorio;


        private readonly IMapper _mapper;

        public TipoPersonaService(IGenericRepository<TipoPersona> tipoPersonaRepositorio, IMapper mapper)
        {
            _tipoPersonaRepositorio = tipoPersonaRepositorio;
            _mapper = mapper;
        }


        public async Task<List<TipoPersonaDTO>> Lista()
        {
            try
            {

                var queryTipoPersona = await _tipoPersonaRepositorio.Consultar();
                var listaTipoPersonas = queryTipoPersona.ToList();
                return _mapper.Map<List<TipoPersonaDTO>>(listaTipoPersonas).ToList();

            }
            catch
            {
                throw;
            }
        }
        public async Task<TipoPersonaDTO> Crear(TipoPersonaDTO modelo)
        {
            try
            {
                var TipoPersonaCreado = await _tipoPersonaRepositorio.Crear(_mapper.Map<TipoPersona>(modelo));
                if (TipoPersonaCreado.IdTipoPersona == 0)
                {
                    throw new TaskCanceledException("No se pudo crear el TipoPersona");
                }
                return _mapper.Map<TipoPersonaDTO>(TipoPersonaCreado);

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(TipoPersonaDTO modelo)
        {
            try
            {
                var TipoPersonaModelo = _mapper.Map<TipoPersona>(modelo);
                var TipoPersonaEncontrado = await _tipoPersonaRepositorio.Obtener(u => u.IdTipoPersona == TipoPersonaModelo.IdTipoPersona);
                if (TipoPersonaEncontrado == null)
                {
                    throw new TaskCanceledException("No existe el TipoPersona");
                }
                TipoPersonaEncontrado.Nombre = TipoPersonaModelo.Nombre;

                bool respuesta = await _tipoPersonaRepositorio.Editar(TipoPersonaEncontrado);
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
                var TipoPersonaEncontrado = await _tipoPersonaRepositorio.Obtener(p => p.IdTipoPersona == id);
                if (TipoPersonaEncontrado == null)
                {
                    throw new TaskCanceledException("El TipoPersona no existe");
                }
                bool respuesta = await _tipoPersonaRepositorio.Eliminar(TipoPersonaEncontrado);
                if (respuesta == false)
                {
                    throw new TaskCanceledException("El TipoPersona no se elimino con exito");
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
