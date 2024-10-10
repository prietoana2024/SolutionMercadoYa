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
    public class ChatService:IChatService
    {
        private readonly IGenericRepository<Chat> _chatRepositorio;


        private readonly IMapper _mapper;

        public ChatService(IGenericRepository<Chat> chatRepositorio, IMapper mapper)
        {
            _chatRepositorio = chatRepositorio;
            _mapper = mapper;
        }



        public async Task<List<ChatDTO>> Lista()
        {
            try
            {

                var queryCategoria = await _chatRepositorio.Consultar();
                var listaCategorias = queryCategoria.ToList();
                return _mapper.Map<List<ChatDTO>>(listaCategorias).ToList();

            }
            catch
            {
                throw;
            }
        }
        public async Task<ChatDTO> Crear(ChatDTO modelo)
        {
            try
            {
                var categoriaCreado = await _chatRepositorio.Crear(_mapper.Map<Chat>(modelo));
                if (categoriaCreado.IdChat == 0)
                {
                    throw new TaskCanceledException("No se pudo crear el categoria");
                }
                return _mapper.Map<ChatDTO>(categoriaCreado);

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(ChatDTO modelo)
        {
            try
            {
                var categoriaModelo = _mapper.Map<Chat>(modelo);
                var categoriaEncontrado = await _chatRepositorio.Obtener(u => u.IdChat == categoriaModelo.IdChat);
                if (categoriaEncontrado == null)
                {
                    throw new TaskCanceledException("No existe el Chat");
                }
                categoriaEncontrado.Numero = categoriaModelo.Numero;

                bool respuesta = await _chatRepositorio.Editar(categoriaEncontrado);
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
                var productoEncontrado = await _chatRepositorio.Obtener(p => p.IdChat == id);
                if (productoEncontrado == null)
                {
                    throw new TaskCanceledException("El Chat no existe");
                }
                bool respuesta = await _chatRepositorio.Eliminar(productoEncontrado);
                if (respuesta == false)
                {
                    throw new TaskCanceledException("El Chat no se elimino con exito");
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
