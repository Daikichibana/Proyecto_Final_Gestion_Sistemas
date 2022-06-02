﻿using CAPAS.CAPA.DOMINIO;
using CAPAS.CAPA.DOMINIO.BASICO.ENTIDADES;
using CAPAS.CAPA.DOMINIO.CLIENTES.ENTIDADES;
using CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.ENTIDADES;
using CAPAS.CAPA.DOMINIO.INVENTARIO.ENTIDADES;
using CAPAS.CAPA.DOMINIO.PROVEEDORES.ENTIDADES;
using CAPAS.CAPA.DOMINIO.USUARIOS.ENTIDADES;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CAPAS.CAPA.TECNICA.PERSISTENCIA
{
    public class BaseDatosContext : IdentityDbContext
    {
        /* Modulo Basico */
        public DbSet<NIT> NIT { get; set; }
        public DbSet<ResponsableEmpresa> ResponsableEmpresa { get; set; }
        public DbSet<Rubro> Rubro { get; set; }

        /* Modulo Clientes */
        public DbSet<EmpresaCliente> EmpresaCliente { get; set; }
        public DbSet<TarjetaCliente> TarjetaCliente { get; set; }

        /* Modulo Distribuidoras */
        public DbSet<Conductor> Conductor { get; set; }
        public DbSet<EmpresaDistribuidora> EmpresaDistribuidora { get; set; }
        public DbSet<ResponsableAlmacen> ResponsableAlmacen { get; set; }
        public DbSet<Sucursales> Sucursales { get; set; }
        public DbSet<Vechiculo> Vechiculo { get; set; }

        /* Modulo Inventario */
        public DbSet<TipoProducto> TipoProducto { get; set; }
        public DbSet<Producto> Producto { get; set; }

        /* Modulo Pedidos */

        /* Modulo Proveedores */
        public DbSet<EmpresaProveedor> EmpresaProveedor { get; set; }
        public DbSet<NotaRecepcion> NotaRecepcion { get; set; }

        /* Modulo Usuarios */
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

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
