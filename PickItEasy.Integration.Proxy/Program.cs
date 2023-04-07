using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Logging.EventLog;
using PickItEasy.Application.Dtos;

namespace PickItEasy.Integration.Proxy
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);

            builder.Services.AddWindowsService(options =>
            {
                options.ServiceName = "PickItEasy.Integration";
            });

            //LoggerProviderOptions.RegisterProviderOptions<EventLogSettings, EventLogLoggerProvider>(builder.Services);
            //builder.Logging.ClearProviders();
            //builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));
            builder.Logging.AddEventLog();
            //builder.Logging.AddConsole();
            var logger = LoggerFactory.Create(config => config.AddEventLog()).CreateLogger("PickItEasy.Integration");

            builder.Services.AddHostedService<ProxyWorker>();
            builder.Services.AddHostedService<HealthChecker>();


            string hubUri = builder.Configuration.GetSection("HubUri").Value
                ?? throw new ApplicationException("Fail to get configuration");

            HubConnection hubConnection = new HubConnectionBuilder()
                .WithUrl(hubUri)
                .WithAutomaticReconnect()
                .Build();

            //hubConnection.On("PostWhsOrderOutDto", new[] { typeof(WhsOrderOutDto) }, HandlePostWhsOrderOutDto);
            hubConnection.On("PostWhsOrderOutDto", new[] { typeof(WhsOrderOutDto) }, async (input) =>
            {
                Console.WriteLine($"{(input[0] as WhsOrderOutDto).Name} - received");

                logger.LogInformation($"{(input[0] as WhsOrderOutDto).Name} - received");

                await Task.Delay(1000);

                var result = (input[0] as WhsOrderOutDto).Name;

                return $"{result} - Ok";
            });

            await StartConnection(hubConnection, logger);

            IHost host = builder.Build();

            host.Run();
        }


        private static async Task StartConnection(HubConnection hubConnection, ILogger logger)
        {

            logger.LogInformation($"Trying to connect");
            try
            {
                await hubConnection.StartAsync();
                logger.LogInformation($"Connected");
            }
            catch (Exception ex)
            {
                await Task.Delay(3000);
                await StartConnection(hubConnection, logger);
            }
        }

        public static async Task<string> HandlePostWhsOrderOutDto(object?[] input)
        {
            Console.WriteLine($"{(input[0] as WhsOrderOutDto).Name} - received");

            //logger.LogInformation($"{(input[0] as WhsOrderOutDto).Name} - received");

            await Task.Delay(1000);

            var result = (input[0] as WhsOrderOutDto).Name;

            return $"{result} - Ok";
        }
    }
}