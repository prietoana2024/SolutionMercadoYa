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
    public class CuentaService:ICuentaService
    {
        private readonly IGenericRepository<Cuenta> _cuentaRepositorio;

        private readonly IGenericRepository<Usuario> _usuarioRepositorio;

        private readonly IMapper _mapper;

        public CuentaService(IGenericRepository<Cuenta> cuentaRepositorio, IGenericRepository<Usuario> usuarioRepositorio, IMapper mapper)
        {
            _cuentaRepositorio = cuentaRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
            _mapper = mapper;
        }
        public async Task<List<CuentaDTO>> Lista()
        {
            try
            {

                var queryCuenta = await _cuentaRepositorio.Consultar();
                return _mapper.Map<List<CuentaDTO>>(queryCuenta).ToList();

            }
            catch
            {
                throw;
            }
        }
        public async Task<CuentaDTO> Crear(CuentaDTO modelo)
        {
            try
            {
                var CuentaCreado = await _cuentaRepositorio.Crear(_mapper.Map<Cuenta>(modelo));
                if (CuentaCreado.IdCuenta == 0)
                {
                    throw new TaskCanceledException("No se pudo crear el Cuenta");
                }
                return _mapper.Map<CuentaDTO>(CuentaCreado);

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(CuentaDTO modelo)
        {
            try
            {
                var CuentaModelo = _mapper.Map<Cuenta>(modelo);
                var CuentaEncontrado = await _cuentaRepositorio.Obtener(u => u.IdCuenta == CuentaModelo.IdCuenta);
                if (CuentaEncontrado == null)
                {
                    throw new TaskCanceledException("No existe el Cuenta");
                }
                CuentaEncontrado.Saldo = CuentaModelo.Saldo;
                CuentaEncontrado.IdMovimiento = CuentaModelo.IdMovimiento;

                bool respuesta = await _cuentaRepositorio.Editar(CuentaEncontrado);
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
                var productoEncontrado = await _cuentaRepositorio.Obtener(p => p.IdCuenta == id);
                if (productoEncontrado == null)
                {
                    throw new TaskCanceledException("La Cuenta no existe");
                }
                bool respuesta = await _cuentaRepositorio.Eliminar(productoEncontrado);
                if (respuesta == false)
                {
                    throw new TaskCanceledException("La Cuenta no se elimino con exito");
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
