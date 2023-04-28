using MediatR;
using PickItEasy.Domain;

namespace PickItEasy.Application.Services.WeatherForecasts
{
    public class WeatherForecastUpdateNotification : INotification
    {
        public WeatherForecast? Value { get; set; }
    }
}
