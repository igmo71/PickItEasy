using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PickItEasy.Integration.Connectors.Ut1c;

namespace PickItEasy.Integration
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddConnectors(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddConnectorUt1c(configuration);
            return services;
        }
    }
}
