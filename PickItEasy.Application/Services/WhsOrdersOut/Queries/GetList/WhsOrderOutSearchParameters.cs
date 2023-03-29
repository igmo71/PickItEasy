using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Services.WhsOrdersOut.Queries.GetList
{
    public class WhsOrderOutSearchParameters
    {
        public string? SearchTerm { get; set; }
        public Guid UserId { get; set; }
        public Guid WarehouseId{ get; set; }
        public int Take { get; set; } = 10;
    }
}
