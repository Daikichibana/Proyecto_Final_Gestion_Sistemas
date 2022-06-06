using AutoMapper;
using CAPAS.CAPA.DOMINIO.BASICO.ABSTRACCIONES;
using CAPAS.CAPA.DOMINIO.BASICO.ENTIDADES;
using CAPAS.CAPA.DOMINIO.BASICO.SERVICIOS;
using CAPAS.CAPA.DOMINIO.CLIENTES.ABSTRACCIONES;
using CAPAS.CAPA.DOMINIO.CLIENTES.SERVICIOS;
using CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.ABSTRACCIONES;
using CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.SERVICIOS;
using CAPAS.CAPA.DOMINIO.INVENTARIO.ABSTRACCIONES;
using CAPAS.CAPA.DOMINIO.INVENTARIO.SERVICIOS;
using CAPAS.CAPA.DOMINIO.USUARIOS.ABSTRACCIONES;
using CAPAS.CAPA.DOMINIO.USUARIOS.SERVICIOS;
using CAPAS.CAPA.TECNICA;
using CAPAS.CAPA.TECNICA.BASICO;
using CAPAS.CAPA.TECNICA.CLIENTES;
using CAPAS.CAPA.TECNICA.DISTRIBUIDORAS;
using CAPAS.CAPA.TECNICA.INVENTARIO;
using CAPAS.CAPA.TECNICA.PERSISTENCIA;
using CAPAS.CAPA.TECNICA.USUARIOS;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

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
                    b => b.MigrationsAssembly("CAPAS"))
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

            //Repositorios
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
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
