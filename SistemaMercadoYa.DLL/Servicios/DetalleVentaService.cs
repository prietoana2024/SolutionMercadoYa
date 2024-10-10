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
    public class DetalleVentaService:IDetalleVentaService
    {
        private readonly IGenericRepository<Venta> _ventaRepositorio;
        private readonly IGenericRepository<Estado> _estadoRepositorio;
        private readonly IGenericRepository<Entrega> _entregaRepositorio;
        private readonly IGenericRepository<DetalleVenta> _detalleVentaRepositorio;
        private readonly IMapper _mapper;

        public DetalleVentaService(IGenericRepository<Venta> ventaRepositorio, IGenericRepository<Estado> estadoRepositorio, IGenericRepository<Entrega> entregaRepositorio, IGenericRepository<DetalleVenta> detalleVentaRepositorio, IMapper mapper)
        {
            _ventaRepositorio = ventaRepositorio;
            _estadoRepositorio = estadoRepositorio;
            _entregaRepositorio = entregaRepositorio;
            _detalleVentaRepositorio = detalleVentaRepositorio;
            _mapper = mapper;
        }

        public Task<DetalleVentaDTO> Crear(DetalleVentaDTO modelo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Editar(DetalleVentaDTO modelo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<DetalleVentaDTO>> Lista()
        {
            try
            {
                var queryDetalle = await _detalleVentaRepositorio.Consultar();
                return _mapper.Map<List<DetalleVentaDTO>>(queryDetalle).ToList();
            }
            catch
            {
                throw;
            }
        }
    }
}
