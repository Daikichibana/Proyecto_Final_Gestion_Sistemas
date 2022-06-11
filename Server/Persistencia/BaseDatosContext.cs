using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Persistencia
{
    public class BaseDatosContext : IdentityDbContext
    {
        
        // Modulo Distribuidora 
        public DbSet<NIT> NIT { get; set; }
        public DbSet<Rubro> Rubro { get; set; }
        public DbSet<EmpresaDistribuidora> EmpresaDistribuidora { get; set; }
        public DbSet<EmpresaCliente> EmpresaCliente { get; set; }
        public DbSet<EmpresaProveedor> EmpresaProveedor { get; set; }
        public DbSet<TarjetaCliente> TarjetaCliente { get; set; }
        public DbSet<Sucursales> Sucursales { get; set; }
        public DbSet<Vechiculo> Vechiculo { get; set; }
        public DbSet<AsignacionVechiculoConductor> AsignacionVechiculoConductor { get; set; }
        
        
        // Modulo Inventario 
        public DbSet<NotaRecepcion> NotaRecepcion { get; set; }
        public DbSet<TipoProducto> TipoProducto { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<DetalleNotaRecepcion> DetalleNotaRecepcion { get; set; }


        // Modulo Pedidos 
        public DbSet<Factura> Factura { get; set; }
        public DbSet<OrdenPedido> OrdenPedido { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<DetalleOrdenPedido> DetalleOrdenPedido { get; set; }

        // Modulo Personal 
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<ResponsableEmpresa> ResponsableEmpresa { get; set; }
        public DbSet<ResponsableAlmacen> ResponsableAlmacen { get; set; }
        public DbSet<Conductor> Conductor { get; set; }
        public DbSet<UsuariosRoles> UsuariosRoles { get; set; }

        public BaseDatosContext(DbContextOptions options)
           : base(options)
        {
        }
        public IConfiguration Configuration { get; }
        public BaseDatosContext()
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Entity>();
            modelBuilder.Entity<Stock>().Property(p => p.PrecioCompraPromedio).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Stock>().Property(p => p.PrecioVentaPromedio).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Factura>().Property(p => p.Total).HasColumnType("decimal(18,2)");

            //Ignorar 

            //modelBuilder.Ignore<Rol>();
            //modelBuilder.Ignore<Usuario>();
            //modelBuilder.Ignore<ResponsableEmpresa>();
            //modelBuilder.Ignore<ResponsableAlmacen>();
            //modelBuilder.Ignore<Conductor>();
            //modelBuilder.Ignore<UsuarioRoles>();

            //modelBuilder.Ignore<NIT>();
            //modelBuilder.Ignore<Rubro>();
            //modelBuilder.Ignore<EmpresaDistribuidora>();
            //modelBuilder.Ignore<EmpresaCliente>();
            //modelBuilder.Ignore<EmpresaProveedor>();
            //modelBuilder.Ignore<TarjetaCliente>();
            //modelBuilder.Ignore<Sucursales>();
            //modelBuilder.Ignore<Vechiculo>();
            //modelBuilder.Ignore<AsignacionVechiculoConductor>();

            //modelBuilder.Ignore<NotaRecepcion>();
            //modelBuilder.Ignore<TipoProducto>();
            //modelBuilder.Ignore<Producto>();
            //modelBuilder.Ignore<Stock>();

            //modelBuilder.Ignore<Factura>();
            //modelBuilder.Ignore<OrdenPedido>();
            //modelBuilder.Ignore<Pedido>();
            //modelBuilder.Ignore<DetalleOrdenPedido>();

            base.OnModelCreating(modelBuilder);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer("DefaultConnection");
            }
        }

    }
}
