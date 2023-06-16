using AE.Common.Exceptions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.Common.Extentions
{
    public static class FluentValidationExtention
    {
        public static async Task ValidateAndThrowExceptionAsync<T>(this IValidator<T> validator, T instance, CancellationToken cancellationToken)
        {
            var validationResult = await validator.ValidateAsync(instance, cancellationToken);
            if (validationResult.IsValid) return;

            var ex = new ValidationException(validationResult.Errors);
            var errors = ex.Errors.Select(e => new Error(e.PropertyName, e.ErrorMessage));
            throw new CustomValidationException($"{validationResult.ToString(", ")}", errors);
        }
    }
    public record Error(string Field, string Message);
}
