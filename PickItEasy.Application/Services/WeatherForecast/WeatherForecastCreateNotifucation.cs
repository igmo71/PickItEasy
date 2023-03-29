using MediatR;
using PickItEasy.Domain;

namespace PickItEasy.Application.Services
{
    public class WeatherForecastCreateNotifucation : EventArgs, INotification
    {
        public WeatherForecast? Value { get; set; }

    }
}
