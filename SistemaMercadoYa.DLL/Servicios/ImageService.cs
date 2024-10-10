using AutoMapper;
using SistemaMercadoYa.DAL.Repositorios.Contrato;
using SistemaMercadoYa.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaMercadoYa.DLL.Servicios.Contrato;
using SistemaMercadoYa.DTO;

namespace SistemaMercadoYa.DLL.Servicios
{
    public class ImageService:IImageService
    {
        private readonly IGenericRepository<FileData> _fileDataRepositorio;

        private readonly IGenericRepository<Imagen> _imagenRepositorio;

        private readonly IMapper _mapper;

        public ImageService(IGenericRepository<FileData> fileDataRepositorio, IGenericRepository<Imagen> imagenRepositorio, IMapper mapper)
        {
            _fileDataRepositorio = fileDataRepositorio;
            _imagenRepositorio = imagenRepositorio;
            _mapper = mapper;
        }
        public async Task<List<Imagen>> Lista()
        {

            try
            {

                var queryImagen = await _imagenRepositorio.Consultar();
                return queryImagen.ToList();
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Add(ImagenDTO modelo)
        {
            try
            {
                var imagenCreado = await _imagenRepositorio.Crear(_mapper.Map<Imagen>(modelo));
                if (imagenCreado.IdImagen == 0)
                {
                    throw new TaskCanceledException("No se pudo crear la imagen");
                }
                return true;

            }
            catch
            {
                throw;
            }
        }

        public async Task<ImagenDTO> Crear(ImagenDTO modelo)
        {
            try
            {
                var imagenCreado = await _imagenRepositorio.Crear(_mapper.Map<Imagen>(modelo));
                if (imagenCreado.IdImagen == 0)
                {
                    throw new TaskCanceledException("No se pudo crear el imagen");
                }
                return _mapper.Map<ImagenDTO>(imagenCreado);

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(ImagenDTO modelo)
        {
            try
            {
                var imagenModelo = _mapper.Map<Imagen>(modelo);
                var imagenCreado = await _imagenRepositorio.Editar(_mapper.Map<Imagen>(modelo));
                var imagenEncontrado = await _imagenRepositorio.Obtener(u => u.IdImagen == imagenModelo.IdImagen);
                if (imagenEncontrado == null)
                {
                    throw new TaskCanceledException("imagen no existe");
                }

                imagenEncontrado.Nombre = imagenModelo.Nombre;


                bool respuesta = await _imagenRepositorio.Editar(imagenEncontrado);

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
                var imagenEncontrado = await _imagenRepositorio.Obtener(u => u.IdImagen == id);
                //donde usuario encontrado en la segunda parte no lleva await 

                if (imagenEncontrado == null)
                {
                    throw new TaskCanceledException("La imagen no existe");
                }

                bool respuesta = await _imagenRepositorio.Eliminar(imagenEncontrado);

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

       
        //private IWebHostEnvironment environment;
    }
}
