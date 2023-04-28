using MediatR;
using PickItEasy.Domain;

namespace PickItEasy.Application.MediatR.Services.WeatherForecast
{
    public class WeatherForecastCreateNotifucation : EventArgs, INotification
    {
        public WeatherForecast? Value { get; set; }

    }
}
