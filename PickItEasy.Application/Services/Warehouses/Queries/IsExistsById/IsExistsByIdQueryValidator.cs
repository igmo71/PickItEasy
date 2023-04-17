﻿using FluentValidation;

namespace PickItEasy.Application.Services.Warehouses.Queries.IsExistsById
{
    public class IsExistsByIdQueryValidator : AbstractValidator<IsExistsByIdQuery>
    {
        public IsExistsByIdQueryValidator()
        {
            RuleFor(isExistsByIdQuery => isExistsByIdQuery.Id).NotNull().NotEmpty();
        }
    }
}
