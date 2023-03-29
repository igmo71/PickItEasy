﻿using MediatR;

namespace PickItEasy.Application.Services.Products.Queries.IsExistsById
{
    public class IsExistsByIdProductQuery : IRequest<bool>
    {
        public required Guid Id { get; set; }
    }
}
