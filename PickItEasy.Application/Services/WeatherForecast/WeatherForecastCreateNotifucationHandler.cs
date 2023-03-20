using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Services
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
