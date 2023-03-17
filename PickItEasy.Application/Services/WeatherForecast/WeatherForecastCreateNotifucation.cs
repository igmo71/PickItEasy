using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PickItEasy.Domain;

namespace PickItEasy.Application.Services
{
    public class WeatherForecastCreateNotifucation : EventArgs, INotification
    {
        public WeatherForecast? Value { get; set; }

    }
}
