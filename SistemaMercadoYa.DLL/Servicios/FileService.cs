using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SistemaMercadoYa.DAL.Repositorios.Contrato;
using SistemaMercadoYa.DLL.Servicios.Contrato;
using SistemaMercadoYa.DTO;
using SistemaMercadoYa.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaMercadoYa.UTILITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace SistemaMercadoYa.DLL.Servicios
{
    public class FileService:IFileService
    {
        private readonly IGenericRepository<FileData> _fileDataRepositorio;
        private readonly IMapper _mapper;
        // private readonly UTILITY.IWebHostEnviroment environment;
        private IWebHostEnvironment environment;
        public FileService(IGenericRepository<FileData> fileDataRepositorio, IMapper mapper)
        {
            _fileDataRepositorio = fileDataRepositorio;
            _mapper = mapper;
            //this.environment = environment;
        }

        public async Task<List<FileData>> ListaImagen()
        {
            try
            {
                var queryProducto = await _fileDataRepositorio.Consultar();
                return queryProducto.ToList();
            }
            catch
            {
                throw;
            }
        }

        public async Task<FileRecordDTO> SaveFileAsync1(IFormFile imageFile)
        {
            FileRecordDTO file = new FileRecordDTO();
            if (imageFile != null)
            {
                var contentPath = this.environment.ContentRootPath;
                // path = "c://projects/productminiapi/uploads" ,not exactly something like that
                var path = Path.Combine(contentPath, "Uploads");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                    var fileName = DateTime.Now.Ticks.ToString() + Path.GetExtension(imageFile.FileName);
                    var path2 = Path.Combine(path, fileName);

                    file.Path = path;
                    file.Name = fileName;
                    file.FileFormat = Path.GetExtension(imageFile.FileName);
                    file.ContentType = imageFile.ContentType;
                    var stream = new FileStream(path2, FileMode.Create);
                    using (stream = new FileStream(path2, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }

                    imageFile.CopyTo(stream);
                    stream.Close();
                    return file;
                }
                return file;

            }
            return file;
        }

        public Tuple<int, string, string> SaveImage(IFormFile imageFile)
        {

            try
            {
                var contentPath = this.environment.ContentRootPath;
                // path = "c://projects/productminiapi/uploads" ,not exactly something like that
                var path = Path.Combine(contentPath, "Uploads");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                // Check the allowed extenstions

                var ext = Path.GetExtension(imageFile.FileName);
                var allowedExtensions = new string[] { ".jpg", ".png", ".jpeg", ".pdf", ".xls", ".xlsx", ".docx" };
                if (!allowedExtensions.Contains(ext))
                {
                    string msg = string.Format("Only {0} extensions are allowed", string.Join(",", allowedExtensions));
                    return new Tuple<int, string, string>(0, msg, "failed");
                }
                string uniqueString = Guid.NewGuid().ToString();
                // we are trying to create a unique filename here
                var newFileName = uniqueString + ext;
                var fileWithPath = Path.Combine(path, newFileName);
                var stream = new FileStream(fileWithPath, FileMode.Create);
                imageFile.CopyTo(stream);
                stream.Close();
                return new Tuple<int, string, string>(1, newFileName, fileWithPath);
            }
            catch (Exception ex)
            {
                return new Tuple<int, string, string>(0, "Error has occured", "failed");
            }
        }
        public async Task<List<FileRecordDTO>> GetAllFile()
        {

            try
            {
                /* var queryProducto = await _servicioRepositorio.Consultar();
                 var listaProductos = queryProducto.Include(cat => cat.IdCategoriaNavigation).ToList();
                 return _mapper.Map<List<ServicioDTO>>(listaProductos).ToList();*/
                var queryProducto = await _fileDataRepositorio.Consultar();
                return _mapper.Map<List<FileRecordDTO>>(queryProducto).ToList();
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> CrearFileData(FileData modelo)
        {
            try
            {
                var prospectoCreado = await _fileDataRepositorio.Crear(modelo);
                if (prospectoCreado.IdFile == 0)
                {
                    throw new TaskCanceledException("No se pudo crear el Prospecto");
                }

                return true;

            }
            catch
            {
                throw;
            }
        }
        public bool DeleteImage(string imageFileName)
        {
            try
            {
                var wwwPath = this.environment.WebRootPath;
                var path = Path.Combine(wwwPath, "Uploads\\", imageFileName);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async  Task<FileRecordDTO> DeleteFileAsync(string imageFile)
        {
            FileRecordDTO file = new FileRecordDTO();

            try
            {
                var contentPath = this.environment.ContentRootPath;
                // path = "c://projects/productminiapi/uploads" ,not exactly something like that
                var path = Path.Combine(contentPath, "Uploads", imageFile);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                // Check the allowed extenstions


                file.Path = path;
                file.Name = imageFile;
                file.FileFormat = Path.GetExtension(imageFile);
                file.ContentType = imageFile;
                //aqui termina
                return  file;
            }
            catch (Exception ex)
            {
                return file;
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                var prospectoEncontrado = await _fileDataRepositorio.Obtener(u => u.IdFile == id);
                //donde usuario encontrado en la segunda parte no lleva await 

                if (prospectoEncontrado == null)
                {
                    throw new TaskCanceledException("El prospecto no existe");
                }

                bool respuesta = await _fileDataRepositorio.Eliminar(prospectoEncontrado);

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
        public async Task<List<FileData>> Lista()
        {
            try
            {
                /* var queryProducto = await _servicioRepositorio.Consultar();
                 var listaProductos = queryProducto.Include(cat => cat.IdCategoriaNavigation).ToList();
                 return _mapper.Map<List<ServicioDTO>>(listaProductos).ToList();*/
                var queryProducto = await _fileDataRepositorio.Consultar();
                return queryProducto.ToList();
            }
            catch
            {
                throw;
            }
        }

       

       
      
    }

}
