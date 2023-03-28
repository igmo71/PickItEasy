using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PickItEasy.Application;
using PickItEasy.Application.Interfaces;
using PickItEasy.Application.Interfaces.EventBus;
using PickItEasy.EventBus;
using PickItEasy.Persistence;
using PickItEasy.WebApi.Middleware;
using PickItEasy.WebApi.Services;
using Serilog;

namespace PickItEasy.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseSerilog((ctx, lc) => lc
                .ReadFrom.Configuration(ctx.Configuration)
                .WriteTo.Console());

            // Add services to the container.

            builder.Services.AddApplication();
            builder.Services.AddPersistence(builder.Configuration);

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.ConfigureEventBus(builder.Configuration);
            builder.Services.AddEventBusPublisher();

            builder.Services.AddSingleton<ICurrentUserService, CurrentUserService>();
            builder.Services.AddHttpContextAccessor();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCustomExceptionHandler();

            app.UseSerilogRequestLogging();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}