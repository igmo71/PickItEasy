using MediatR;
using PickItEasy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Services
{
    public class WeatherForecastUpdateNotifucation : INotification
    {
        public WeatherForecast? Value { get; set; }
    }
}
