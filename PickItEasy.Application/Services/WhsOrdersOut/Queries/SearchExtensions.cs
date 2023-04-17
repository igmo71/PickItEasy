using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.Services.WhsOrdersOut.Queries
{
    public static class SearchExtensions
    {
        public static IQueryable<WhsOrderOut> Search(this IQueryable<WhsOrderOut> query, SearchParameters parameters)
        {
            query = query.Where(e => e.Active);

            if (parameters.DocumentId != null)
            {
                query = query.Where(e => e.Id == parameters.DocumentId);
                return query;
            }

            if (parameters.StatusId != null && parameters.StatusId != Guid.Empty)
            {
                query = query.Where(e => e.StatusId == parameters.StatusId);
            }

            if (!string.IsNullOrWhiteSpace(parameters.SearchTerm))
            {
                var lowerCaseSearchTerm = parameters.SearchTerm.Trim().ToLower();
                query = query.Where(e =>
                    e.Name.ToLower().Contains(lowerCaseSearchTerm) ||
                    e.Number.ToLower().Contains(lowerCaseSearchTerm));
            }

            query = query.OrderByDescending(e => e.DateTime).Take(parameters.Take);

            return query;
        }
    }
}
