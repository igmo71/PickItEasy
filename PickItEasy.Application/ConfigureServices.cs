using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PickItEasy.Application.Common.Behaviors;
using PickItEasy.Application.Services.Products.Mapping;
using PickItEasy.Application.Services.WhsOrdersOut.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
            });

            services.AddAutoMapper(config =>
            {
                config.AddProfile<WhsOrderOutMapperProfile>();
                config.AddProfile<ProductMappingProfile>();
            });

            //services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            //services.AddTransient(typeof(INotificationHandler<>), typeof(WeatherForecastCreateNotificationHandler));

            return services;
        }
    }
}
