using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using SistemaMercadoYa.DTO;
using SistemaMercadoYa.MODELS;

namespace SistemaMercadoYa.UTILITY
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region Barrio
            CreateMap<Barrio, BarrioDTO>().ReverseMap();
            #endregion Barrio

            #region Calificacion
            CreateMap<Calificacion, CalificacionDTO>()

                 .ForMember(destino =>
                destino.FechaRegistro,
                opt => opt.MapFrom(origen => origen.FechaRegistro.Value.ToString("dd/MM/yyyy"))
                );


            CreateMap<CalificacionDTO, Calificacion>()

                .ForMember(destino => destino.FechaRegistro,
                opt => opt.MapFrom(origen => Convert.ToDateTime(origen.FechaRegistro)));


            #endregion Calificacion

            #region Categoria
            CreateMap<Categoria, CategoriaDTO>()
                 .ForMember(destino =>
                destino.EsActivo,
                opt => opt.MapFrom(origen => origen.EsActivo == true ? 1 : 0));



            CreateMap<CategoriaDTO, Categoria>()

               .ForMember(destino =>
               destino.EsActivo,
               opt => opt.MapFrom(origen => origen.EsActivo == 1 ? true : false));

            #endregion Categoria


            #region Chat
            CreateMap<Chat, ChatDTO>()

                 .ForMember(destino =>
                destino.FechaRegistro,
                opt => opt.MapFrom(origen => origen.FechaRegistro.Value.ToString("dd/MM/yyyy"))
                );


            CreateMap<ChatDTO, Chat>()

                .ForMember(destino => destino.FechaRegistro,
                opt => opt.MapFrom(origen => Convert.ToDateTime(origen.FechaRegistro)));


            #endregion Chat


            #region Cuenta
            CreateMap<Cuenta, CuentaDTO>()

                .ForMember(destino =>
                destino.SaldoTexto,
                opt => opt.MapFrom(origen => Convert.ToString(origen.Saldo.Value, new CultureInfo("es-CO")))
                )
                 .ForMember(destino => destino.MovimientoDescripcion,
                opt => opt.MapFrom(origen => origen.IdMovimientoNavigation.Nombre)
                );

            CreateMap<CuentaDTO, Cuenta>()

                .ForMember(destino =>
                destino.Saldo,
                opt => opt.MapFrom(origen => Convert.ToDecimal(origen.SaldoTexto, new CultureInfo("es-CO")))
                )
                .ForMember(destino => destino.IdMovimientoNavigation, opt => opt.Ignore()
                );

            #endregion Cuenta 

            #region DetalleVenta
            CreateMap<DetalleVenta, DetalleVentaDTO>()

                .ForMember(destino => destino.DescripcionProducto,
                opt => opt.MapFrom(origen => origen.IdProductoNavigation.Nombre)
                )
                .ForMember(destino => destino.DescripcionEstado,
                opt => opt.MapFrom(origen => origen.IdEstadoNavigation.Nombre)
                )
                .ForMember(destino =>
                destino.PrecioTexto,
                opt => opt.MapFrom(origen => Convert.ToString(origen.Precio.Value, new CultureInfo("es-CO")))
                )
                .ForMember(destino =>
                destino.ImpuestoTexto,
                opt => opt.MapFrom(origen => Convert.ToString(origen.Impuesto.Value, new CultureInfo("es-CO")))
                )
                .ForMember(destino =>
                destino.DomicilioTexto,
                opt => opt.MapFrom(origen => Convert.ToString(origen.Domicilio.Value, new CultureInfo("es-CO")))
                )
                .ForMember(destino =>
                destino.TotalTexto,
                opt => opt.MapFrom(origen => Convert.ToString(origen.Total.Value, new CultureInfo("es-CO")))
                );

            CreateMap<DetalleVentaDTO, DetalleVenta>()
                .ForMember(destino => destino.IdProductoNavigation,
                opt => opt.Ignore()
                )
                .ForMember(destino => destino.IdEstadoNavigation,
                opt => opt.Ignore()
                )
                .ForMember(destino =>
                destino.Precio,
                opt => opt.MapFrom(origen => Convert.ToDecimal(origen.PrecioTexto, new CultureInfo("es-CO")))
                )
                .ForMember(destino =>
                destino.Impuesto,
                opt => opt.MapFrom(origen => Convert.ToDecimal(origen.ImpuestoTexto, new CultureInfo("es-CO")))
                )
                 .ForMember(destino =>
                destino.Domicilio,
                opt => opt.MapFrom(origen => Convert.ToDecimal(origen.DomicilioTexto, new CultureInfo("es-CO")))
                )
                 .ForMember(destino =>
                destino.Total,
                opt => opt.MapFrom(origen => Convert.ToDecimal(origen.TotalTexto, new CultureInfo("es-CO")))
                );

            #endregion DetalleVenta

            #region Divisa
            CreateMap<Divisa, DivisaDTO>()

                 .ForMember(destino =>
                destino.EsActivo,
                opt => opt.MapFrom(origen => origen.EsActivo == true ? 1 : 0));



            CreateMap<DivisaDTO, Divisa>()

               .ForMember(destino =>
               destino.EsActivo,
               opt => opt.MapFrom(origen => origen.EsActivo == 1 ? true : false));

            #endregion Divisa


            #region Domicilio
            CreateMap<Domicilio, DomicilioDTO>()

                .ForMember(destino => destino.DescripcionBarrio,
                opt => opt.MapFrom(origen => origen.IdBarrioNavigation.Nombre)
                )
                .ForMember(destino => destino.DescripcionSector,
                opt => opt.MapFrom(origen => origen.IdSectorNavigation.Nombre)
                )
                 .ForMember(destino =>
                destino.PrecioTexto,
                opt => opt.MapFrom(origen => Convert.ToString(origen.Precio.Value, new CultureInfo("es-CO")))
                )
                 .ForMember(destino =>
                destino.EsActivo,
                opt => opt.MapFrom(origen => origen.EsActivo == true ? 1 : 0))

                  .ForMember(destino =>
                destino.FechaRegistro,
                opt => opt.MapFrom(origen => origen.FechaRegistro.Value.ToString("dd/MM/yyyy"))
                );



            CreateMap<DomicilioDTO, Domicilio>()

                .ForMember(destino => destino.IdBarrioNavigation,
                opt => opt.Ignore()
                )
                .ForMember(destino => destino.IdSectorNavigation,
                opt => opt.Ignore()
                )
                .ForMember(destino =>
                destino.Precio,
                opt => opt.MapFrom(origen => Convert.ToDecimal(origen.PrecioTexto, new CultureInfo("es-CO")))
                )

               .ForMember(destino =>
               destino.EsActivo,
               opt => opt.MapFrom(origen => origen.EsActivo == 1 ? true : false))

                .ForMember(destino => destino.FechaRegistro,
                opt => opt.MapFrom(origen => Convert.ToDateTime(origen.FechaRegistro)));

            #endregion Domicilio

            #region Entrega
            CreateMap<Entrega, EntregaDTO>()

                  .ForMember(destino =>
                destino.Entrega1,
                opt => opt.MapFrom(origen => origen.Entrega1.Value.ToString("dd/MM/yyyy"))
                )

                .ForMember(destino => destino.DescripcionDomicilio,
                opt => opt.MapFrom(origen => origen.IdDomicilioNavigation.Nombre)
                )
                .ForMember(destino => destino.DescripcionSede,
                opt => opt.MapFrom(origen => origen.IdSedeNavigation.Nombre)
                )

                .ForMember(destino => destino.DescripcionEstado,
                opt => opt.MapFrom(origen => origen.IdEstadoNavigation.Nombre)
                )

                 .ForMember(destino =>
                destino.PrecioTexto,
                opt => opt.MapFrom(origen => Convert.ToString(origen.Precio.Value, new CultureInfo("es-CO")))
                )
                .ForMember(destino =>
                destino.FechaRegistro,
                opt => opt.MapFrom(origen => origen.FechaRegistro.Value.ToString("dd/MM/yyyy"))
                );



            CreateMap<EntregaDTO, Entrega>()

                .ForMember(destino => destino.Entrega1,
                opt => opt.MapFrom(origen => Convert.ToDateTime(origen.Entrega1)))

                .ForMember(destino => destino.IdDomicilioNavigation,
                opt => opt.Ignore()
                )
                .ForMember(destino => destino.IdSedeNavigation,
                opt => opt.Ignore()
                )
                .ForMember(destino => destino.IdEstadoNavigation,
                opt => opt.Ignore()
                )
                .ForMember(destino =>
                destino.Precio,
                opt => opt.MapFrom(origen => Convert.ToDecimal(origen.PrecioTexto, new CultureInfo("es-CO")))
                )

                .ForMember(destino => destino.FechaRegistro,
                opt => opt.MapFrom(origen => Convert.ToDateTime(origen.FechaRegistro)));

            #endregion Entrega

            #region Estado
            CreateMap<Estado, EstadoDTO>().ReverseMap();
            #endregion Estado

            #region Factura
            CreateMap<Factura, FacturaDTO>()

                 .ForMember(destino =>
                destino.FechaRegistro,
                opt => opt.MapFrom(origen => origen.FechaRegistro.Value.ToString("dd/MM/yyyy"))
                );


            CreateMap<FacturaDTO, Factura>()

                .ForMember(destino => destino.FechaRegistro,
                opt => opt.MapFrom(origen => Convert.ToDateTime(origen.FechaRegistro)));


            #endregion Factura

            #region Mensaje
            CreateMap<Mensaje, MensajeDTO>()
                 .ForMember(destino =>
                destino.FechaRegistro,
                opt => opt.MapFrom(origen => origen.FechaRegistro.Value.ToString("dd/MM/yyyy"))
                );


            CreateMap<MensajeDTO, Mensaje>()

                .ForMember(destino => destino.FechaRegistro,
                opt => opt.MapFrom(origen => Convert.ToDateTime(origen.FechaRegistro)));


            #endregion Mensaje

            


            #region Menu
            CreateMap<Menu, MenuDTO>().ReverseMap();
            #endregion Menu

            #region Movimiento

            CreateMap<Movimiento, MovimientoDTO>()

                 .ForMember(destino =>
                destino.ValorTexto,
                opt => opt.MapFrom(origen => Convert.ToString(origen.Valor.Value, new CultureInfo("es-CO")))
                )

                 .ForMember(destino =>
                destino.FechaRegistro,
                opt => opt.MapFrom(origen => origen.FechaRegistro.Value.ToString("dd/MM/yyyy"))
                );


            CreateMap<MovimientoDTO, Movimiento>()

                 .ForMember(destino =>
                destino.Valor,
                opt => opt.MapFrom(origen => Convert.ToDecimal(origen.ValorTexto, new CultureInfo("es-CO")))
                )

                .ForMember(destino => destino.FechaRegistro,
                opt => opt.MapFrom(origen => Convert.ToDateTime(origen.FechaRegistro)));


            #endregion Movimiento



            #region DivisaProducto

            CreateMap<DivisaProducto, DivisaProductoDTO>()

                 .ForMember(destino => destino.DescripcionDivisa,
                opt => opt.MapFrom(origen => origen.IdDivisaNavigation.Nombre)
                )
                .ForMember(destino => destino.DescripcionProducto,
                opt => opt.MapFrom(origen => origen.IdProductoNavigation.Nombre)
                );


            CreateMap<DivisaProductoDTO, DivisaProducto>()
                 .ForMember(destino => destino.IdDivisaNavigation,
                opt => opt.Ignore()
                )
                .ForMember(destino => destino.IdProductoNavigation,
                opt => opt.Ignore()
                );

            #endregion DivisaProducto

            #region FileData
            CreateMap<FileData, FileDataDTO>()
                .ForMember(destino => destino.Image,
                opt => opt.MapFrom(origen => origen.IdImagenNavigation.Nombre)
                );

            CreateMap<FileDataDTO, FileData>()
                .ForMember(destino => destino.IdImagenNavigation,
                opt => opt.Ignore()
                );
            #endregion FileData

            #region FileRecord
            CreateMap<FileData, FileRecordDTO>()
                .ForMember(destino => destino.FileFormat,
                opt => opt.MapFrom(origen => origen.Extension)
                ).ForMember(destino => destino.ContentType,
                opt => opt.MapFrom(origen => origen.MimeType)
                );

            CreateMap<FileRecordDTO, FileData>()
                .ForMember(destino => destino.Extension,
                opt => opt.MapFrom(origen => origen.FileFormat))
                .ForMember(destino => destino.MimeType,
                opt => opt.MapFrom(origen => origen.ContentType)
                );
            #endregion FileRecord


            #region SedeProducto

            CreateMap<SedeProducto, SedeProductoDTO>()

                 .ForMember(destino => destino.DescripcionProducto,
                opt => opt.MapFrom(origen => origen.IdProductoNavigation.Nombre)
                )
                .ForMember(destino => destino.DescripcionSede,
                opt => opt.MapFrom(origen => origen.IdSedeNavigation.Nombre)
                );


            CreateMap<SedeProductoDTO, SedeProducto>()

                 .ForMember(destino => destino.IdProductoNavigation,
                opt => opt.Ignore()
                )
                .ForMember(destino => destino.IdSedeNavigation,
                opt => opt.Ignore()
                );

            #endregion SedeProducto

            #region Producto

            CreateMap<Producto, ProductoDTO>()

                 .ForMember(destino => destino.DescripcionSubCategoria,
                opt => opt.MapFrom(origen => origen.IdSubCategoriaNavigation.Nombre)
                )

                  .ForMember(destino =>
                destino.PrecioNormalTexto,
                opt => opt.MapFrom(origen => Convert.ToString(origen.PrecioNormal.Value, new CultureInfo("es-CO")))
                )
                    .ForMember(destino =>
                destino.PrecioDescuentoTexto,
                opt => opt.MapFrom(origen => Convert.ToString(origen.PrecioDescuento.Value, new CultureInfo("es-CO")))
                )

                 .ForMember(destino =>
                destino.Precio1Texto,
                opt => opt.MapFrom(origen => Convert.ToString(origen.Precio1.Value, new CultureInfo("es-CO")))
                )
                    .ForMember(destino =>
                destino.Precio2Texto,
                opt => opt.MapFrom(origen => Convert.ToString(origen.Precio2.Value, new CultureInfo("es-CO")))
                )

                .ForMember(destino =>
                destino.Precio3Texto,
                opt => opt.MapFrom(origen => Convert.ToString(origen.Precio3.Value, new CultureInfo("es-CO")))
                )

                 .ForMember(destino =>
                destino.EsActivo,
                opt => opt.MapFrom(origen => origen.EsActivo == true ? 1 : 0))


                 .ForMember(destino =>
                destino.FechaRegistro,
                opt => opt.MapFrom(origen => origen.FechaRegistro.Value.ToString("dd/MM/yyyy"))
                )

                .ForMember(destino => destino.DetalleVenta,
                 opt => opt.MapFrom(origen => origen.DetalleVenta))

                 .ForMember(destino => destino.Sede,
                 opt => opt.MapFrom(origen => origen.SedeProductos))

                  .ForMember(destino => destino.Divisa,
                 opt => opt.MapFrom(origen => origen.DivisaProductos));

            CreateMap<ProductoDTO, Producto>()

                 .ForMember(destino => destino.IdSubCategoriaNavigation,
                opt => opt.Ignore()
                )

                 .ForMember(destino =>
                destino.PrecioNormal,
                opt => opt.MapFrom(origen => Convert.ToDecimal(origen.PrecioNormalTexto, new CultureInfo("es-CO")))
                )

                   .ForMember(destino =>
                destino.PrecioDescuento,
                opt => opt.MapFrom(origen => Convert.ToDecimal(origen.PrecioDescuentoTexto, new CultureInfo("es-CO")))
                )
                    .ForMember(destino =>
                destino.Precio1,
                opt => opt.MapFrom(origen => Convert.ToDecimal(origen.Precio1Texto, new CultureInfo("es-CO")))
                )

                .ForMember(destino =>
                destino.Precio2,
                opt => opt.MapFrom(origen => Convert.ToDecimal(origen.Precio2Texto, new CultureInfo("es-CO")))
                )

                .ForMember(destino =>
                destino.Precio3,
                opt => opt.MapFrom(origen => Convert.ToDecimal(origen.Precio3Texto, new CultureInfo("es-CO")))
                )

               .ForMember(destino =>
               destino.EsActivo,
               opt => opt.MapFrom(origen => origen.EsActivo == 1 ? true : false))


               .ForMember(destino => destino.FechaRegistro,
                opt => opt.MapFrom(origen => Convert.ToDateTime(origen.FechaRegistro)))


                .ForMember(destino => destino.DetalleVenta,
                 opt => opt.MapFrom(origen => origen.DetalleVenta))

                 .ForMember(destino => destino.SedeProductos,
                 opt => opt.MapFrom(origen => origen.Sede))

                  .ForMember(destino => destino.DivisaProductos,
                 opt => opt.MapFrom(origen => origen.Divisa));


            #endregion Producto

            #region Reporte


            CreateMap<DetalleVenta, ReporteDTO>()

                .ForMember(destino => destino.FechaRegistro,
                opt => opt.MapFrom(origen => origen.IdVentaNavigation.FechaRegistro.Value.ToString("dd/MM/yyyy")))

               .ForMember(destino => destino.numeroDocumento,
                opt => opt.MapFrom(origen => origen.IdVentaNavigation.NumeroDocumento))

               .ForMember(destino => destino.TipoPago,
                opt => opt.MapFrom(origen => origen.IdVentaNavigation.TipoPago))

               .ForMember(destino =>
                destino.TotalVenta,
                opt => opt.MapFrom(origen => Convert.ToString(origen.IdVentaNavigation.Total.Value, new CultureInfo("es-CO"))))

                .ForMember(destino =>
                destino.Producto,
                opt => opt.MapFrom(origen => Convert.ToString(origen.IdProductoNavigation.Nombre)))

                .ForMember(destino =>
                destino.Precio,
                opt => opt.MapFrom(origen => Convert.ToString(origen.Precio, new CultureInfo("es-CO"))))


                .ForMember(destino =>
                destino.Total,
                opt => opt.MapFrom(origen => Convert.ToString(origen.Total, new CultureInfo("es-CO"))))

                 .ForMember(destino => destino.EntregasExito,
                opt => opt.MapFrom(origen => origen.IdEstadoNavigation.Entregas))

                   .ForMember(destino => destino.DiomiciliosRegistrados,
                opt => opt.MapFrom(origen => origen.IdVentaNavigation.IdEntregaNavigation.Sede));

             #endregion

            #region Rol
            CreateMap<Rol, RolDTO>().ReverseMap();
            #endregion Rol


            #region Sector
            CreateMap<Sector, SectorDTO>().ReverseMap();

            #endregion Sector

            #region Sede

            CreateMap<Sede, SedeDTO>().ReverseMap();

            #endregion Sede


            #region SubCategoria
            CreateMap<SubCategoria, SubCategoriaDTO>()
                 .ForMember(destino => destino.CategoriaDescripcion,
                opt => opt.MapFrom(origen => origen.IdCategoriaNavigation.Nombre)
                )
                .ForMember(destino =>
                destino.EsActivo,
                opt => opt.MapFrom(origen => origen.EsActivo == true ? 1 : 0))

                 .ForMember(destino =>
                destino.FechaRegistro,
                opt => opt.MapFrom(origen => origen.FechaRegistro.Value.ToString("dd/MM/yyyy"))
                );


            CreateMap<SubCategoriaDTO, SubCategoria>()

                 .ForMember(destino => destino.IdCategoriaNavigation, opt => opt.Ignore()
                )
                .ForMember(destino =>
                destino.EsActivo,
                opt => opt.MapFrom(origen => origen.EsActivo == 1 ? true : false))

                .ForMember(destino => destino.FechaRegistro,
                opt => opt.MapFrom(origen => Convert.ToDateTime(origen.FechaRegistro)));

            #endregion SubCategoria

            #region TipoPersona

            CreateMap<TipoPersona, TipoPersonaDTO>().ReverseMap();

            #endregion TipoPersona

            #region Usuario
            CreateMap<Usuario, UsuarioDTO>()

                .ForMember(destino => destino.RolDescripcion,
                opt => opt.MapFrom(origen => origen.IdRolNavigation.Nombre)
                )
                .ForMember(destino => destino.TipoPersonaDescripcion,
                opt => opt.MapFrom(origen => origen.IdTipoPersonaNavigation.Nombre)
                )
                 .ForMember(destino => destino.CuentaDescripcion,
                opt => opt.MapFrom(origen => origen.IdCuentaNavigation.Saldo)
                )
                .ForMember(destino =>
                destino.EsActivo,
                opt => opt.MapFrom(origen => origen.EsActivo == true ? 1 : 0))


                   .ForMember(destino => destino.DomiciliosDTO,
                 opt => opt.MapFrom(origen => origen.DomicilioUsuarios));



            CreateMap<Usuario, SesionDTO>()

                .ForMember(destino =>
                destino.RolDescripcion,
                opt => opt.MapFrom(origen => origen.IdRolNavigation.Nombre))

                .ForMember(destino => destino.CuentaDescripcion,
                opt => opt.MapFrom(origen => origen.IdCuentaNavigation.Saldo)
                );

            CreateMap<UsuarioDTO, Usuario>()

                .ForMember(destino => destino.IdRolNavigation, opt => opt.Ignore()
                )
                .ForMember(destino => destino.IdTipoPersonaNavigation, opt => opt.Ignore()
                )
                .ForMember(destino => destino.IdCuentaNavigation, opt => opt.Ignore()
                )
                .ForMember(destino =>
                destino.EsActivo,
                opt => opt.MapFrom(origen => origen.EsActivo == 1 ? true : false))

                .ForMember(destino => destino.DomicilioUsuarios,
                opt => opt.MapFrom(origen => origen.DomiciliosDTO));

            #endregion Usuario

            #region Venta

            CreateMap<Venta, VentaDTO>()
                .ForMember(destino =>
                destino.TotalTexto,
                opt => opt.MapFrom(origen => Convert.ToString(origen.Total.Value, new CultureInfo("es-CO")))
                )
                .ForMember(destino =>
                destino.EntregaDescripcion,
                opt => opt.MapFrom(origen => origen.IdEntregaNavigation.Tipo))

                .ForMember(destino => destino.FacturaDescripcion,
                opt => opt.MapFrom(origen => origen.IdFacturaNavigation.Documento)
                )
                .ForMember(destino =>
                destino.FechaRegistro,
                opt => opt.MapFrom(origen => origen.FechaRegistro.Value.ToString("dd/MM/yyyy"))
                );
            CreateMap<VentaDTO, Venta>()

                .ForMember(destino =>
                destino.Total,
                opt => opt.MapFrom(origen => Convert.ToDecimal(origen.TotalTexto, new CultureInfo("es-CO")))
                )
                .ForMember(destino => destino.IdEntregaNavigation, opt => opt.Ignore()
                )
                .ForMember(destino => destino.IdFacturaNavigation, opt => opt.Ignore()
                )
                .ForMember(destino => destino.FechaRegistro,
                opt => opt.MapFrom(origen => Convert.ToDateTime(origen.FechaRegistro)));

            #endregion


        }
    }
}