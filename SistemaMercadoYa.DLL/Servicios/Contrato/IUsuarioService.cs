﻿using SistemaMercadoYa.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMercadoYa.DLL.Servicios.Contrato
{
    public interface IUsuarioService
    {
        Task<List<UsuarioDTO>> Lista();

        Task<List<UsuarioDTO>> ListaNombres();
        Task<SesionDTO> ValidarCredenciales(string Correo, string Clave);

        Task<UsuarioDTO> Crear(UsuarioDTO modelo);

        Task<bool> Editar(UsuarioDTO modelo);

        Task<bool> Eliminar(int id);

        Task<bool> EditarActivo(int id);

        Task<bool> EditarNoActivo(int id);
    }
}
