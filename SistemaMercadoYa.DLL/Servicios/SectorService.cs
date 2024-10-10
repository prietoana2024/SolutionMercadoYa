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
    public class SectorService:ISectorService
    {
        private readonly IGenericRepository<Sector> _sectorRepositorio;


        private readonly IMapper _mapper;

        public SectorService(IGenericRepository<Sector> sectorRepositorio, IMapper mapper)
        {
            _sectorRepositorio = sectorRepositorio;
            _mapper = mapper;
        }


        public async Task<List<SectorDTO>> Lista()
        {
            try
            {

                var querySector = await _sectorRepositorio.Consultar();
                var listaSectors = querySector.ToList();
                return _mapper.Map<List<SectorDTO>>(listaSectors).ToList();

            }
            catch
            {
                throw;
            }
        }
        public async Task<SectorDTO> Crear(SectorDTO modelo)
        {
            try
            {
                var SectorCreado = await _sectorRepositorio.Crear(_mapper.Map<Sector>(modelo));
                if (SectorCreado.IdSector == 0)
                {
                    throw new TaskCanceledException("No se pudo crear el Sector");
                }
                return _mapper.Map<SectorDTO>(SectorCreado);

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(SectorDTO modelo)
        {
            try
            {
                var SectorModelo = _mapper.Map<Sector>(modelo);
                var SectorEncontrado = await _sectorRepositorio.Obtener(u => u.IdSector == SectorModelo.IdSector);
                if (SectorEncontrado == null)
                {
                    throw new TaskCanceledException("No existe el Sector");
                }
                SectorEncontrado.Nombre = SectorModelo.Nombre;


                bool respuesta = await _sectorRepositorio.Editar(SectorEncontrado);
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
                var SectorEncontrado = await _sectorRepositorio.Obtener(p => p.IdSector == id);
                if (SectorEncontrado == null)
                {
                    throw new TaskCanceledException("El Sector no existe");
                }
                bool respuesta = await _sectorRepositorio.Eliminar(SectorEncontrado);
                if (respuesta == false)
                {
                    throw new TaskCanceledException("El Sector no se elimino con exito");
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
