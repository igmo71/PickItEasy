using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Services.Products.Queries.IsExistsById
{
    public class IsExistsByIdProductQuery : IRequest<bool>
    {
        public required Guid Id { get; set; }
    }
}
