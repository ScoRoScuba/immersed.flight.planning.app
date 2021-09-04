using System.Threading.Tasks;
using Autofac;
using immersed.flight.planning.app.Extensions.Startup;
using immersed.flight.planning.app.HealthChecks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;

namespace immersed.flight.planning.app
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.AppSettings()
                .CreateLogger();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.Register(c => Log.Logger).AsImplementedInterfaces().SingleInstance();

            builder.AddConfiguration(_configuration);

            builder.AddServices();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging((a) =>
            {
                a.AddSerilog();
            });

            services.AddHealthChecks().AddCheck<DefaultHealthCheck>("default_health_check");

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "immersed.flight.planning.app", Version = "v1" });
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "immersed.flight.planning.app v1"));

//            app.UseHttpsRedirection();

            app.UseRouting();

//            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/healthz");
                endpoints.MapGet("/", context =>
                {
                    context.Response.Redirect("/swagger/index.html", permanent: false);
                    return Task.CompletedTask;
                });

                endpoints.MapControllers();
            });
        }
    }
}
