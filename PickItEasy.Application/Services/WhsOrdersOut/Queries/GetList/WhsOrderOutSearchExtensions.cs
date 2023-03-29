using PickItEasy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Services.WhsOrdersOut.Queries.GetList
{
    public static class WhsOrderOutSearchExtensions
    {
        public static IQueryable<WhsOrderOut> Search(this IQueryable<WhsOrderOut> query, WhsOrderOutSearchParameters parameters)
        {
            if (!string.IsNullOrWhiteSpace(parameters.SearchTerm))
            {
                var lowerCaseSearchTerm = parameters.SearchTerm.Trim().ToLower();
                query = query.Where(e =>
                    (e.Name.ToLower().Contains(lowerCaseSearchTerm)) ||
                    (e.Number.ToLower().Contains(lowerCaseSearchTerm)));
            }

            query = query.OrderByDescending(e => e.DateTime).Take(parameters.Take);

            return query;
        }
    }
}
