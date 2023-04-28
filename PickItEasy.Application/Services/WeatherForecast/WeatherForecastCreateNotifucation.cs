using MediatR;
using PickItEasy.Domain;

namespace PickItEasy.Application.Services.WeatherForecast
{
    public class WeatherForecastCreateNotifucation : EventArgs, INotification
    {
        public WeatherForecast? Value { get; set; }

    }
}
