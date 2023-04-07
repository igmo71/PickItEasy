namespace PickItEasy.Integration.Proxy
{
    public class HealthChecker : BackgroundService
    {
        private readonly ILogger<ProxyWorker> _logger;

        public HealthChecker(ILogger<ProxyWorker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("HealthChecker running at: {time}", DateTimeOffset.Now);

                await Task.Delay(200000, stoppingToken);
            }
        }
    }
}