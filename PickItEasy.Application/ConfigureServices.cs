using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PickItEasy.Application.Common.Behaviors;
using PickItEasy.Application.Dtos.Mapping;
using PickItEasy.Application.Services.WhsOrder.Out.Search;
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
                config.AddProfile<BaseDocumentMappingProfile>();
                config.AddProfile<ProductMappingProfile>();
                config.AddProfile<WarehouseMappingProfile>();
                config.AddProfile<WhsOrderOutMappingProfile>();
                config.AddProfile<WhsOrderOutQueueMappingProfile>();
                config.AddProfile<WhsOrderOutStatusMappingProfile>();
            }); services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });

            //services.AddTransient(typeof(INotificationHandler<>), typeof(WeatherForecastCreateNotificationHandler));

            //services.AddScoped<ISearchState, SearchState>();
            services.AddScoped<SearchParameters>();

            return services;
        }
    }
}
