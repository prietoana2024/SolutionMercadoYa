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
    public class DomicilioService:IDomicilioService
    {
        private readonly IGenericRepository<Domicilio> _domicilioRepositorio;
        private readonly IGenericRepository<Sede> _sedeRepositorio;
        private readonly IGenericRepository<Usuario> _usuarioRepositorio;
        private readonly IMapper _mapper;

        public DomicilioService(IGenericRepository<Domicilio> domicilioRepositorio, IGenericRepository<Sede> sedeRepositorio, IGenericRepository<Usuario> usuarioRepositorio, IMapper mapper)
        {
            _domicilioRepositorio = domicilioRepositorio;
            _sedeRepositorio = sedeRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
            _mapper = mapper;
        }




        public async Task<List<DomicilioDTO>> Lista()
        {
            try
            {

                var queryDomicilio = await _domicilioRepositorio.Consultar();
                return _mapper.Map<List<DomicilioDTO>>(queryDomicilio).ToList();

            }
            catch
            {
                throw;
            }
        }
        public async Task<DomicilioDTO> Crear(DomicilioDTO modelo)
        {
            try
            {
                var DomicilioCreado = await _domicilioRepositorio.Crear(_mapper.Map<Domicilio>(modelo));
                if (DomicilioCreado.IdDomicilio == 0)
                {
                    throw new TaskCanceledException("No se pudo crear el Domicilio");
                }
                return _mapper.Map<DomicilioDTO>(DomicilioCreado);

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(DomicilioDTO modelo)
        {
            try
            {
                var DomicilioModelo = _mapper.Map<Domicilio>(modelo);
                var DomicilioEncontrado = await _domicilioRepositorio.Obtener(u => u.IdDomicilio == DomicilioModelo.IdDomicilio);
                if (DomicilioEncontrado == null)
                {
                    throw new TaskCanceledException("No existe el Domicilio");
                }
                DomicilioEncontrado.Nombre = DomicilioModelo.Nombre;
                DomicilioEncontrado.Referencia = DomicilioModelo.Referencia;
                DomicilioEncontrado.Fachada = DomicilioModelo.Fachada;
                DomicilioEncontrado.Recibe = DomicilioModelo.Recibe;
                DomicilioEncontrado.FotoRecibe = DomicilioModelo.FotoRecibe;
                DomicilioEncontrado.Coordenadas = DomicilioModelo.Coordenadas;
                DomicilioEncontrado.Celular1 = DomicilioModelo.Celular1;
                DomicilioEncontrado.Celular2 = DomicilioModelo.Celular2;
                DomicilioEncontrado.Direccion = DomicilioModelo.Direccion;

                bool respuesta = await _domicilioRepositorio.Editar(DomicilioEncontrado);
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
                var productoEncontrado = await _domicilioRepositorio.Obtener(p => p.IdDomicilio == id);
                if (productoEncontrado == null)
                {
                    throw new TaskCanceledException("La Domicilio no existe");
                }
                bool respuesta = await _domicilioRepositorio.Eliminar(productoEncontrado);
                if (respuesta == false)
                {
                    throw new TaskCanceledException("La Domicilio no se elimino con exito");
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
