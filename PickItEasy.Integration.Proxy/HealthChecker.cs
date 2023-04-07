namespace PickItEasy.Integration.Proxy
{
    public class HealthChecker : BackgroundService
    {
        private readonly ILogger<HealthChecker> _logger;

        public HealthChecker(ILogger<HealthChecker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Health Check: {time}", DateTimeOffset.Now);

                await Task.Delay(60000, stoppingToken);
            }
        }
    }
}