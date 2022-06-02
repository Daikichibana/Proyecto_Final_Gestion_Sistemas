using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Proyecto_Final_Gestion_Sistemas.Client.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Proyecto_Final_Gestion_Sistemas.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<IInventarioServices, InventarioServices>();

            await builder.Build().RunAsync();
        }
    }
}
