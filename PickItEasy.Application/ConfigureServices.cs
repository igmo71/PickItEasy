using FluentValidation;
using Mapster;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PickItEasy.Application.Common.Behaviors;
using PickItEasy.Application.Dtos.Mapping;
using PickItEasy.Application.Interfaces.Services;
using PickItEasy.Application.Interfaces.Services.WhsOrder.Out;
using PickItEasy.Application.Models.WhsOrder.Out.Dto;
using PickItEasy.Application.Services;
using PickItEasy.Application.Services.WhsOrder.Out;
using PickItEasy.Application.Services.WhsOrder.Out.Search;
using PickItEasy.Domain.Entities.WhsOrder.Out;
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
            
            
            services.AddScoped<SearchParameters>();
            services.AddScoped<IBaseDocumentService, BaseDocumentService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IWarehouseService, WarehouseService>();
            services.AddScoped<IWhsOrderOutService, WhsOrderOutService>();
            services.AddScoped<IWhsOrderOutQueueService, WhsOrderOutQueueService>();
            services.AddScoped<IWhsOrderOutStatusService, WhsOrderOutStatusService>();

            //services.AddSingleton<TypeAdapterConfig>();
            //TypeAdapterConfig typeAdapterConfig = new TypeAdapterConfig();
            WhsOrderOutDto.RegisterMapping();
            WhsOrderOutBaseDocumentDto.RegisterMapping();

            return services;
        }
    }
}
