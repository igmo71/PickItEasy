using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Components.Authorization;
using PickItEasy.Application;
using PickItEasy.Application.Common;
using PickItEasy.Application.Common.Behaviors;
using PickItEasy.Application.Interfaces;
using PickItEasy.Application.Services;
using PickItEasy.Application.Services.Products.Mapping;
using PickItEasy.Application.Services.WhsOrdersOut.Mapping;
using PickItEasy.EventBus;
using PickItEasy.Persistence;
using PickItEasy.Persistence.Data;
using PickItEasy.Persistence.Models;
using PickItEasy.WebApp.BlazorServer.Areas.Identity;
using Serilog;
using System.Reflection;

namespace PickItEasy.WebApp.BlazorServer
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

            builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<ApplicationUser>>();

            builder.Services.ConfigureEventBus(builder.Configuration);
            builder.Services.AddEventBusConsumer();

            builder.Services.AddSingleton<ICurrentUserService, CurrentUserService>();
            builder.Services.AddHttpContextAccessor();

            builder.Services.AddScoped<WeatherForecastService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
        }
    }
}