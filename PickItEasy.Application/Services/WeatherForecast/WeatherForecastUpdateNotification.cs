using MediatR;
using PickItEasy.Domain;

namespace PickItEasy.Application.Services.WeatherForecast
{
    public class WeatherForecastUpdateNotification : INotification
    {
        public WeatherForecast? Value { get; set; }
    }
}
