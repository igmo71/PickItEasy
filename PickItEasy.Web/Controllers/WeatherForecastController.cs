using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PickItEasy.Application.Services;
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
        private readonly EventManager _eventManager;

        public WeatherForecastController(WeatherForecastService forecastService, EventManager eventManager)
        {
            _forecastService = forecastService;
            _eventManager = eventManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            WeatherForecast[]? forecasts = await _forecastService.GetAllAsync(/*DateOnly.FromDateTime(DateTime.Now)*/);
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

            _eventManager.OnWeatherForecastCreated();

            return Ok(result);
        }   
    }
}
