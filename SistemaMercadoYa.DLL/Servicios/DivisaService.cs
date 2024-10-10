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
    public class DivisaService:IDivisaService
    {
        private readonly IGenericRepository<Divisa> _divisaRepositorio;


        private readonly IMapper _mapper;

        public DivisaService(IGenericRepository<Divisa> divisaRepositorio, IMapper mapper)
        {
            _divisaRepositorio = divisaRepositorio;
            _mapper = mapper;
        }


        public async Task<List<DivisaDTO>> Lista()
        {
            try
            {

                var queryDivisa = await _divisaRepositorio.Consultar();
                return _mapper.Map<List<DivisaDTO>>(queryDivisa).ToList();

            }
            catch
            {
                throw;
            }
        }
        public async Task<DivisaDTO> Crear(DivisaDTO modelo)
        {
            try
            {
                var DivisaCreado = await _divisaRepositorio.Crear(_mapper.Map<Divisa>(modelo));
                if (DivisaCreado.IdDivisa == 0)
                {
                    throw new TaskCanceledException("No se pudo crear el Divisa");
                }
                return _mapper.Map<DivisaDTO>(DivisaCreado);

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(DivisaDTO modelo)
        {
            try
            {
                var DivisaModelo = _mapper.Map<Divisa>(modelo);
                var DivisaEncontrado = await _divisaRepositorio.Obtener(u => u.IdDivisa == DivisaModelo.IdDivisa);
                if (DivisaEncontrado == null)
                {
                    throw new TaskCanceledException("No existe el Divisa");
                }
                DivisaEncontrado.Nombre = DivisaModelo.Nombre;

                bool respuesta = await _divisaRepositorio.Editar(DivisaEncontrado);
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
                var productoEncontrado = await _divisaRepositorio.Obtener(p => p.IdDivisa == id);
                if (productoEncontrado == null)
                {
                    throw new TaskCanceledException("La Divisa no existe");
                }
                bool respuesta = await _divisaRepositorio.Eliminar(productoEncontrado);
                if (respuesta == false)
                {
                    throw new TaskCanceledException("La Divisa no se elimino con exito");
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
