using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PickItEasy.Application.Common.Behaviors;
using PickItEasy.Application.Dtos.Mapping;
using PickItEasy.Application.Services.Products.Mapping;
using System.Reflection;
using IntegrationMapping = PickItEasy.Application.Integration.WhsOrdersOut;

namespace PickItEasy.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
                config.AddBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
                config.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            });

            services.AddAutoMapper(config =>
            {
                config.AddProfile<WhsOrderOutMapperProfile>();
                config.AddProfile<IntegrationMapping.WhsOrderOutMapperProfile>();
                config.AddProfile<ProductMappingProfile>();
            }); services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });

            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            //services.AddTransient(typeof(INotificationHandler<>), typeof(WeatherForecastCreateNotificationHandler));

            return services;
        }
    }
}
