namespace PickItEasy.Integration.Proxy
{
    public class HealthChecker : BackgroundService
    {
        private readonly ILogger<HealthChecker> _logger;
        private readonly ISignalRHubClient _signalRHubClient;

        public HealthChecker(ILogger<HealthChecker> logger, ISignalRHubClient signalRHubClient)
        {
            _logger = logger;
            _signalRHubClient = signalRHubClient;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {                
                _logger.LogInformation("Health Check: {State}", _signalRHubClient.State);

                await Task.Delay(60000, stoppingToken);
            }
        }
    }
}