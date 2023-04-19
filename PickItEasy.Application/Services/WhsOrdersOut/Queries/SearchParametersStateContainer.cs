namespace PickItEasy.Application.Services.WhsOrdersOut.Queries
{
    public class SearchParametersStateContainer
    {
        private SearchParameters? searchParameters;

        public SearchParameters SearchParameters
        {
            get => searchParameters ?? new();
            set
            {
                searchParameters = value;
                NotifyStateChanged();
            }
        }

        public event Action? OnChange;
        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
