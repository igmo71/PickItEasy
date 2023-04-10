using MediatR;
using PickItEasy.Domain;

namespace PickItEasy.Application.Services
{
    public class WeatherForecastUpdateNotification : INotification
    {
        public WeatherForecast? Value { get; set; }
    }
}
