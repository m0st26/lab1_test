using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using parkWiFis.InfrastructureServices.Gateways.Database;
using Microsoft.EntityFrameworkCore;
using parkWiFis.ApplicationServices.GetRouteListUseCase;
using parkWiFis.ApplicationServices.Ports.Gateways.Database;
using parkWiFis.ApplicationServices.Repositories;
using parkWiFis.DomainObjects.Ports;

namespace parkWiFis.WebService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TransportContext>(opts => 
                opts.UseSqlite($"Filename={System.IO.Path.Combine(System.Environment.CurrentDirectory, "MoscowTransport.db")}")
            );

            services.AddScoped<IparkWiFiDatabaseGateway, TransportEFSqliteGateway>();

            services.AddScoped<DbRouteRepository>();
            services.AddScoped<IReadOnlyparkwifiRepository>(x => x.GetRequiredService<DbRouteRepository>());
            services.AddScoped<IparkwifiRepository>(x => x.GetRequiredService<DbRouteRepository>());

            services.AddScoped<DbTransportOrganizationRepository>();
            services.AddScoped<IReadOnlyTransportOrganizationRepository>(x => x.GetRequiredService<DbTransportOrganizationRepository>());
            services.AddScoped<ITransportOrganizationRepository>(x => x.GetRequiredService<DbTransportOrganizationRepository>());


            services.AddScoped<IGetparkWiFiListUseCase, GetparkWiFiListUseCase>();

            
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
