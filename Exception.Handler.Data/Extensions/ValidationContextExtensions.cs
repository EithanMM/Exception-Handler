using Ardalis.GuardClauses;
using Exception.Handler.Core.Common;
using FluentValidation;
using FluentValidation.Results;
namespace Exception.Handler.Data.Extensions;

public static class ValidationErrorCodes
{
    public const string NotFound = "NotFound";
}

public static class ValidationContextExtensions
{

    public static void AddNotFoundFailure<T>(this ValidationContext<T> validationContext)
    {
        AddNotFoundFailure(validationContext, "Entity with {PropertyName} of {PropertyValue} was not found");
    }

    public static void AddNotFoundFailure<T>(this ValidationContext<T> validationContext, string errorMessage)
    {
        AddNotFoundFailure(validationContext, errorMessage);
    }

    public static void AddNotFoundFailure<T>(this ValidationContext<T> validationContext, string propertyName, string errorMessage)
    {
        var validationFailure = new NotFoundValidationFailure();
        AddNotFoundFailure(validationContext, errorMessage);
    }
}

public sealed class NotFoundValidationFailure : ValidationFailure
{
    public NotFoundValidationFailure() { ErrorCode = ValidationErrorCodes.NotFound; }

    public NotFoundValidationFailure(string propertyName, string errorMessage) : base(propertyName, errorMessage) { ErrorCode = ValidationErrorCodes.NotFound; }

    public NotFoundValidationFailure(string propertyName, string errorMessage, object attemptedValue) : base(propertyName, errorMessage, attemptedValue) { ErrorCode = ValidationErrorCodes.NotFound; }
}

public static class ValidationResponseResultExtensions
{
    /*
     * Override method that will allow us to return the validation exceptions created
     * via FluentValidations
     */
    public static ResponseResult<T> ToResult<T>(this ValidationResult validationResult)
    {
        Guard.Against.Null(validationResult);
        var exception = new ValidationException(validationResult.Errors);
        return new ResponseResult<T>(exception);
    }
}