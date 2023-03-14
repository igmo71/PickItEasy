using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PickItEasy.Web.Data;

namespace PickItEasy.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User")]
    public class WeatherForecastController : BaseController
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
