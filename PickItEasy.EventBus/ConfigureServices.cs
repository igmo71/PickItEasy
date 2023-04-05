using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PickItEasy.Application.Interfaces.EventBus;
using PickItEasy.EventBus.RabbitMq;

namespace PickItEasy.EventBus
{
    public static class ConfigureServices
    {
        public static IServiceCollection ConfigureEventBus(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EventBusConfiguration>(configuration.GetSection(EventBusConfiguration.Section));
            return services;
        }

        public static IServiceCollection AddEventBusPublisher(this IServiceCollection services)
        {
            services.AddTransient<IEventBusPublisher, WhsOrderOutPublisher>();
            return services;
        }

        public static IServiceCollection AddEventBusConsumer(this IServiceCollection services)
        {
            services.AddHostedService<WhsOrderOutConsumer>();
            return services;
        }
    }
}
