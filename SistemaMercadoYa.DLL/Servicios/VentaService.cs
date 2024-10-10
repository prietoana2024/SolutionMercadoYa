﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaMercadoYa.DAL.Repositorios.Contrato;
using SistemaMercadoYa.DLL.Servicios.Contrato;
using SistemaMercadoYa.DTO;
using SistemaMercadoYa.MODELS;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMercadoYa.DLL.Servicios
{
    public class VentaService:IVentaService
    {
        private readonly IVentaRepository _ventaRepositorio;

        private readonly IGenericRepository<DetalleVenta> _detalleVentaRepositorio;

        private readonly IMapper _mapper;

        private readonly IGenericRepository<Estado> _estadoVentaRepositorio;

        public VentaService(IVentaRepository ventaRepositorio, IGenericRepository<DetalleVenta> detalleVentaRepositorio, IMapper mapper, IGenericRepository<Estado> estadoVentaRepositorio)
        {
            _ventaRepositorio = ventaRepositorio;
            _detalleVentaRepositorio = detalleVentaRepositorio;
            _mapper = mapper;
            _estadoVentaRepositorio = estadoVentaRepositorio;
        }

        public async Task<VentaDTO> Registrar(VentaDTO modelo)
        {
            try
            {
                var ventaGenerada = await _ventaRepositorio.Registrar(_mapper.Map<Venta>(modelo));
                if (ventaGenerada.IdVenta == 0)
                {
                    throw new TaskCanceledException("No se pudo crear");
                }
                return _mapper.Map<VentaDTO>(ventaGenerada);
            }
            catch
            {
                throw;
            }
        }

        public async  Task<List<ReporteDTO>> Reporte(string fechaInicio, string fechaFin)
        {
            IQueryable<DetalleVenta> query = await _detalleVentaRepositorio.Consultar();
            //ESE RETORNA UNA LISTA DEL TIPO DETALLE VENTA
            var listaResultado = new List<DetalleVenta>();
            try
            {
                DateTime fech_Inicio = DateTime.ParseExact(fechaInicio, "dd/MM/yyyy", new CultureInfo("es-CO"));
                DateTime fech_Fin = DateTime.ParseExact(fechaFin, "dd/MM/yyyy", new CultureInfo("es-CO"));

                listaResultado = await query.Include(p => p.IdProductoNavigation).Include(v => v.IdVentaNavigation)
                    .Where(dv => dv.IdVentaNavigation!.FechaRegistro!.Value.Date >= fech_Inicio.Date &&
                    dv.IdVentaNavigation.FechaRegistro.Value.Date <= fech_Fin.Date).ToListAsync();
            }
            catch
            {
                throw;
            }
            return _mapper.Map<List<ReporteDTO>>(listaResultado);
        }

        public async Task<List<EstadoDTO>> Estado(string Nombre)
        {

            IQueryable<Estado> query = await _estadoVentaRepositorio.Consultar();
            var listaResultado = new List<Estado>();

            try
            {
                if (Nombre == "CERRADO")
                {
                    listaResultado = await query.Where(v =>
                   v.Nombre == "CERRADO").Include(dv => dv.DetalleVenta)
                   .ThenInclude(p => p.IdProductoNavigation).ToListAsync();
                }
                else if (Nombre == "ABIERTO")
                {
                    listaResultado = await query.Where(v =>
                    v.Nombre == "ABIERTO").Include(dv => dv.DetalleVenta)
                    .ThenInclude(p => p.IdProductoNavigation).ToListAsync();
                }
                else if (Nombre == "CANCELADO")
                {
                    listaResultado = await query.Where(v =>
                    v.Nombre == "CANCELADO").Include(dv => dv.DetalleVenta)
                    .ThenInclude(p => p.IdProductoNavigation).ToListAsync();
                }
                else if (Nombre == "PENDIENTE")
                {
                    listaResultado = await query.Where(v =>
                    v.Nombre == "PENDIENTE").Include(dv => dv.DetalleVenta)
                    .ThenInclude(p => p.IdProductoNavigation).ToListAsync();
                }
                else
                {
                    listaResultado = await query.Where(v =>
                     v.Nombre == "NO CUMPLE").Include(dv => dv.DetalleVenta)
                     .ThenInclude(p => p.IdProductoNavigation).ToListAsync();
                }
            }
            catch
            {
                throw;
            }
            return _mapper.Map<List<EstadoDTO>>(listaResultado);
        }

        public async Task<List<VentaDTO>> Historial(string buscarPor, string numeroVenta, string fechaInicio, string fechaFin)
        {
            IQueryable<Venta> query = await _ventaRepositorio.Consultar();
            IQueryable<DetalleVenta> queryDetalle = await _detalleVentaRepositorio.Consultar();
            var listaResultado = new List<Venta>();

            try
            {
                if (buscarPor == "fecha")
                {
                    DateTime fech_Inicio = DateTime.ParseExact(fechaInicio, "dd/MM/yyyy", new CultureInfo("es-CO"));
                    DateTime fech_Fin = DateTime.ParseExact(fechaFin, "dd/MM/yyyy", new CultureInfo("es-CO"));

                    listaResultado = await query.Where(v =>
                   v.FechaRegistro.Value.Date >= fech_Inicio.Date &&
                   v.FechaRegistro.Value.Date <= fech_Fin.Date).Include(dv => dv.DetalleVenta)
                   .ThenInclude(p => p.IdProductoNavigation).ToListAsync();


                }
                else if (buscarPor == "numero")
                {
                    listaResultado = await query.Where(v =>
                   v.NumeroDocumento == numeroVenta).Include(dv => dv.DetalleVenta)
                   .ThenInclude(p => p.IdProductoNavigation).ToListAsync();
                }
                else
                {

                }
            }
            catch
            {
                throw;
            }
            return _mapper.Map<List<VentaDTO>>(listaResultado);
        }

    }
}
