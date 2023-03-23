using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PickItEasy.Application;
using PickItEasy.Application.Interfaces;
using PickItEasy.Application.Interfaces.EventBus;
using PickItEasy.EventBus;
using PickItEasy.Persistence;
using PickItEasy.WebApi.Services;
using Serilog;

namespace PickItEasy.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Log.Logger = new LoggerConfiguration()
            //    .ReadFrom.Configuration(builder.Configuration)
            //    .WriteTo.Console()
            //    .CreateBootstrapLogger();

            builder.Host.UseSerilog((ctx, lc) => lc
                .ReadFrom.Configuration(ctx.Configuration)
                .WriteTo.Console());

            // Add services to the container.

            builder.Services.AddApplication();
            builder.Services.AddPersistence(builder.Configuration);

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.ConfigureEventBus(builder.Configuration);
            builder.Services.AddEventBusPublisher();

            builder.Services.AddSingleton<ICurrentUserService, CurrentUserService>();
            builder.Services.AddHttpContextAccessor();

            var app = builder.Build();

            app.UseSerilogRequestLogging();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}