using Microsoft.AspNetCore.Components;
using PickItEasy.Application.Services;
using PickItEasy.Domain;
using PickItEasy.Web.EventBus;

namespace PickItEasy.Web.Pages
{
    public partial class FetchData : IDisposable
    {
        [Inject]
        public WeatherForecastService? ForecastService { get; set; }

        [Inject]
        public EventManager? EventManager { get; set; }

        private WeatherForecast[]? forecasts;
        private SearchWeatherForecastModel searchWeatherForecastModel = new();

        protected override async Task OnInitializedAsync()
        {
            if (ForecastService is not null)
                forecasts = await ForecastService.GetAllAsync();
        }

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            if (firstRender)
            {
                if (EventManager is not null)
                    EventManager.WeatherForecastCreated += UpdateList;
            }
        }

        private async Task SearchAsync(SearchWeatherForecastModel searchWeatherForecastModel)
        {
            this.searchWeatherForecastModel = searchWeatherForecastModel;
            if (ForecastService is not null)
            {
                forecasts = await ForecastService.SearchAsync(searchWeatherForecastModel);
                //StateHasChanged();
                await InvokeAsync(() => StateHasChanged());
            }
        }

        private void UpdateList(object? sender, EventArgs e)
        {
            SearchAsync(searchWeatherForecastModel).GetAwaiter().GetResult();
            //StateHasChanged();
            InvokeAsync(() => StateHasChanged());
        }

        public void Dispose()
        {
            if (EventManager is not null)
                EventManager.WeatherForecastCreated -= UpdateList;
        }
    }
}
