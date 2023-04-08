using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Logging.EventLog;
using PickItEasy.Application.Dtos;

namespace PickItEasy.Integration.Proxy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);

            builder.Logging.AddEventLog();

            //builder.Services.AddHostedService<ProxyWorker>();
            builder.Services.AddHostedService<HealthChecker>();
            builder.Services.AddSingleton<ISignalRHubClient, SignalRHubClient>();
            builder.Services.AddSingleton<IRequestHandler, RequestHandler>();

            builder.Services.AddWindowsService(options => options.ServiceName = "PickItEasy.Integration");

            IHost host = builder.Build();
            host.Run();
        }
    }
}