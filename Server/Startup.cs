using AutoMapper;
using CAPAS.CAPA.DOMINIO.BASICO.ABSTRACCIONES;
using CAPAS.CAPA.DOMINIO.BASICO.ENTIDADES;
using CAPAS.CAPA.DOMINIO.BASICO.SERVICIOS;
using CAPAS.CAPA.DOMINIO.CLIENTES.SERVICIOS;
using CAPAS.CAPA.DOMINIO.INVENTARIO.ABSTRACCIONES;
using CAPAS.CAPA.DOMINIO.INVENTARIO.SERVICIOS;
using CAPAS.CAPA.TECNICA;
using CAPAS.CAPA.TECNICA.BASICO;
using CAPAS.CAPA.TECNICA.CLIENTES;
using CAPAS.CAPA.TECNICA.INVENTARIO;
using CAPAS.CAPA.TECNICA.PERSISTENCIA;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            services.AddScoped(typeof(IAdministrarTarjetaClienteService), typeof(AdministrarTarjetaClienteService)) ;

            //Repositorios
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(ITipoProductoRepository), typeof(TipoProductoRepository));
            services.AddScoped(typeof(IRubroRepository), typeof(RubroRepository));
            services.AddScoped(typeof(ITarjetaClienteRepository), typeof(TarjetaClienteRepository));

            //Configuracion del Mapeador
            var config = new MapperConfiguration(configure =>
            {
                configure.AddProfile(new MappingProfile());
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
            services.AddMvc();

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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
