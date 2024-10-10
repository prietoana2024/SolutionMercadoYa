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
    public class EntregaService:IEntregaService
    {

        private readonly IGenericRepository<Entrega> _entregaRepositorio;

        private readonly IGenericRepository<Estado> _estadoRepositorio;

        private readonly IGenericRepository<Domicilio> _domicilioRepositorio;

        private readonly IGenericRepository<Usuario> _usuarioRepositorio;

        private readonly IGenericRepository<Producto> _productoRepositorio;

        private readonly IMapper _mapper;

        public EntregaService(IGenericRepository<Entrega> entregaRepositorio, IGenericRepository<Estado> estadoRepositorio, IGenericRepository<Domicilio> domicilioRepositorio, IGenericRepository<Usuario> usuarioRepositorio, IGenericRepository<Producto> productoRepositorio, IMapper mapper)
        {
            _entregaRepositorio = entregaRepositorio;
            _estadoRepositorio = estadoRepositorio;
            _domicilioRepositorio = domicilioRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
            _productoRepositorio = productoRepositorio;
            _mapper = mapper;
        }

        public async Task<List<EntregaDTO>> Lista()
        {
            try
            {
                var queryEntrega = await _entregaRepositorio.Consultar();
                return _mapper.Map<List<EntregaDTO>>(queryEntrega).ToList();
            }
            catch
            {
                throw;
            }
        }

       /* public async  Task<EntregaDTO> Registrar(EntregaDTO modelo)
        {
           var FechaRegistro = DateTime.Now;

            if (modelo.FechaRegistro == null)
            {
                modelo.FechaRegistro = FechaRegistro.ToString("dd/MM/yyyy");
            }

            try
            {
                var entregaGenerada = await _entregaRepository.Registrar(_mapper.Map<Entrega>(modelo));
               if (entregaGenerada.Identrega == 0)
                {
                    throw new TaskCanceledException("No se pudo crear");
                }
                return _mapper.Map<EntregaDTO>(entregaGenerada);
            }
            catch
            {
                throw;
            }
        }*/

        public async Task<EntregaDTO> Crear(EntregaDTO modelo)
        {
            try
            {
                var entregaCreado = await _entregaRepositorio.Crear(_mapper.Map<Entrega>(modelo));
                if (entregaCreado.IdEntrega == 0)
                {
                    throw new TaskCanceledException("No se pudo crear el entrega");
                }
                return _mapper.Map<EntregaDTO>(entregaCreado);

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(EntregaDTO modelo)
        {
            IQueryable<Producto> query = await _productoRepositorio.Consultar();
            var listaResultado = new List<Producto>();
            var listaResultadoDTO = _mapper.Map<ProductoDTO>(listaResultado);
            try
            {
                //entrega
                var entregaModelo = _mapper.Map<Entrega>(modelo);
                var entregaEncontrado = await _entregaRepositorio.Obtener(u => u.IdEntrega == entregaModelo.IdEntrega);

                if (entregaEncontrado == null)
                {
                    throw new TaskCanceledException("No existe el entrega");
                }
                entregaEncontrado.Tipo = entregaModelo.Tipo;
                entregaEncontrado.Km = entregaModelo.Km;
                entregaEncontrado.TiempoAproximado = entregaModelo.TiempoAproximado;
                entregaEncontrado.Entrega1 = entregaModelo.Entrega1;
                entregaEncontrado.IdDomicilio = entregaModelo.IdDomicilio;
                entregaEncontrado.IdSede = entregaModelo.IdSede;
                entregaEncontrado.IdEstado = entregaModelo.IdEstado;
                entregaEncontrado.Precio = entregaModelo.Precio;
                entregaEncontrado.Evidencia = entregaModelo.Evidencia;


                bool respuesta = await _entregaRepositorio.Editar(entregaEncontrado);
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
                var entregaEncontrado = await _entregaRepositorio.Obtener(u => u.IdEntrega == id);
                //donde usuario encontrado en la segunda parte no lleva await 

                if (entregaEncontrado == null)
                {
                    throw new TaskCanceledException("La entrega no existe");
                }

                bool respuesta = await _entregaRepositorio.Eliminar(entregaEncontrado);

                if (respuesta == false)
                {
                    throw new TaskCanceledException("No se pudo eliminar");

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
