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
    public class EstadoService:IEstadoService
    {
        private readonly IVentaRepository _ventaRepository;
        private readonly IGenericRepository<DetalleVenta> _detalleVentaRepositorio;
        private readonly IGenericRepository<Venta> _ventaRepositorio;
        private readonly IGenericRepository<Entrega> _entregaRepositorio;
        private readonly IGenericRepository<Estado> _estadoRepositorio;
        private readonly IMapper _mapper;

        public EstadoService(IVentaRepository ventaRepository, IGenericRepository<DetalleVenta> detalleVentaRepositorio, IGenericRepository<Venta> ventaRepositorio, IGenericRepository<Entrega> entregaRepositorio, IGenericRepository<Estado> estadoRepositorio, IMapper mapper)
        {
            _ventaRepository = ventaRepository;
            _detalleVentaRepositorio = detalleVentaRepositorio;
            _ventaRepositorio = ventaRepositorio;
            _entregaRepositorio = entregaRepositorio;
            _estadoRepositorio = estadoRepositorio;
            _mapper = mapper;
        }


        public async Task<List<EstadoDTO>> Lista()
        {

            try
            {
                var queryEstado = await _estadoRepositorio.Consultar();
                var listaEstados = queryEstado.Include(u => u.DetalleVenta).Include(p => p.Entregas).ToList();
                return _mapper.Map<List<EstadoDTO>>(listaEstados);
            }
            catch
            {
                throw;
            }
        }
        public async Task<EstadoDTO> Crear(EstadoDTO modelo)
        {
            try
            {
                var estadoCreado = await _estadoRepositorio.Crear(_mapper.Map<Estado>(modelo));
                if (estadoCreado.IdEstado == 0)
                {
                    throw new TaskCanceledException("No se pudo crear el estado");
                }
                return _mapper.Map<EstadoDTO>(estadoCreado);

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(EstadoDTO modelo)
        {

            try
            {
                var estadoModelo = _mapper.Map<Estado>(modelo);
                var estadoCreado = await _estadoRepositorio.Crear(_mapper.Map<Estado>(modelo));
                var estadoEncontrado = await _estadoRepositorio.Obtener(u => u.IdEstado == estadoModelo.IdEstado);
                if (estadoEncontrado == null)
                {
                    throw new TaskCanceledException("Estado no existe");
                }

                estadoEncontrado.Nombre = estadoModelo.Nombre;


                bool respuesta = await _estadoRepositorio.Editar(estadoEncontrado);

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
                var estadoEncontrado = await _estadoRepositorio.Obtener(u => u.IdEstado == id);
                //donde usuario encontrado en la segunda parte no lleva await 

                if (estadoEncontrado == null)
                {
                    throw new TaskCanceledException("El estado no existe");
                }

                bool respuesta = await _estadoRepositorio.Eliminar(estadoEncontrado);

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
