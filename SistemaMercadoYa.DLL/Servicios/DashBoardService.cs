using AutoMapper;
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
    public class DashBoardService:IDashBoardService
    {
        private readonly IVentaRepository _ventaRepositorio;

        private readonly IGenericRepository<Producto> _productoRepositorio;

        private readonly IMapper _mapper;

        private readonly IGenericRepository<Estado> _estadoVentaRepositorio;

        private readonly IGenericRepository<DetalleVenta> _detalleVentaRepositorio;

        private readonly IGenericRepository<Entrega> _entregaRepositorio;

        private readonly IGenericRepository<Domicilio> _domicilioRepositorio;

        private readonly IGenericRepository<Usuario> _usuarioRepositorio;

        private readonly IGenericRepository<Sede> _sedeRepositorio;

        public DashBoardService(IVentaRepository ventaRepositorio, IGenericRepository<Producto> productoRepositorio, IMapper mapper, IGenericRepository<Estado> estadoVentaRepositorio, IGenericRepository<DetalleVenta> detalleVentaRepositorio, IGenericRepository<Entrega> entregaRepositorio, IGenericRepository<Domicilio> domicilioRepositorio, IGenericRepository<Usuario> usuarioRepositorio, IGenericRepository<Sede> sedeRepositorio)
        {
            _ventaRepositorio = ventaRepositorio;
            _productoRepositorio = productoRepositorio;
            _mapper = mapper;
            _estadoVentaRepositorio = estadoVentaRepositorio;
            _detalleVentaRepositorio = detalleVentaRepositorio;
            _entregaRepositorio = entregaRepositorio;
            _domicilioRepositorio = domicilioRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
            _sedeRepositorio = sedeRepositorio;
        }

        private IQueryable<Entrega> RetornarCotizaciones(IQueryable<Entrega> tablaCotizacion, int restarCantidadDias)
        {
            //el ? despues de datetime significa que permitira nullos
            DateTime? ultimaFecha = tablaCotizacion.OrderByDescending(v => v.FechaRegistro).Select(v => v.FechaRegistro).First();
            //nos lo ordenará por fecha de registro
            ultimaFecha = ultimaFecha.Value.AddDays(restarCantidadDias);
            //vamos a obtener la ultima fecha encontrada y a esa fecha le vamos a restar los dias
            return tablaCotizacion.Where(v => v.FechaRegistro.Value.Date >= ultimaFecha.Value.Date);
        }
        //recibe la tabla de ventas, el siguiente
        private IQueryable<Venta> RetornarVentas(IQueryable<Venta> tablaVenta, int restarCantidadDias)
        {
            //el ? despues de datetime significa que permitira nullos
            DateTime? ultimaFecha = tablaVenta.OrderByDescending(v => v.FechaRegistro).Select(v => v.FechaRegistro).First();
            //nos lo ordenará por fecha de registro
            ultimaFecha = ultimaFecha.Value.AddDays(restarCantidadDias);
            //vamos a obtener la ultima fecha encontrada y a esa fecha le vamos a restar los dias
            return tablaVenta.Where(v => v.FechaRegistro.Value.Date >= ultimaFecha.Value.Date);
        }

        private IQueryable<Domicilio> RetornarClientes(IQueryable<Domicilio> tablaVenta, int restarCantidadDias)
        {
            //el ? despues de datetime significa que permitira nullos
            DateTime? ultimaFecha = tablaVenta.OrderByDescending(v => v.FechaRegistro).Select(v => v.FechaRegistro).First();
            //nos lo ordenará por fecha de registro
            ultimaFecha = ultimaFecha.Value.AddDays(restarCantidadDias);
            //vamos a obtener la ultima fecha encontrada y a esa fecha le vamos a restar los dias
            return tablaVenta.Where(v => v.FechaRegistro.Value.Date >= ultimaFecha.Value.Date);
        }
        //EL SIGUIENTE ES PARA MOSTRAR EN NUESTRO DASHBOARD EL NUMERO DE VENTAS, COMO UN DIGITO
        private async Task<int> TotalVentasUltimaSemana()
        {
            int total = 0;
            IQueryable<Venta> _ventaQuery = await _ventaRepositorio.Consultar();
            //validamos que si existan ventas

            if (_ventaQuery.Count() > 0)
            {
                var tablaVenta = RetornarVentas(_ventaQuery, -7);
                //vamos a obtener el total de ventas que han sido registradas estos 7 dias
                total = tablaVenta.Count();
            }
            return total;
        }

        //EL SIGUIENTE METODO MOSTRARÁ EL TOTAL DE INGRESOS DE LA ULTIMA SEMANA
        private async Task<string> TotalIngresosUltimaSemana()
        { //todo metodo retorna el tipo de aquí arriba
            decimal resultado = 0;

            IQueryable<Venta> _ventaQuery = await _ventaRepositorio.Consultar();
            //validamos que si existan ventas
            if (_ventaQuery.Count() > 0)
            {
                var tablaVenta = RetornarVentas(_ventaQuery, -7);
                //vamos a obtener el total de ventas que han sido registradas estos 7 dias
                resultado = tablaVenta.Select(v => v.Total).Sum(v => v.Value);
            }
            return Convert.ToString(resultado, new CultureInfo("es-CO"));
        }

        private async Task<int> TotalEntregasUltimaSemana()
        { //todo metodo retorna el tipo de aquí arriba
            int resultado = 0;

            IQueryable<Entrega> _cotizacionQuery = await _entregaRepositorio.Consultar();


            /* IQueryable<DetalleVenta> _detalleQuery = await _detalleVentaRepositorio.Consultar();
             int totalDetalle = _detalleQuery.Count();*/

            //validamos que si existan ventas
            if (_cotizacionQuery.Count() > 0)
            {
                var tablaVenta = RetornarCotizaciones(_cotizacionQuery, -7);
                //vamos a obtener el total de ventas que han sido registradas estos 7 dias
                resultado = tablaVenta.Count();
            }
            return resultado;
        }
        private async Task<int> MisProspectosUltimaSemana(int id)
        { //todo metodo retorna el tipo de aquí arriba
            int resultado = 5;

            IQueryable<Sede> _prospectoQuery2 = await _sedeRepositorio.Consultar(u => u.IdSede == id);
            //var cotizacionEncontrado = await _cotizacionRepositorio.Obtener(u => u.IdCotizacion == cotizacionModelo.IdCotizacion);

            //IQueryable <Prospecto> _prospectoQuery = await _prospectoRepositorio.Consultar(u => u.Idauditor == id);

            //var prospectoEncontrado = await _prospectoRepositorio.Obtener(u => u.Idauditor == id);
            //List<Prospecto> lstInsert = new List<Prospecto>();

            resultado = _prospectoQuery2.Count();


            /*foreach (Prospecto dv in _prospectoQuery)
            {
                Cotizacion servicio_encontrado = _cotizacionQuery.Where(p => p.IdProspecto == dv.IdProspecto).First();
                //Prospecto _prospectoQuery = _cotizacionQuery.Where(p => p.IdProspecto == dv.IdProspecto).First();
                //Servicio servicio_encontrado = _dbContext.Servicios.Where(p => p.IdServicio == dv.IdServicio).First();

                //_dbContext.Servicios.Update(servicio_encontrado);
            }*/
            /*foreach (Prospecto v in _prospectoQuery)
            {
                Cotizacion cotizacionEncontrada = _cotizacionQuery.Where(p => p.IdProspecto == v.IdProspecto).First();
            }*/
            /* IQueryable<DetalleVenta> _detalleQuery = await _detalleVentaRepositorio.Consultar();
             int totalDetalle = _detalleQuery.Count();*/

            //validamos que si existan ventas
            /*if (_cotizacionQuery.Count() > 0)
            {
                var tablaVenta = RetornarCotizaciones(_cotizacionQuery, -7);
                //vamos a obtener el total de ventas que han sido registradas estos 7 dias
                resultado = tablaVenta.Count();
            }*/
            return resultado;
        }

        private async Task<int> TotalCerradas()
        { //todo metodo retorna el tipo de aquí arriba
            IQueryable<DetalleVenta> _detalleQuery = await _detalleVentaRepositorio.Consultar();
            int totalDetalle = _detalleQuery.Count();

            int sumatoria = 0;

            int metrosCuadrados = 0;

            int metrosCuadrados2 = 0;

            for (int c = 0; c < totalDetalle; c++)
            {
                foreach (var d in _detalleQuery)
                {
                    if (d.IdEstado == 2)
                    {
                        sumatoria = +1;
                        metrosCuadrados = metrosCuadrados + sumatoria;
                    }

                }
                metrosCuadrados2 = metrosCuadrados2 + metrosCuadrados;
                //  return metrosCuadrados2;
            }
            int resultado = metrosCuadrados2;
            return resultado;
        }
        /*
        private async Task<int> TotalProspectosUltimaSemana()
        { //todo metodo retorna el tipo de aquí arriba
            int resultado = 0;

            IQueryable<Prospecto> _prospectoQuery = await _prospectoRepositorio.Consultar();


            /* IQueryable<DetalleVenta> _detalleQuery = await _detalleVentaRepositorio.Consultar();
             int totalDetalle = _detalleQuery.Count();*/

            //validamos que si existan ventas*/
          /*  if (_prospectoQuery.Count() > 0)
            {
                resultado = _prospectoQuery.Count();
            }
            return resultado;
        }*/

        private async Task<int> TotalServicios()
        {
            IQueryable<DetalleVenta> _detalleQuery = await _detalleVentaRepositorio.Consultar();
            int totalDetalle = _detalleQuery.Count();

            int sumatoria;

            int metrosCuadrados = 0;

            int metrosCuadrados2 = 0;

            for (int c = 0; c < totalDetalle; c++)
            {
                foreach (var d in _detalleQuery)
                {

                    sumatoria = d.Cantidad.HasValue ? d.Cantidad.Value : 0;
                    metrosCuadrados = metrosCuadrados + sumatoria;

                }
                metrosCuadrados2 = metrosCuadrados2 + metrosCuadrados;
                //  return metrosCuadrados2;
            }
            // return total;

            // IQueryable<Servicio> _productoQuery = await _servicioRepositorio.Consultar();
            // int total = _productoQuery.Count();
            return metrosCuadrados2;
        }
        private async Task<Dictionary<string, int>> ventasUltimaSemana()
        {
            //variable diccionario oara ingresar es un string
            Dictionary<string, int> resultado = new Dictionary<string, int>();
            IQueryable<Venta> _ventaQuery = await _ventaRepositorio.Consultar();

            if (_ventaQuery.Count() > 0)
            {
                var tablaVenta = RetornarVentas(_ventaQuery, -7);

                resultado = tablaVenta
                    .GroupBy(v => v.FechaRegistro.Value.Date)
                    .OrderBy(g => g.Key)
                    .Select(dv => new { fecha = dv.Key.ToString("dd/MM/yyyy"), total = dv.Count() })
                    .ToDictionary(keySelector: r => r.fecha, elementSelector: r => r.total);
            }
            return resultado;
        }

        private async Task<Dictionary<string, int>> domiciliosUltimaSemana()
        {
            //variable diccionario oara ingresar es un string
            Dictionary<string, int> resultado = new Dictionary<string, int>();
            IQueryable<Domicilio> _clienteQuery = await _domicilioRepositorio.Consultar();


            if (_clienteQuery.Count() > 0)
            {
                var tablaVenta = RetornarClientes(_clienteQuery, -7);

                resultado = tablaVenta
                    .GroupBy(v => v.FechaRegistro.Value.Date)
                    .OrderBy(g => g.Key)
                    .Select(dv => new { fecha = dv.Key.ToString("dd/MM/yyyy"), total = dv.Count() })
                    .ToDictionary(keySelector: r => r.fecha, elementSelector: r => r.total);
            }
            return resultado;
        }
        /* public async Task<int> TotalCerradas(string Nombre)
         {


             IQueryable<Estado> _estadooQueryCerrado = await _estadoVentaRepositorio.Consultar();
             int total = _estadooQueryCerrado.Count();


             try
             {
                 if (Nombre == "CERRADO")
                 {
                     int totalCerradas = _estadooQueryCerrado.Count();
                     return total;
                 }
                 else {
                     return total;

                 }
             }
             catch
             {
                 throw;
             }

         }
     */
        public async Task<DashBoardDTO> Resumen()
        {
            DashBoardDTO vmDashboard = new DashBoardDTO();
            try
            {
                vmDashboard.TotalVentas = await TotalVentasUltimaSemana();
                vmDashboard.TotalIngresos = await TotalIngresosUltimaSemana();
                vmDashboard.TotalProductos = await TotalServicios();
                vmDashboard.TotalCerradas = await TotalCerradas();
                vmDashboard.TotalEntregas = await TotalEntregasUltimaSemana();

                List<VentasSemanaDTO> listaVentaSemana = new List<VentasSemanaDTO>();
                List<DomiciliosSemanaDTO> listaClienteSemana = new List<DomiciliosSemanaDTO>();

                foreach (KeyValuePair<string, int> item in await ventasUltimaSemana())
                {
                    listaVentaSemana.Add(new VentasSemanaDTO()
                    {
                        Fecha = item.Key,
                        Total = item.Value
                    });
                }
                vmDashboard.VentasUltimaSemana = listaVentaSemana;

                foreach (KeyValuePair<string, int> item in await domiciliosUltimaSemana())
                {
                    listaClienteSemana.Add(new DomiciliosSemanaDTO()
                    {
                        Fecha = item.Key,
                        Total = item.Value
                    });
                }
                vmDashboard.DomiciliosUltimaSemana = listaClienteSemana;
            }
            catch
            {
                throw;
            }
            return vmDashboard;
        }

        public async Task<DashBoardDTO> MiResumen(int id)
        {
            DashBoardDTO vmDashboard = new DashBoardDTO();
            try
            {
                vmDashboard.TotalVentas = await TotalVentasUltimaSemana();
                vmDashboard.TotalIngresos = await TotalIngresosUltimaSemana();
                vmDashboard.TotalProductos = await TotalServicios();
                vmDashboard.TotalCerradas = await TotalCerradas();
               /*vmDashboard.TotalEntregas = await MisProspectosUltimaSemana(id);
                vmDashboard.TotalProspectos = await TotalProspectosUltimaSemana();
               */

                List<VentasSemanaDTO> listaVentaSemana = new List<VentasSemanaDTO>();
                List<DomiciliosSemanaDTO> listaClienteSemana = new List<DomiciliosSemanaDTO>();

                foreach (KeyValuePair<string, int> item in await ventasUltimaSemana())
                {
                    listaVentaSemana.Add(new VentasSemanaDTO()
                    {
                        Fecha = item.Key,
                        Total = item.Value
                    });
                }
                vmDashboard.VentasUltimaSemana = listaVentaSemana;

                foreach (KeyValuePair<string, int> item in await domiciliosUltimaSemana())
                {
                    listaClienteSemana.Add(new DomiciliosSemanaDTO()
                    {
                        Fecha = item.Key,
                        Total = item.Value
                    });
                }
                vmDashboard.DomiciliosUltimaSemana = listaClienteSemana;
            }
            catch
            {
                throw;
            }
            return vmDashboard;
        }
    }
}
