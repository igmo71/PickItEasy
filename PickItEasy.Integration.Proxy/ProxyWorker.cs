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
                //_logger.Log(LogLevel.Information, "Worker running at: {time}", DateTimeOffset.Now);
                //_logger.LogError("Worker running at: {time}", DateTimeOffset.Now);
                _logger.LogWarning("Worker running at: {time}", DateTimeOffset.Now);
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                //_logger.LogDebug("Worker running at: {time}", DateTimeOffset.Now);

                await Task.Delay(6000, stoppingToken);
            }
        }
    }
}