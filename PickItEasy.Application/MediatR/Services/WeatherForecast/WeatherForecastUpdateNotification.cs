using MediatR;
using PickItEasy.Domain;

namespace PickItEasy.Application.MediatR.Services.WeatherForecast
{
    public class WeatherForecastUpdateNotification : INotification
    {
        public WeatherForecast? Value { get; set; }
    }
}
