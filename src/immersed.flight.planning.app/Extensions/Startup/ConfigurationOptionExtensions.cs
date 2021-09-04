using Autofac;
using Microsoft.Extensions.Configuration;

namespace immersed.flight.planning.app.Extensions.Startup
{
    public static class ConfigurationOptionExtensions
    {
        public static ContainerBuilder AddConfiguration(this ContainerBuilder containerBuilder,
            IConfiguration configuration)
        {
            return containerBuilder;
        }
    }
}
