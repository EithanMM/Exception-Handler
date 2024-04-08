using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Exception.Handler.Extensions;

public static class ValidationExceptionExtensions
{
    public static ValidationProblemDetails ToProblemDetails(this ValidationException exception)
    {
        if (exception is null)
            throw new ArgumentNullException(nameof(exception));

        var problemDetails = new ValidationProblemDetails()
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
            Status = StatusCodes.Status400BadRequest
        };

        foreach ( var validationFailure in exception.Errors )
        {
            if (problemDetails.Errors.ContainsKey(validationFailure.PropertyName))
            {
                problemDetails.Errors[validationFailure.PropertyName] = problemDetails.Errors[validationFailure.PropertyName].Concat([validationFailure.ErrorMessage]).ToArray();
                continue;
            }

            problemDetails.Errors.Add(new KeyValuePair<string, string[]>(validationFailure.PropertyName, [validationFailure.ErrorMessage]));
        }

        return problemDetails;
    }
}
