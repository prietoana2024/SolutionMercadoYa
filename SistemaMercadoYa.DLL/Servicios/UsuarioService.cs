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
    public class UsuarioService:IUsuarioService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Usuario> _usuarioRepositorio;

        public UsuarioService(IMapper mapper, IGenericRepository<Usuario> usuarioRepositorio)
        {
            _mapper = mapper;
            _usuarioRepositorio = usuarioRepositorio;
        }
        public async Task<List<UsuarioDTO>> Lista()
        {
            try
            {
                var queryUsuario = await _usuarioRepositorio.Consultar();
                var listaUsuarios = queryUsuario.Include(rol => rol.IdRolNavigation).ToList();
                return _mapper.Map<List<UsuarioDTO>>(listaUsuarios);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<UsuarioDTO>> ListaNombres()
        {
            try
            {
                var queryUsuario = await _usuarioRepositorio.Consultar();
                return _mapper.Map<List<UsuarioDTO>>(queryUsuario);
            }
            catch
            {
                throw;
            }
        }
        public async Task<UsuarioDTO> Crear(UsuarioDTO modelo)
        {
            try
            {
                //nuestro usuariocreado recibe un usuario, pero no es del tipo dto, asi que para recibirlo en _usuarioRepositorio debemos covertirlo, así lo aceptará el modelo
                var UsuarioCreado = await _usuarioRepositorio.Crear(_mapper.Map<Usuario>(modelo));
                if (UsuarioCreado.IdUsuario == 0)
                {
                    throw new TaskCanceledException("Usuario no se pudo crear");
                }
                //con el await obtenemos, si es cero el usuario fallo, sino, continuaria aquí
                var query = await _usuarioRepositorio.Consultar(u => u.IdUsuario == UsuarioCreado.IdUsuario);
                UsuarioCreado = query.Include(rol => rol.IdRolNavigation).First();
                return _mapper.Map<UsuarioDTO>(UsuarioCreado);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(UsuarioDTO modelo)
        {
            try
            {
                var usuarioModelo = _mapper.Map<Usuario>(modelo);
                var usuarioEncontrado = await _usuarioRepositorio.Obtener(u => u.IdUsuario == usuarioModelo.IdUsuario);

                if (usuarioEncontrado == null)
                {
                    throw new TaskCanceledException("Usuario no existe");
                }
                usuarioEncontrado.Nombre = usuarioModelo.Nombre;
                usuarioEncontrado.Apellido = usuarioModelo.Apellido;
                usuarioEncontrado.Correo = usuarioModelo.Correo;
                usuarioEncontrado.IdRol = usuarioModelo.IdRol;
                usuarioEncontrado.Clave = usuarioModelo.Clave;
                usuarioEncontrado.EsActivo = usuarioModelo.EsActivo;

                bool respuesta = await _usuarioRepositorio.Editar(usuarioEncontrado);

                if (!respuesta)
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

        public async Task<bool> EditarActivo(int id)
        {
            try
            {
                var usuarioEncontrado = await _usuarioRepositorio.Obtener(u => u.IdUsuario == id);
                //donde usuario encontrado en la segunda parte no lleva await 

                if (usuarioEncontrado == null)
                {
                    throw new TaskCanceledException("El usuario no existe");
                }
                usuarioEncontrado.EsActivo = true;

                bool respuesta = await _usuarioRepositorio.Editar(usuarioEncontrado);



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

        public async Task<bool> EditarNoActivo(int id)
        {
            try
            {
                var usuarioEncontrado = await _usuarioRepositorio.Obtener(u => u.IdUsuario == id);
                //donde usuario encontrado en la segunda parte no lleva await 

                if (usuarioEncontrado == null)
                {
                    throw new TaskCanceledException("El usuario no existe");
                }
                usuarioEncontrado.EsActivo = false;

                bool respuesta = await _usuarioRepositorio.Editar(usuarioEncontrado);



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

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                var usuarioEncontrado = await _usuarioRepositorio.Obtener(u => u.IdUsuario == id);
                //donde usuario encontrado en la segunda parte no lleva await 

                if (usuarioEncontrado == null)
                {
                    throw new TaskCanceledException("El usuario no existe");
                }
                bool respuesta = await _usuarioRepositorio.Eliminar(usuarioEncontrado);

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

        

        public async Task<SesionDTO> ValidarCredenciales(string Correo, string Clave)
        {
            try
            {
                var queryUsuario = await _usuarioRepositorio.Consultar(u => u.Correo == Correo && u.Clave == Clave);
                if (queryUsuario.FirstOrDefault() == null)
                {
                    throw new TaskCanceledException("El usuario no existe");

                }
                Usuario devolverUsuario = queryUsuario.Include(rol => rol.IdRolNavigation).First();
                //este usuario de la linea de arriba o devolver usuario, es del tipo Usuario, asi que debemos pasarlo por mapper y convertirlo de tipo SesionDTO
                return _mapper.Map<SesionDTO>(devolverUsuario);


            }
            catch
            {
                throw;
            }
        }
    }
}
