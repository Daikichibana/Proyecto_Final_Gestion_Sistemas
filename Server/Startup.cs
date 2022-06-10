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
using Proyecto_Final_Gestion_Sistemas.Server.Modulos;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Basico.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Basico.Dominio.Servicios;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Basico.Tecnica;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Clientes.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Clientes.Dominio.Servicios;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Clientes.Tecnica;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidoras.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidoras.Dominio.Servicios;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidoras.Tecnica;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Servicios;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Tecnica;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Usuarios.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Usuarios.Dominio.Servicios;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Usuarios.Tecnica;

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
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("Compartido"))
                );

            //Aplicacion
            services.AddScoped(typeof(IAdministrarRubroService), typeof(AdministrarRubroService));
            services.AddScoped(typeof(IGestionarTipoProductoService), typeof(GestionarTipoProductoService));   
            services.AddScoped(typeof(IAdministrarProductoService), typeof(AdministrarProductoService));   
            services.AddScoped(typeof(INITService), typeof(AdministrarNITService));   
            services.AddScoped(typeof(IResponsableEmpresaService), typeof(AdministrarResponsableEmpresaService));   
            services.AddScoped(typeof(IAdministrarUsuarioService), typeof(AdministrarUsuarioService));   
            services.AddScoped(typeof(IAdministrarRolService), typeof(AdminsitrarRolService));     
            services.AddScoped(typeof(IGestionarTipoProductoService), typeof(GestionarTipoProductoService));
            services.AddScoped(typeof(IAdministrarTarjetaClienteService), typeof(AdministrarTarjetaClienteService)) ;
            services.AddScoped(typeof(IAdministrarEmpresaClienteService), typeof(AdministrarEmpresaClienteService)) ;
            services.AddScoped(typeof(IAdministrarDistribuidoraService), typeof(AdministrarDistribuidoraService)) ;
            services.AddScoped(typeof(IAdministrarConductorService), typeof(AdministrarConductorService)) ;
            services.AddScoped(typeof(IAdministrarVehiculoService), typeof(AdministrarVehiculoService)) ;
            services.AddScoped(typeof(IAdministrarSucursalesService), typeof(AdministrarSucursalesService)) ;
            services.AddScoped(typeof(IAdministrarResponsableAlmacenService), typeof(AdministrarResponsableAlmacenService)) ;

            //Repositorios
            services.AddScoped(typeof(Modulos.Inventario.Tecnica.IRepository<>), typeof(Modulos.Inventario.Tecnica.Repository<>));
            services.AddScoped(typeof(ITipoProductoRepository), typeof(TipoProductoRepository));
            services.AddScoped(typeof(IRubroRepository), typeof(RubroRepository));
            services.AddScoped(typeof(IProductoRepository), typeof(ProductoRepository));
            services.AddScoped(typeof(INITRepository), typeof(NITRepository));
            services.AddScoped(typeof(IResponsableEmpresaRepository), typeof(ResponsableEmpresaRepository));
            services.AddScoped(typeof(IUsuarioRepository), typeof(UsuarioRepository));
            services.AddScoped(typeof(IRolRepository), typeof(RolRepository));
            services.AddScoped(typeof(ITarjetaClienteRepository), typeof(TarjetaClienteRepository));
            services.AddScoped(typeof(IEmpresaClienteRepository), typeof(EmpresaClienteRepository));
            services.AddScoped(typeof(IEmpresaDistribuidoraRepository), typeof(EmpresaDistribuidoraRepository));
            services.AddScoped(typeof(IConductorRepository), typeof(ConductorRepository));
            services.AddScoped(typeof(IVehiculoRepository), typeof(VehiculoRepository));
            services.AddScoped(typeof(ISucursalRepository), typeof(SucursalRepository));
            services.AddScoped(typeof(IResponsableAlmacenRepository), typeof(ResponsableAlmacenRepository));

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
