using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LS.Document.Business.Validations
{
    public class ValidationPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IValidator<TRequest>[] _validators;

        public ValidationPipeline(IValidator<TRequest>[] validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, System.Threading.CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var validationContext = new ValidationContext(request);
            if (_validators == null || !_validators.Any())
            {
                Trace.WriteLine($"Unable to find validator for {request.GetType().FullName}");
            }
            else
            {
                var errorMessages = _validators.Select(validator => validator.Validate(validationContext))
                    .Where(w => w != null)
                    .SelectMany(s => s.Errors)
                    .ToList();

                if (errorMessages.Any())
                    throw new ValidationException(errorMessages);
            }

            return await next().ConfigureAwait(false);
        }
    }
}
