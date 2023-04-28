using MediatR;
using Microsoft.Extensions.Logging;

namespace PickItEasy.Application.Services.WeatherForecasts
{
    public class WeatherForecastCreateNotifucationHandler : INotificationHandler<WeatherForecastCreateNotifucation>
    {
        private readonly ILogger<WeatherForecastCreateNotifucationHandler> _logger;

        public WeatherForecastCreateNotifucationHandler(ILogger<WeatherForecastCreateNotifucationHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(WeatherForecastCreateNotifucation notification, CancellationToken cancellationToken)
        {
            _logger.LogDebug("Handle of WeatherForecast Create Notifucation");
            return Task.CompletedTask;
        }
    }
}
