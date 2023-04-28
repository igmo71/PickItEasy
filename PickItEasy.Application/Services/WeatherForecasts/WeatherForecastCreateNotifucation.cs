using MediatR;
using PickItEasy.Domain;

namespace PickItEasy.Application.Services.WeatherForecasts
{
    public class WeatherForecastCreateNotifucation : EventArgs, INotification
    {
        public WeatherForecast? Value { get; set; }

    }
}
