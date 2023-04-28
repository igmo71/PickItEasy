using MediatR;
using Microsoft.AspNetCore.Components;
using PickItEasy.Application.MediatR.Services.WeatherForecast;
using PickItEasy.Domain;

namespace PickItEasy.Web.Pages
{
    public partial class FetchData :
        INotificationHandler<WeatherForecastCreateNotifucation>,
        INotificationHandler<WeatherForecastUpdateNotification>,
        IDisposable
    {
        [Inject]
        public WeatherForecastService? ForecastService { get; set; }

        private List<WeatherForecast>? forecasts;
        private SearchWeatherForecastModel searchForecastModel = new();

        private static event EventHandler<WeatherForecastCreateNotifucation>? WeatherForecastCreated;
        private static event EventHandler<WeatherForecastUpdateNotification>? WeatherForecastUpdated;

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

        private void WeatherForecastUpdatedHandle(object? sender, WeatherForecastUpdateNotification e)
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

        public Task Handle(WeatherForecastUpdateNotification notification, CancellationToken cancellationToken)
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
