using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PickItEasy.Web.Data;

namespace PickItEasy.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        private readonly WeatherForecastService _forecastService;

        public WeatherForecastController(WeatherForecastService forecastService)
        {
            _forecastService = forecastService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            WeatherForecast[]? forecastsawait = await _forecastService.GetForecastAsync(DateOnly.FromDateTime(DateTime.Now));
            return Ok(forecastsawait);
        }
    }
}
