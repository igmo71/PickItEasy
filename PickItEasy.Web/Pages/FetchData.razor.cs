using MediatR;
using Microsoft.AspNetCore.Components;
using PickItEasy.Application.Services;
using PickItEasy.Domain;

namespace PickItEasy.Web.Pages
{
    public partial class FetchData : INotificationHandler<WeatherForecastCreateNotifucation>, IDisposable
    {
        [Inject]
        public WeatherForecastService? ForecastService { get; set; }

        private List<WeatherForecast>? forecasts;
        private SearchWeatherForecastModel searchForecastModel = new();

        private static event EventHandler<WeatherForecastCreateNotifucation>? WeatherForecastCreated;

        protected override async Task OnInitializedAsync()
        {
            if (ForecastService is null) return;

            forecasts = await ForecastService.GetAllAsync();
        }

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            if (firstRender)
            {
                WeatherForecastCreated += WeatherForecastCreatedHandle;
            }
        }

        private void WeatherForecastCreatedHandle(object? sender, WeatherForecastCreateNotifucation e)
        {
            if (e.Value is null) return;

            forecasts?.Add(e.Value);
            InvokeAsync(StateHasChanged);
        }

        private async Task SearchAsync(SearchWeatherForecastModel searchWeatherForecastModel)
        {
            if (ForecastService is null) return;

            forecasts = await ForecastService.SearchAsync(searchWeatherForecastModel);
            //StateHasChanged(); // InvokeAsync(StateHasChanged);
            await InvokeAsync(() => StateHasChanged()); // !!!

        }

        public Task Handle(WeatherForecastCreateNotifucation notification, CancellationToken cancellationToken)
        {
            WeatherForecastCreated?.Invoke(this, notification);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            WeatherForecastCreated -= WeatherForecastCreatedHandle;
        }
    }
}
