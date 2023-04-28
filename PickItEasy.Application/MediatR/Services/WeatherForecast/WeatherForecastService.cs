using Microsoft.EntityFrameworkCore;
using PickItEasy.Application.Interfaces;
using PickItEasy.Domain;

namespace PickItEasy.Application.MediatR.Services.WeatherForecast
{
    public class WeatherForecastService
    {
        public static readonly string[] Summaries = new[]
            { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };
        private readonly IApplicationDbContext _context;

        public WeatherForecastService(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<WeatherForecast>> GetAllAsync()
        {
            var result = await _context.WeatherForecasts.ToListAsync();

            return result;
        }

        public async Task<List<WeatherForecast>> SearchAsync(SearchWeatherForecastModel searchModel)
        {
            var query = _context.WeatherForecasts.AsQueryable();

            if (!string.IsNullOrEmpty(searchModel.Summary))
                query = query.Where(e => e.Summary == searchModel.Summary);

            var result = await query.AsNoTracking().ToListAsync();

            return result;
        }

        public async Task<WeatherForecast> CreateAsync(WeatherForecast weatherForecast)
        {
            await _context.WeatherForecasts.AddAsync(weatherForecast);
            await _context.SaveChangesAsync(CancellationToken.None);
            return weatherForecast;
        }

        public async Task<WeatherForecast?> UpdateAsync(WeatherForecast weatherForecast)
        {
            var item = await _context.WeatherForecasts.FindAsync(weatherForecast.Id);
            if (item != null)
            {
                item.Summary = weatherForecast.Summary;
                item.TemperatureC = weatherForecast.TemperatureC;
                await _context.SaveChangesAsync(CancellationToken.None);
            }
            return item;
        }

        public async Task AddRangeAsync(WeatherForecast[] weatherForecasts)
        {
            await _context.WeatherForecasts.AddRangeAsync(weatherForecasts);
            await _context.SaveChangesAsync(CancellationToken.None);
        }

        public async Task AddRandomRangeAsync()
        {
            WeatherForecast[] weatherForecasts = await GetRandomRangeAsync(DateOnly.FromDateTime(DateTime.Now));
            await AddRangeAsync(weatherForecasts);
        }

        public static Task<WeatherForecast[]> GetRandomRangeAsync(DateOnly startDate)
        {
            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToArray());
        }

        public async Task DeleteAllAsync()
        {
            var range = await _context.WeatherForecasts.ToListAsync();
            _context.WeatherForecasts.RemoveRange(range);
            await _context.SaveChangesAsync(CancellationToken.None);
        }
    }
}
