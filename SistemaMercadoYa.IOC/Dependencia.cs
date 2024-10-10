using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaMercadoYa.DAL.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaMercadoYa.DAL.Repositorios.Contrato;
using SistemaMercadoYa.DAL.Repositorios;
using SistemaMercadoYa.UTILITY;
using SistemaMercadoYa.DLL.Servicios.Contrato;
using SistemaMercadoYa.DLL.Servicios;

namespace SistemaMercadoYa.IOC
{
    public static class Dependencia
    {
        public static void InyectarDependencias(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BdmercadoYaContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("cadenaSQL"));
            });
            //en la siguiente linea utilizamos un modelo generico
            //ahora utilizamos un modelo en especifico
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IVentaRepository, VentaRepository>();
            /*
            services.AddScoped<ICotizacionRepository, CotizacionRepository>();
            services.AddScoped<IEmailService, EmailService>();*/
            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddScoped<IRolService, RolService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IImageService, ImageService>();
           
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IProductoService,    ProductoService>();
            services.AddScoped<IVentaService, VentaService>();
            services.AddScoped<IDashBoardService, DashBoardService>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IBarrioService, BarrioService>();
            services.AddScoped<IEstadoService, EstadoService>();
            services.AddScoped<ICalificacionService, CalificacionService>();
            services.AddScoped<IFile2Service, File2Service>();
            services.AddScoped<IChatService, ChatService>();
            services.AddScoped<IDetalleVentaService, DetalleVentaService>();
            services.AddScoped<ICuentaService, CuentaService>();
            services.AddScoped<IDivisaService,DivisaService>();

            services.AddScoped<IDomicilioService, DomicilioService>();
            services.AddScoped<IEntregaService, EntregaService>();
            services.AddScoped<IFacturaService, FacturaService>();

            services.AddScoped<IMensajeService, MensajeService>();
            services.AddScoped<IMovimientoService,MovimientoService>();
            services.AddScoped<ISectorService, SectorService>();
            services.AddScoped<ISedeService, SedeService>();
            services.AddScoped<ISubCategoriaService, SubCategoriaService>();
            services.AddScoped<ITipoPersonaService,TipoPersonaService>();


            services.AddScoped<DbContext, BdmercadoYaContext>();

        }
    }
}
