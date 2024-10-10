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
    public class MovimientoService : IMovimientoService
    {
        private readonly IGenericRepository<Movimiento> _movimientoRepositorio;

        private readonly IMapper _mapper;

        public MovimientoService(IGenericRepository<Movimiento> movimientoRepositorio, IMapper mapper)
        {
            _movimientoRepositorio = movimientoRepositorio;
            _mapper = mapper;
        }

        public async Task<List<MovimientoDTO>> Lista()
        {
            try
            {

                var queryMovimiento = await _movimientoRepositorio.Consultar();
                return _mapper.Map<List<MovimientoDTO>>(queryMovimiento).ToList();

            }
            catch
            {
                throw;
            }
        }
        public async Task<MovimientoDTO> Crear(MovimientoDTO modelo)
        {
            try
            {
                var MovimientoCreado = await _movimientoRepositorio.Crear(_mapper.Map<Movimiento>(modelo));
                if (MovimientoCreado.IdMovimiento == 0)
                {
                    throw new TaskCanceledException("No se pudo crear el Movimiento");
                }
                return _mapper.Map<MovimientoDTO>(MovimientoCreado);

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(MovimientoDTO modelo)
        {
            try
            {
                var MovimientoModelo = _mapper.Map<Movimiento>(modelo);
                var MovimientoEncontrado = await _movimientoRepositorio.Obtener(u => u.IdMovimiento == MovimientoModelo.IdMovimiento);
                if (MovimientoEncontrado == null)
                {
                    throw new TaskCanceledException("No existe el Movimiento");
                }
                MovimientoEncontrado.Valor = MovimientoModelo.Valor;
                MovimientoEncontrado.Nombre = MovimientoModelo.Nombre;

                bool respuesta = await _movimientoRepositorio.Editar(MovimientoEncontrado);
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
                var productoEncontrado = await _movimientoRepositorio.Obtener(p => p.IdMovimiento == id);
                if (productoEncontrado == null)
                {
                    throw new TaskCanceledException("La Movimiento no existe");
                }
                bool respuesta = await _movimientoRepositorio.Eliminar(productoEncontrado);
                if (respuesta == false)
                {
                    throw new TaskCanceledException("La Movimiento no se elimino con exito");
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
