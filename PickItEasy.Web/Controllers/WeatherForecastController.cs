using MediatR;
using Microsoft.AspNetCore.Mvc;
using PickItEasy.Application.MediatR.Services.WeatherForecast;
using PickItEasy.Application.Services;
using PickItEasy.Application.Services.WeatherForecast;
using PickItEasy.Domain;
using PickItEasy.Web.EventBus;

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
            var result = await _forecastService.CreateAsync(weatherForecast);

            //_forecastEventManager.OnWeatherForecastCreated();
            await _mediator.Publish(new WeatherForecastCreateNotifucation() { Value = result });

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(WeatherForecast weatherForecast)
        {
            var result = await _forecastService.UpdateAsync(weatherForecast);

            //_forecastEventManager.OnWeatherForecastCreated();
            await _mediator.Publish(new WeatherForecastUpdateNotification() { Value = result });

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAll()
        {
            await _forecastService.DeleteAllAsync();
            return NoContent();
        }
    }
}
