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
                _logger.LogWarning("Worker running (0) at: {time}", DateTimeOffset.Now);
                _logger.LogInformation("------------->Worker running at: {time}", DateTimeOffset.Now);
                _logger.LogWarning("Worker running (1) at: {time}", DateTimeOffset.Now);

                await Task.Delay(6000, stoppingToken);
            }
        }
    }
}