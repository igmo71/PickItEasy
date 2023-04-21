namespace PickItEasy.Application.Services.WhsOrdersOut.Queries
{
    public interface ISearchState
    {
        SearchParameters Parameters { get; set; }
    };

    public class SearchState : ISearchState
    {
        public SearchParameters Parameters { get; set; } = new();
    }
}
