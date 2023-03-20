using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
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
            });

            //services.AddValidatorsFromAssemblies
            //services.AddTransient(typeof(INotificationHandler<>), typeof(WeatherForecastCreateNotificationHandler));
            
            return services;
        }
    }
}
