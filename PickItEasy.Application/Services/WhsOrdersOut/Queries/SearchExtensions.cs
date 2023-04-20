using PickItEasy.Application.Common;
using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.Services.WhsOrdersOut.Queries
{
    public static class SearchExtensions
    {
        public static IQueryable<WhsOrderOut> SearchByBarcode(this IQueryable<WhsOrderOut> query, SearchParameters parameters)
        {
            if (parameters.Barcode != null)
            {
                var id = BarcodeGuidConvert.FromNumericString(parameters.Barcode);
                query = query.Where(e => e.Id == id || e.WhsOrderOutBaseDocuments.Any(bd => bd.BaseDocumentId == id));
            }            

            return query;
        }

        public static IQueryable<WhsOrderOut> SearchByTerm(this IQueryable<WhsOrderOut> query, SearchParameters parameters)
        {
            if (!string.IsNullOrWhiteSpace(parameters.SearchTerm))
            {
                query = query.Where(e => e.Name.ToLower().Contains(parameters.SearchTerm.Trim().ToLower()));
            }

            return query;
        }

        public static IQueryable<WhsOrderOut> SearchByStatus(this IQueryable<WhsOrderOut> query, SearchParameters parameters)
        {
            if (parameters.StatusId != null && parameters.StatusId != Guid.Empty)
            {
                query = query.Where(e => e.StatusId == parameters.StatusId);
            }

            return query;
        }
    }
}
