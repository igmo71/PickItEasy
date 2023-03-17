using MediatR;
using Microsoft.AspNetCore.Components;
using PickItEasy.Application.Services;
using PickItEasy.Domain;

namespace PickItEasy.Web.Pages
{
    public partial class FetchData :
        INotificationHandler<WeatherForecastCreateNotifucation>,
        INotificationHandler<WeatherForecastUpdateNotifucation>,
        IDisposable
    {
        [Inject]
        public WeatherForecastService? ForecastService { get; set; }

        private List<WeatherForecast>? forecasts;
        private SearchWeatherForecastModel searchForecastModel = new();

        private static event EventHandler<WeatherForecastCreateNotifucation>? WeatherForecastCreated;
        private static event EventHandler<WeatherForecastUpdateNotifucation>? WeatherForecastUpdated;

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
                WeatherForecastUpdated += WeatherForecastUpdatedHandle;
            }
        }

        private void WeatherForecastCreatedHandle(object? sender, WeatherForecastCreateNotifucation e)
        {
            SearchAsync(searchForecastModel).GetAwaiter().GetResult();
        }

        private void WeatherForecastUpdatedHandle(object? sender, WeatherForecastUpdateNotifucation e)
        {
            SearchAsync(searchForecastModel).GetAwaiter().GetResult();
        }

        private async Task SearchAsync(SearchWeatherForecastModel searchWeatherForecastModel)
        {
            if (ForecastService is null) return;

            forecasts = await ForecastService.SearchAsync(searchWeatherForecastModel);
            await InvokeAsync(StateHasChanged);
        }

        public Task Handle(WeatherForecastCreateNotifucation notification, CancellationToken cancellationToken)
        {
            WeatherForecastCreated?.Invoke(this, notification);
            return Task.CompletedTask;
        }

        public Task Handle(WeatherForecastUpdateNotifucation notification, CancellationToken cancellationToken)
        {
            WeatherForecastUpdated?.Invoke(this, notification);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            WeatherForecastCreated -= WeatherForecastCreatedHandle;
            WeatherForecastUpdated -= WeatherForecastUpdatedHandle;
        }
    }
}
