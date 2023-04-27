using PickItEasy.Application.Common;
using PickItEasy.Domain.Entities.WhsOrder.Out;

namespace PickItEasy.Application.Services.WhsOrder.Out.Search
{
    public static class SearchExtensions
    {
        public static IQueryable<WhsOrderOut> SearchByTerm(this IQueryable<WhsOrderOut> query, SearchParameters parameters)
        {
            if (parameters.IsBarcode && !string.IsNullOrEmpty(parameters.SearchBarcode))
            {
                var id = BarcodeGuidConvert.FromNumericString(parameters.SearchBarcode);
                query = query.Where(e => e.Id == id || e.WhsOrderOutBaseDocuments.Any(bd => bd.BaseDocumentId == id));
            }

            if (parameters.IsTerm && !string.IsNullOrWhiteSpace(parameters.SearchTerm))
            {
                {
                    query = query.Where(e => e.Name.ToLower().Contains(parameters.SearchTerm.Trim().ToLower()));
                }
            }

            return query;
        }

        public static IQueryable<WhsOrderOut> SearchByStatus(this IQueryable<WhsOrderOut> query, SearchParameters parameters)
        {
            if (parameters.IsStatus && parameters.StatusId != null && parameters.StatusId != Guid.Empty)
            {
                query = query.Where(e => e.StatusId == parameters.StatusId);
            }

            return query;
        }
    }
}
