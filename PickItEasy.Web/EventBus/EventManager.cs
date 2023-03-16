namespace PickItEasy.Web.EventBus
{
    public class EventManager
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
