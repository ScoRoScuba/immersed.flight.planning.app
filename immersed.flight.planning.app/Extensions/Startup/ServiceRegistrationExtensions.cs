using Autofac;

namespace immersed.flight.planning.app.Extensions.Startup
{
    public static class ServiceRegistrationExtensions
    {
        public static ContainerBuilder AddServices(this ContainerBuilder containerBuilder)
        {
            return containerBuilder;
        }
    }
}
