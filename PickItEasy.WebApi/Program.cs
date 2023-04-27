using Microsoft.AspNetCore.HttpLogging;
using PickItEasy.Application;
using PickItEasy.Application.Common;
using PickItEasy.Application.Interfaces;
using PickItEasy.EventBus;
using PickItEasy.Integration;
using PickItEasy.Integration.Connectors.Ut1c;
using PickItEasy.Persistence;
using PickItEasy.WebApi.Middleware;
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

            builder.Services.AddHttpLogging(options =>
                options.LoggingFields = options.LoggingFields | HttpLoggingFields.RequestBody | HttpLoggingFields.ResponseBody);

            builder.Services.AddApplication();
            builder.Services.AddPersistence(builder.Configuration);
            builder.Services.AddConnectors(builder.Configuration);

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSignalR();

            builder.Services.ConfigureEventBus(builder.Configuration);
            builder.Services.AddEventBusPublisher();

            builder.Services.AddSingleton<ICurrentUserService, CurrentUserService>();
            builder.Services.AddHttpContextAccessor();

            var app = builder.Build();

            app.UseHttpLogging();

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
            app.MapHub<Hub1cUt>("/Hub1cUt");

            app.Run();
        }
    }
}