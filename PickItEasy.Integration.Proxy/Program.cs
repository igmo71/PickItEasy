namespace PickItEasy.Integration.Proxy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);

            builder.Logging.AddEventLog();

            builder.Services.AddHostedService<HealthChecker>();
            builder.Services.AddSingleton<ISignalRHubClient, SignalRHubClient>();
            builder.Services.AddSingleton<IRequestHandler, RequestHandler>();

            builder.Services.AddWindowsService(options => options.ServiceName = "PickItEasy.Integration");

            IHost host = builder.Build();
            host.Run();
        }
    }
}