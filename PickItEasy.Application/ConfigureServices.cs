using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PickItEasy.Application.Common.Behaviors;
using PickItEasy.Application.Dtos.Mapping;
using PickItEasy.Application.Services.WhsOrdersOut.Queries;
using System.Reflection;

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
                config.AddProfile<ProductMappingProfile>();
                config.AddProfile<WhsOrderOutMappingProfile>();
                config.AddProfile<WhsOrderOutStatusMappingProfile>();
                config.AddProfile<WhsOrderOutQueueMappingProfile>();
            }); services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });

            //services.AddTransient(typeof(INotificationHandler<>), typeof(WeatherForecastCreateNotificationHandler));

            services.AddScoped<SearchParameters>();

            return services;
        }
    }
}
