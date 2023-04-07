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

            LoggerProviderOptions.RegisterProviderOptions<EventLogSettings, EventLogLoggerProvider>(builder.Services);
            builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));
            builder.Logging.AddEventLog();            
            var logger = LoggerFactory.Create(config => config.AddEventLog()).CreateLogger("PickItEasy.Integration");

            builder.Services.AddHostedService<ProxyWorker>();
            builder.Services.AddHostedService<HealthChecker>();


            string hubUri = builder.Configuration.GetSection("HubUri").Value
                ?? throw new ApplicationException("Fail to get configuration");

            HubConnection hubConnection = new HubConnectionBuilder()
                .WithUrl(hubUri)
                .WithAutomaticReconnect()
                .Build();

            //hubConnection.On<WhsOrderOutDto>("PostWhsOrderOutDto", async (dto) =>
            //{
            //    await PostWhsOrderOutDto(dto, hubConnection, logger);
            //});

            hubConnection.On("PostWhsOrderOutDtoWithResponse", new[] { typeof(WhsOrderOutDto) }, HandleWhsOrderOutDtoRequest);

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

        //private static async Task PostWhsOrderOutDto(WhsOrderOutDto dto, HubConnection hubConnection, ILogger logger)
        //{
        //    logger.LogInformation($"{dto.Name} - received");
        //    var httpStatusCode = HttpStatusCode.OK;
        //    await hubConnection.SendAsync("GetResult", $"{dto.Name} - {httpStatusCode}"); // Guid
        //}

        //private static Task<string> PostWhsOrderOutDtoWithResponse(WhsOrderOutDto dto, ILogger logger)
        //{
        //    logger.LogInformation($"{dto.Name} - received");
        //    var httpStatusCode = HttpStatusCode.OK;
        //    return Task.FromResult($"{dto.Name} - {httpStatusCode}"); // Guid
        //}

        public static async Task<string> HandleWhsOrderOutDtoRequest(object?[] input)
        {
            Console.WriteLine($"{(input[0] as WhsOrderOutDto).Name} - received");
            //logger.LogInformation($"{(input[0] as WhsOrderOutDto).Name} - received");
            // Do some asynchronous work
            await Task.Delay(1000);

            var result = (input[0] as WhsOrderOutDto).Name;
            return $"{result} - Ok";
        }
    }
}