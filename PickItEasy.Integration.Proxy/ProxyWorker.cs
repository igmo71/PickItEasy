namespace PickItEasy.Integration.Proxy
{
    public class ProxyWorker : BackgroundService
    {
        private readonly ILogger<ProxyWorker> _logger;

        public ProxyWorker(ILogger<ProxyWorker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("ProxyWorker is up: {time}", DateTimeOffset.Now);
                await Task.Delay(60000, stoppingToken);
            }
        }
    }
}