using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SistemaMercadoYa.MODELS;

namespace SistemaMercadoYa.DAL.DBContext;

public partial class BdmercadoYaContext : DbContext
{
    public BdmercadoYaContext()
    {
    }

    public BdmercadoYaContext(DbContextOptions<BdmercadoYaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Barrio> Barrios { get; set; }

    public virtual DbSet<Calificacion> Calificacions { get; set; }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<Chat> Chats { get; set; }

    public virtual DbSet<Cuenta> Cuenta { get; set; }

    public virtual DbSet<DetalleVenta> DetalleVenta { get; set; }

    public virtual DbSet<Divisa> Divisas { get; set; }

    public virtual DbSet<DivisaProducto> DivisaProductos { get; set; }

    public virtual DbSet<Domicilio> Domicilios { get; set; }

    public virtual DbSet<DomicilioUsuario> DomicilioUsuarios { get; set; }

    public virtual DbSet<Entrega> Entregas { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<FileData> FileData { get; set; }

    public virtual DbSet<Imagen> Imagens { get; set; }

    public virtual DbSet<Mensaje> Mensajes { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<MenuRol> MenuRols { get; set; }

    public virtual DbSet<Movimiento> Movimientos { get; set; }

    public virtual DbSet<NumeroDocumento> NumeroDocumentos { get; set; }

    public virtual DbSet<Origen> Origens { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Sector> Sectors { get; set; }

    public virtual DbSet<Sede> Sedes { get; set; }

    public virtual DbSet<SedeProducto> SedeProductos { get; set; }

    public virtual DbSet<SubCategoria> SubCategoria { get; set; }

    public virtual DbSet<TipoPersona> TipoPersonas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuarioCalificacion> UsuarioCalificacions { get; set; }

    public virtual DbSet<UsuarioChat> UsuarioChats { get; set; }

    public virtual DbSet<Venta> Venta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Barrio>(entity =>
        {
            entity.HasKey(e => e.IdBarrio).HasName("PK__Barrio__42F23FF8A7BB4B7F");

            entity.ToTable("Barrio");

            entity.Property(e => e.IdBarrio).HasColumnName("idBarrio");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Url)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("url");
        });

        modelBuilder.Entity<Calificacion>(entity =>
        {
            entity.HasKey(e => e.IdCalificacion).HasName("PK__Califica__E056358FE598CCC7");

            entity.ToTable("Calificacion");

            entity.Property(e => e.IdCalificacion).HasColumnName("idCalificacion");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.Numero).HasColumnName("numero");
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__8A3D240C3515ED3E");

            entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");
            entity.Property(e => e.EsActivo)
                .HasDefaultValueSql("((1))")
                .HasColumnName("esActivo");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Chat>(entity =>
        {
            entity.HasKey(e => e.IdChat).HasName("PK__Chat__8307BCB3D5CE58DB");

            entity.ToTable("Chat");

            entity.Property(e => e.IdChat).HasColumnName("idChat");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.Numero)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("numero");
            entity.Property(e => e.Titulo)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("titulo");
        });

        modelBuilder.Entity<Cuenta>(entity =>
        {
            entity.HasKey(e => e.IdCuenta).HasName("PK__Cuenta__BBC6DF320CDD8567");

            entity.Property(e => e.IdCuenta).HasColumnName("idCuenta");
            entity.Property(e => e.IdMovimiento).HasColumnName("idMovimiento");
            entity.Property(e => e.Saldo)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("saldo");

            entity.HasOne(d => d.IdMovimientoNavigation).WithMany(p => p.Cuenta)
                .HasForeignKey(d => d.IdMovimiento)
                .HasConstraintName("FK__Cuenta__idMovimi__5629CD9C");
        });

        modelBuilder.Entity<DetalleVenta>(entity =>
        {
            entity.HasKey(e => e.IdDetalleVenta).HasName("PK__DetalleV__BFE2843F731044A1");

            entity.Property(e => e.IdDetalleVenta).HasColumnName("idDetalleVenta");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Domicilio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("domicilio");
            entity.Property(e => e.IdEstado).HasColumnName("idEstado");
            entity.Property(e => e.IdProducto).HasColumnName("idProducto");
            entity.Property(e => e.IdVenta).HasColumnName("idVenta");
            entity.Property(e => e.Impuesto)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("impuesto");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.IdEstado)
                .HasConstraintName("FK__DetalleVe__idEst__0B91BA14");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK__DetalleVe__idPro__0A9D95DB");

            entity.HasOne(d => d.IdVentaNavigation).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.IdVenta)
                .HasConstraintName("FK__DetalleVe__idVen__09A971A2");
        });

        modelBuilder.Entity<Divisa>(entity =>
        {
            entity.HasKey(e => e.IdDivisa).HasName("PK__Divisa__96114A56D6C9A39D");

            entity.ToTable("Divisa");

            entity.Property(e => e.IdDivisa).HasColumnName("idDivisa");
            entity.Property(e => e.EsActivo)
                .HasDefaultValueSql("((1))")
                .HasColumnName("esActivo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<DivisaProducto>(entity =>
        {
            entity.HasKey(e => e.IdDivisaProducto).HasName("PK__DivisaPr__DF424A82503891EC");

            entity.ToTable("DivisaProducto");

            entity.Property(e => e.IdDivisaProducto).HasColumnName("idDivisaProducto");
            entity.Property(e => e.IdDivisa).HasColumnName("idDivisa");
            entity.Property(e => e.IdProducto).HasColumnName("idProducto");

            entity.HasOne(d => d.IdDivisaNavigation).WithMany(p => p.DivisaProductos)
                .HasForeignKey(d => d.IdDivisa)
                .HasConstraintName("FK__DivisaPro__idDiv__75A278F5");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DivisaProductos)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK__DivisaPro__idPro__76969D2E");
        });

        modelBuilder.Entity<Domicilio>(entity =>
        {
            entity.HasKey(e => e.IdDomicilio).HasName("PK__Domicili__7F6CE3D91C4E936D");

            entity.ToTable("Domicilio");

            entity.Property(e => e.IdDomicilio).HasColumnName("idDomicilio");
            entity.Property(e => e.Celular1)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("celular1");
            entity.Property(e => e.Celular2)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("celular2");
            entity.Property(e => e.Coordenadas)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("coordenadas");
            entity.Property(e => e.Direccion)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.EsActivo)
                .HasDefaultValueSql("((1))")
                .HasColumnName("esActivo");
            entity.Property(e => e.Fachada)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("fachada");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.Fijo)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("fijo");
            entity.Property(e => e.FotoRecibe)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("fotoRecibe");
            entity.Property(e => e.IdBarrio).HasColumnName("idBarrio");
            entity.Property(e => e.IdSector).HasColumnName("idSector");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Notas)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("notas");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio");
            entity.Property(e => e.Recibe)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("recibe");
            entity.Property(e => e.Referencia)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("referencia");
            entity.Property(e => e.Whatsapp)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("whatsapp");

            entity.HasOne(d => d.IdBarrioNavigation).WithMany(p => p.Domicilios)
                .HasForeignKey(d => d.IdBarrio)
                .HasConstraintName("FK__Domicilio__idBar__4BAC3F29");

            entity.HasOne(d => d.IdSectorNavigation).WithMany(p => p.Domicilios)
                .HasForeignKey(d => d.IdSector)
                .HasConstraintName("FK__Domicilio__idSec__4CA06362");
        });

        modelBuilder.Entity<DomicilioUsuario>(entity =>
        {
            entity.HasKey(e => e.IdDomicilioUsuario).HasName("PK__Domicili__C3D2936F14890467");

            entity.ToTable("DomicilioUsuario");

            entity.Property(e => e.IdDomicilioUsuario).HasColumnName("idDomicilioUsuario");
            entity.Property(e => e.IdDomicilio).HasColumnName("idDomicilio");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

            entity.HasOne(d => d.IdDomicilioNavigation).WithMany(p => p.DomicilioUsuarios)
                .HasForeignKey(d => d.IdDomicilio)
                .HasConstraintName("FK__Domicilio__idDom__5FB337D6");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.DomicilioUsuarios)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Domicilio__idUsu__60A75C0F");
        });

        modelBuilder.Entity<Entrega>(entity =>
        {
            entity.HasKey(e => e.IdEntrega).HasName("PK__Entrega__6CA5A9887CBF3753");

            entity.ToTable("Entrega");

            entity.Property(e => e.IdEntrega).HasColumnName("idEntrega");
            entity.Property(e => e.Entrega1)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("entrega");
            entity.Property(e => e.Evidencia)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("evidencia");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.IdDomicilio).HasColumnName("idDomicilio");
            entity.Property(e => e.IdEstado).HasColumnName("idEstado");
            entity.Property(e => e.IdSede).HasColumnName("idSede");
            entity.Property(e => e.Km).HasColumnName("km");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio");
            entity.Property(e => e.Sede)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("sede");
            entity.Property(e => e.TiempoAproximado).HasColumnName("tiempoAproximado");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo");

            entity.HasOne(d => d.IdDomicilioNavigation).WithMany(p => p.Entregas)
                .HasForeignKey(d => d.IdDomicilio)
                .HasConstraintName("FK__Entrega__idDomic__7C4F7684");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Entregas)
                .HasForeignKey(d => d.IdEstado)
                .HasConstraintName("FK__Entrega__idEstad__7E37BEF6");

            entity.HasOne(d => d.IdSedeNavigation).WithMany(p => p.Entregas)
                .HasForeignKey(d => d.IdSede)
                .HasConstraintName("FK__Entrega__idSede__7D439ABD");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.IdEstado).HasName("PK__Estado__62EA894ACD915A09");

            entity.ToTable("Estado");

            entity.Property(e => e.IdEstado).HasColumnName("idEstado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.IdFactura).HasName("PK__Factura__3CD5687E49993BC8");

            entity.ToTable("Factura");

            entity.Property(e => e.IdFactura).HasColumnName("idFactura");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Documento)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("documento");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
        });

        modelBuilder.Entity<FileData>(entity =>
        {
            entity.HasKey(e => e.IdFile).HasName("PK__FileData__775AFE728DF8FB94");

            entity.Property(e => e.IdFile).HasColumnName("idFile");
            entity.Property(e => e.Extension)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("extension");
            entity.Property(e => e.IdImagen).HasColumnName("idImagen");
            entity.Property(e => e.MimeType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("mimeType");
            entity.Property(e => e.Name)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Path)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("path");

            entity.HasOne(d => d.IdImagenNavigation).WithMany(p => p.FileData)
                .HasForeignKey(d => d.IdImagen)
                .HasConstraintName("FK__FileData__idImag__10566F31");
        });

        modelBuilder.Entity<Imagen>(entity =>
        {
            entity.HasKey(e => e.IdImagen).HasName("PK__Imagen__EA9A7136135A580E");

            entity.ToTable("Imagen");

            entity.Property(e => e.IdImagen).HasColumnName("idImagen");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Mensaje>(entity =>
        {
            entity.HasKey(e => e.IdMensaje).HasName("PK__Mensaje__45E42C140A19A8B1");

            entity.ToTable("Mensaje");

            entity.Property(e => e.IdMensaje).HasColumnName("idMensaje");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Texto)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("texto");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.IdMenu).HasName("PK__Menu__C26AF483E744B2B5");

            entity.ToTable("Menu");

            entity.Property(e => e.IdMenu).HasColumnName("idMenu");
            entity.Property(e => e.Icono)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("icono");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Url)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("url");
        });

        modelBuilder.Entity<MenuRol>(entity =>
        {
            entity.HasKey(e => e.IdMenuRol).HasName("PK__MenuRol__9D6D61A4CFE2DB6B");

            entity.ToTable("MenuRol");

            entity.Property(e => e.IdMenuRol).HasColumnName("idMenuRol");
            entity.Property(e => e.IdMenu).HasColumnName("idMenu");
            entity.Property(e => e.IdRol).HasColumnName("idRol");

            entity.HasOne(d => d.IdMenuNavigation).WithMany(p => p.MenuRols)
                .HasForeignKey(d => d.IdMenu)
                .HasConstraintName("FK__MenuRol__idMenu__3F466844");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.MenuRols)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__MenuRol__idRol__403A8C7D");
        });

        modelBuilder.Entity<Movimiento>(entity =>
        {
            entity.HasKey(e => e.IdMovimiento).HasName("PK__Movimien__6285217380672080");

            entity.ToTable("Movimiento");

            entity.Property(e => e.IdMovimiento).HasColumnName("idMovimiento");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Valor)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("valor");
        });

        modelBuilder.Entity<NumeroDocumento>(entity =>
        {
            entity.HasKey(e => e.IdNumeroDocumento).HasName("PK__NumeroDo__471E421A439FCE92");

            entity.ToTable("NumeroDocumento");

            entity.Property(e => e.IdNumeroDocumento).HasColumnName("idNumeroDocumento");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.UltimoNumero).HasColumnName("ultimo_Numero");
        });

        modelBuilder.Entity<Origen>(entity =>
        {
            entity.HasKey(e => e.IdOrigen).HasName("PK__Origen__9F1968EFAC9DA9F3");

            entity.ToTable("Origen");

            entity.Property(e => e.IdOrigen).HasColumnName("idOrigen");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__Producto__07F4A13229AB49A6");

            entity.ToTable("Producto");

            entity.Property(e => e.IdProducto).HasColumnName("idProducto");
            entity.Property(e => e.DescripcionCorta)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("descripcionCorta");
            entity.Property(e => e.DescripcionLarga)
                .HasMaxLength(600)
                .IsUnicode(false)
                .HasColumnName("descripcionLarga");
            entity.Property(e => e.EsActivo).HasColumnName("esActivo");
            entity.Property(e => e.Etiqueta)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("etiqueta");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.Foto1)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("foto1");
            entity.Property(e => e.Foto2)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("foto2");
            entity.Property(e => e.Foto3)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("foto3");
            entity.Property(e => e.Foto4)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("foto4");
            entity.Property(e => e.FotoPrincipal)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("fotoPrincipal");
            entity.Property(e => e.IdSubCategoria).HasColumnName("idSubCategoria");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio1)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio1");
            entity.Property(e => e.Precio2)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio2");
            entity.Property(e => e.Precio3)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio3");
            entity.Property(e => e.PrecioDescuento)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precioDescuento");
            entity.Property(e => e.PrecioNormal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precioNormal");
            entity.Property(e => e.Stock).HasColumnName("stock");

            entity.HasOne(d => d.IdSubCategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdSubCategoria)
                .HasConstraintName("FK__Producto__idSubC__71D1E811");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Rol__3C872F766C34F8AA");

            entity.ToTable("Rol");

            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Sector>(entity =>
        {
            entity.HasKey(e => e.IdSector).HasName("PK__Sector__24DC3D6D97B6F9B9");

            entity.ToTable("Sector");

            entity.Property(e => e.IdSector).HasColumnName("idSector");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Url)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("url");
        });

        modelBuilder.Entity<Sede>(entity =>
        {
            entity.HasKey(e => e.IdSede).HasName("PK__Sede__C5AF63D043AD70A5");

            entity.ToTable("Sede");

            entity.Property(e => e.IdSede).HasColumnName("idSede");
            entity.Property(e => e.Direccion)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Fachada)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("fachada");
            entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<SedeProducto>(entity =>
        {
            entity.HasKey(e => e.IdSedeProducto).HasName("PK__SedeProd__AC4B9ACC27F64B96");

            entity.ToTable("SedeProducto");

            entity.Property(e => e.IdSedeProducto).HasColumnName("idSedeProducto");
            entity.Property(e => e.IdProducto).HasColumnName("idProducto");
            entity.Property(e => e.IdSede).HasColumnName("idSede");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.SedeProductos)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK__SedeProdu__idPro__1EA48E88");

            entity.HasOne(d => d.IdSedeNavigation).WithMany(p => p.SedeProductos)
                .HasForeignKey(d => d.IdSede)
                .HasConstraintName("FK__SedeProdu__idSed__1DB06A4F");
        });

        modelBuilder.Entity<SubCategoria>(entity =>
        {
            entity.HasKey(e => e.IdsubCategoria).HasName("PK__SubCateg__63F6BB50CA97E15C");

            entity.Property(e => e.IdsubCategoria).HasColumnName("idsubCategoria");
            entity.Property(e => e.EsActivo)
                .HasDefaultValueSql("((1))")
                .HasColumnName("esActivo");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.SubCategoria)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("FK__SubCatego__idCat__6754599E");
        });

        modelBuilder.Entity<TipoPersona>(entity =>
        {
            entity.HasKey(e => e.IdTipoPersona).HasName("PK__TipoPers__68D37AD68ECE4E94");

            entity.ToTable("TipoPersona");

            entity.Property(e => e.IdTipoPersona).HasColumnName("idTipoPersona");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__645723A62EBA293A");

            entity.ToTable("Usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Celular)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("celular");
            entity.Property(e => e.Clave)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("clave");
            entity.Property(e => e.Correo)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.EsActivo)
                .HasDefaultValueSql("((1))")
                .HasColumnName("esActivo");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.IdCuenta).HasColumnName("idCuenta");
            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.IdTipoPersona).HasColumnName("idTipoPersona");
            entity.Property(e => e.Identificacion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("identificacion");
            entity.Property(e => e.Nit)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nit");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.NombreOrganizacion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreOrganizacion");
            entity.Property(e => e.RazonSocial)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("razonSocial");
            entity.Property(e => e.Rut)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("rut");
            entity.Property(e => e.TipoIdentificacion)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("tipoIdentificacion");
            entity.Property(e => e.Whatsapp)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("whatsapp");

            entity.HasOne(d => d.IdCuentaNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdCuenta)
                .HasConstraintName("FK__Usuario__idCuent__5BE2A6F2");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__Usuario__idRol__59063A47");

            entity.HasOne(d => d.IdTipoPersonaNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdTipoPersona)
                .HasConstraintName("FK__Usuario__idTipoP__59FA5E80");
        });

        modelBuilder.Entity<UsuarioCalificacion>(entity =>
        {
            entity.HasKey(e => e.IdUsuarioCalificacion).HasName("PK__UsuarioC__B0864104CE34B19D");

            entity.ToTable("UsuarioCalificacion");

            entity.Property(e => e.IdUsuarioCalificacion).HasColumnName("idUsuarioCalificacion");
            entity.Property(e => e.IdCalificacion).HasColumnName("idCalificacion");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

            entity.HasOne(d => d.IdCalificacionNavigation).WithMany(p => p.UsuarioCalificacions)
                .HasForeignKey(d => d.IdCalificacion)
                .HasConstraintName("FK__UsuarioCa__idCal__25518C17");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.UsuarioCalificacions)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__UsuarioCa__idUsu__245D67DE");
        });

        modelBuilder.Entity<UsuarioChat>(entity =>
        {
            entity.HasKey(e => e.IdUsuarioChat).HasName("PK__UsuarioC__D9C2939C04CBA9C6");

            entity.ToTable("UsuarioChat");

            entity.Property(e => e.IdUsuarioChat).HasColumnName("idUsuarioChat");
            entity.Property(e => e.IdChat).HasColumnName("idChat");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

            entity.HasOne(d => d.IdChatNavigation).WithMany(p => p.UsuarioChats)
                .HasForeignKey(d => d.IdChat)
                .HasConstraintName("FK__UsuarioCh__idCha__2BFE89A6");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.UsuarioChats)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__UsuarioCh__idUsu__2B0A656D");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.IdVenta).HasName("PK__Venta__077D561413DA6FC5");

            entity.Property(e => e.IdVenta).HasColumnName("idVenta");
            entity.Property(e => e.Evidencia)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("evidencia");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.IdEntrega).HasColumnName("idEntrega");
            entity.Property(e => e.IdFactura).HasColumnName("idFactura");
            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("numeroDocumento");
            entity.Property(e => e.TipoPago)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipoPago");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total");

            entity.HasOne(d => d.IdEntregaNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdEntrega)
                .HasConstraintName("FK__Venta__idEntrega__04E4BC85");

            entity.HasOne(d => d.IdFacturaNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdFactura)
                .HasConstraintName("FK__Venta__idFactura__05D8E0BE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
