namespace PickItEasy.Web.EventBus
{
    public class WeatherForecasEventManager
    {
        public event EventHandler? WeatherForecastCreated;

        public void OnWeatherForecastCreated()
        {
            EventHandler? handler = WeatherForecastCreated;
            if (handler != null)
            {
                handler.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
