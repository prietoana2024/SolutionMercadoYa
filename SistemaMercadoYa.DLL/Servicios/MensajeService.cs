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
    public class MensajeService:IMensajeService
    {
        private readonly IGenericRepository<Mensaje> _mensajeRepositorio;
        private readonly IGenericRepository<Chat> _chatRepositorio;
        private readonly IGenericRepository<Usuario> _usuarioRepositorio;

        private readonly IMapper _mapper;

        public MensajeService(IGenericRepository<Mensaje> mensajeRepositorio, IGenericRepository<Chat> chatRepositorio, IGenericRepository<Usuario> usuarioRepositorio, IMapper mapper)
        {
            _mensajeRepositorio = mensajeRepositorio;
            _chatRepositorio = chatRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
            _mapper = mapper;
        }


        public async Task<List<MensajeDTO>> Lista()
        {
            try
            {

                var queryMensaje = await _mensajeRepositorio.Consultar();
                return _mapper.Map<List<MensajeDTO>>(queryMensaje).ToList();

            }
            catch
            {
                throw;
            }
        }
        public async Task<MensajeDTO> Crear(MensajeDTO modelo)
        {
            try
            {
                var MensajeCreado = await _mensajeRepositorio.Crear(_mapper.Map<Mensaje>(modelo));
                if (MensajeCreado.IdMensaje == 0)
                {
                    throw new TaskCanceledException("No se pudo crear el Mensaje");
                }
                return _mapper.Map<MensajeDTO>(MensajeCreado);

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(MensajeDTO modelo)
        {
            try
            {
                var MensajeModelo = _mapper.Map<Mensaje>(modelo);
                var MensajeEncontrado = await _mensajeRepositorio.Obtener(u => u.IdMensaje == MensajeModelo.IdMensaje);
                if (MensajeEncontrado == null)
                {
                    throw new TaskCanceledException("No existe el Mensaje");
                }
                MensajeEncontrado.Texto = MensajeModelo.Texto;

                bool respuesta = await _mensajeRepositorio.Editar(MensajeEncontrado);
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
                var productoEncontrado = await _mensajeRepositorio.Obtener(p => p.IdMensaje == id);
                if (productoEncontrado == null)
                {
                    throw new TaskCanceledException("La Mensaje no existe");
                }
                bool respuesta = await _mensajeRepositorio.Eliminar(productoEncontrado);
                if (respuesta == false)
                {
                    throw new TaskCanceledException("La Mensaje no se elimino con exito");
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
