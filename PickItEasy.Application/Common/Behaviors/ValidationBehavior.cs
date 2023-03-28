using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace PickItEasy.Application.Common.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse> where TRequest : IBaseRequest
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var validationContext = new ValidationContext<TRequest>(request);
            var failures = _validators.Select(v => v.Validate(validationContext))
                .SelectMany(result => result.Errors)
                .Where(failure => failure != null)
                .ToList();
            if(failures.Any())
            {
                throw new ValidationException(failures);
            }
            return next();
        }
    }
}
