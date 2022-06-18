using System;
using System.IO;
using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Servicios;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Tecnica;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Servicios;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Tecnica;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Servicios;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Tecnica;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Servicios;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Tecnica;
using Proyecto_Final_Gestion_Sistemas.Server.Persistencia;

namespace Proyecto_Final_Gestion_Sistemas.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddControllers();

            //Configuracion para bases de datos:

            services.AddDbContext<BaseDatosContext>(options =>
                    //options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                    options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("Proyecto_Final_Gestion_Sistemas.Server")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                );

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            /*** Modulo Distribuidora ***/
            //Servicios
            services.AddScoped(typeof(IAdministrarRubroService), typeof(AdministrarRubroService));
            services.AddScoped(typeof(IAdministrarNITService), typeof(AdministrarNITService));
            services.AddScoped(typeof(IAdministrarTarjetaClienteService), typeof(AdministrarTarjetaClienteService));
            services.AddScoped(typeof(IAdministrarClienteService), typeof(AdministrarEmpresaClienteService));
            services.AddScoped(typeof(IAdministrarDistribuidoraService), typeof(AdministrarDistribuidoraService));
            services.AddScoped(typeof(IAdministrarVehiculoService), typeof(AdministrarVehiculoService));
            services.AddScoped(typeof(IAdministrarSucursalesService), typeof(AdministrarSucursalesService));
            services.AddScoped(typeof(IAdministrarProveedorService), typeof(AdministrarProveedorService));

            //Repositorios
            services.AddScoped(typeof(IRubroRepository), typeof(RubroRepository));
            services.AddScoped(typeof(INITRepository), typeof(NITRepository));
            services.AddScoped(typeof(ITarjetaClienteRepository), typeof(TarjetaClienteRepository));
            services.AddScoped(typeof(IEmpresaClienteRepository), typeof(EmpresaClienteRepository));
            services.AddScoped(typeof(IEmpresaDistribuidoraRepository), typeof(EmpresaDistribuidoraRepository));
            services.AddScoped(typeof(IVehiculoRepository), typeof(VehiculoRepository));
            services.AddScoped(typeof(ISucursalRepository), typeof(SucursalRepository));
            services.AddScoped(typeof(IClienteDistribuidoraRepository), typeof(ClienteDistribuidoraRepository));
            services.AddScoped(typeof(IProveedorRepository), typeof(ProveedorRepository));
            services.AddScoped(typeof(IAsignacionVechiculoConductorRepository), typeof(AsignacionVechiculoConductorRepository));

            /*** Modulo Inventario ***/
            //Servicios
            services.AddScoped(typeof(IGestionarTipoProductoService), typeof(GestionarTipoProductoService));
            services.AddScoped(typeof(IAdministrarProductoService), typeof(AdministrarProductoService));
            services.AddScoped(typeof(IActualizarStockPorCompraService), typeof(ActualizarStockPorCompraService));
            
            //Repositorios
            services.AddScoped(typeof(ITipoProductoRepository), typeof(TipoProductoRepository));
            services.AddScoped(typeof(IProductoRepository), typeof(ProductoRepository));
            services.AddScoped(typeof(IStockRepository), typeof(StockRepository));

            /*** Modulo Pedidos ***/
            //Servicios
            services.AddScoped(typeof(IAdministrarPedidoService), typeof(AdministrarPedidoService));
            services.AddScoped(typeof(IRealizarPedidoADistribuidoraService), typeof(RealizarPedidoADistribuidoraService));

            //Repositorios
            services.AddScoped(typeof(IDetalleOrdenPedidoRepository), typeof(DetalleOrdenPedidoRepository));
            services.AddScoped(typeof(IFacturaRepository), typeof(FacturaRepository));
            services.AddScoped(typeof(IOrdenPedidoRepository), typeof(OrdenPedidoRepository));
            services.AddScoped(typeof(IPedidoRepository), typeof(PedidoRepository));

            /**** Modulo Personal ****/
            //Servicios
            services.AddScoped(typeof(IResponsableEmpresaService), typeof(AdministrarResponsableEmpresaService));
            services.AddScoped(typeof(IAdministrarUsuarioService), typeof(AdministrarUsuarioService));
            services.AddScoped(typeof(IAdministrarRolService), typeof(AdminsitrarRolService));
            services.AddScoped(typeof(IAdministrarConductorService), typeof(AdministrarConductorService));
            services.AddScoped(typeof(IAdministrarResponsableAlmacenService), typeof(AdministrarResponsableAlmacenService));
            
            //Repositorios
            services.AddScoped(typeof(IResponsableEmpresaRepository), typeof(ResponsableEmpresaRepository));
            services.AddScoped(typeof(IUsuarioRepository), typeof(UsuarioRepository));
            services.AddScoped(typeof(IRolRepository), typeof(RolRepository));
            services.AddScoped(typeof(IConductorRepository), typeof(ConductorRepository));
            services.AddScoped(typeof(IResponsableAlmacenRepository), typeof(ResponsableAlmacenRepository));
            services.AddScoped(typeof(IUsuariosRolesRepository), typeof(UsuariosRolesRepository));


            //Configuracion del Mapeador
            var config = new MapperConfiguration(configure =>
            {
                configure.AddProfile(new MappingProfile());
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
            services.AddMvc();

            //Configuracion del Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Swagger Demo in Core 3.1",
                    Version = "v1",
                    Description = "Swagger Demo for .NET Core 3.1",
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                string swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";
                c.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "Demo swagger V1");
                c.DocumentTitle = "Demo - Swagger in Core";
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
