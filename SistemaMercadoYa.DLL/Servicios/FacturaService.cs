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
    public class FacturaService:IFacturaService
    {
        private readonly IGenericRepository<Factura> _facturaRepositorio;
        private readonly IMapper _mapper;

        public FacturaService(IGenericRepository<Factura> facturaRepositorio, IMapper mapper)
        {
            _facturaRepositorio = facturaRepositorio;
            _mapper = mapper;
        }


        public async Task<List<FacturaDTO>> Lista()
        {
            try
            {

                var queryFactura = await _facturaRepositorio.Consultar();
                return _mapper.Map<List<FacturaDTO>>(queryFactura).ToList();

            }
            catch
            {
                throw;
            }
        }
        public async Task<FacturaDTO> Crear(FacturaDTO modelo)
        {
            try
            {
                var FacturaCreado = await _facturaRepositorio.Crear(_mapper.Map<Factura>(modelo));
                if (FacturaCreado.IdFactura == 0)
                {
                    throw new TaskCanceledException("No se pudo crear el Factura");
                }
                return _mapper.Map<FacturaDTO>(FacturaCreado);

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(FacturaDTO modelo)
        {
            try
            {
                var FacturaModelo = _mapper.Map<Factura>(modelo);
                var FacturaEncontrado = await _facturaRepositorio.Obtener(u => u.IdFactura == FacturaModelo.IdFactura);
                if (FacturaEncontrado == null)
                {
                    throw new TaskCanceledException("No existe el Factura");
                }
                FacturaEncontrado.Descripcion = FacturaModelo.Descripcion;
                FacturaEncontrado.Documento = FacturaModelo.Documento;

                bool respuesta = await _facturaRepositorio.Editar(FacturaEncontrado);
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
                var productoEncontrado = await _facturaRepositorio.Obtener(p => p.IdFactura == id);
                if (productoEncontrado == null)
                {
                    throw new TaskCanceledException("La Factura no existe");
                }
                bool respuesta = await _facturaRepositorio.Eliminar(productoEncontrado);
                if (respuesta == false)
                {
                    throw new TaskCanceledException("La Factura no se elimino con exito");
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
