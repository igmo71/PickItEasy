using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PickItEasy.Application.Services;
using PickItEasy.Domain;
using PickItEasy.Web.EventBus;
using PickItEasy.Web.Pages;

namespace PickItEasy.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User")]
    public class WeatherForecastController : BaseController
    {
        private readonly WeatherForecastService _forecastService;
        private readonly WeatherForecasEventManager _forecastEventManager;
        private readonly IMediator _mediator;

        public WeatherForecastController(WeatherForecastService forecastService, WeatherForecasEventManager forecastEventManager, IMediator mediator)
        {
            _forecastService = forecastService;
            _forecastEventManager = forecastEventManager;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var forecasts = await _forecastService.GetAllAsync();
            return Ok(forecasts);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateRandomRange()
        {
            await _forecastService.AddRandomRangeAsync();
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post(WeatherForecast weatherForecast)
        {
            var result = await _forecastService.AddAsync(weatherForecast);

            //_forecastEventManager.OnWeatherForecastCreated();
            await _mediator.Publish(new WeatherForecastCreateNotifucation() { Value = weatherForecast });
            
            return Ok(result);
        }   
    }
}
