﻿using MediatR;
using PickItEasy.Domain;

namespace PickItEasy.Application.Services
{
    public class WeatherForecastUpdateNotifucation : INotification
    {
        public WeatherForecast? Value { get; set; }
    }
}
