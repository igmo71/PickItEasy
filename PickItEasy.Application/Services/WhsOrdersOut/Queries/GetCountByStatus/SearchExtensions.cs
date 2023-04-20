using PickItEasy.Application.Common;
using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.Services.WhsOrdersOut.Queries.GetCountByStatus
{
    public static class SearchExtensions
    {
        public static IQueryable<WhsOrderOut> SearchCountByStatus(this IQueryable<WhsOrderOut> query, SearchParameters parameters)
        {
            query = query.Where(e => e.Active);

            if (parameters.Barcode != null)
            {
                var id = BarcodeGuidConvert.FromNumericString(parameters.Barcode);
                query = query.Where(e => e.Id == id || e.WhsOrderOutBaseDocuments.Any(bd => bd.BaseDocumentId == id));
                //return query;
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
