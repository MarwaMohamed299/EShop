using BuildingBlocks.Behaviors;
using Carter;
using System.Reflection;

namespace Ordering.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddCarter();

            return services;
        }

        public static WebApplication UseApiServices(this WebApplication app)
        {
            app.MapCarter();
            return app;
        }
    }
}
