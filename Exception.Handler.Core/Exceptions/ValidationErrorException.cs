using FluentValidation.Results;
using System.Runtime.Serialization;

namespace Exception.Handler.Core.Exceptions;

[Serializable]
public class ValidationErrorException : System.Exception
{
    /// <summary>
    /// Validation errors
    /// </summary>
    public IEnumerable<ValidationFailure> Errors { get; private set; }

    /// <summary>
    /// Creates a new validationException
    /// </summary>
    /// <param name="message"></param>
    public ValidationErrorException(string message) : this(message, Enumerable.Empty<ValidationFailure>()) { }


    /// <summary>
    /// Creates a new validationException
    /// </summary>
    /// <param name="message"></param>
    /// <param name="errors"></param>
    public ValidationErrorException(string message, IEnumerable<ValidationFailure> errors) : base(message)
    {
        Errors = errors;
    }


    /// <summary>
    /// Creates a new validationException
    /// </summary>
    /// <param name="message"></param>
    /// <param name="errors"></param>
    /// <param name="appendDefaultMessage"></param>
    public ValidationErrorException(string message, IEnumerable<ValidationFailure> errors, bool appendDefaultMessage)
        : base(appendDefaultMessage ? $"{message} {BuildErrorMessage(errors)}" : message)
    {
        Errors = errors;
    }

    #region Private Methods
    private static string BuildErrorMessage(IEnumerable<ValidationFailure> errors)
    {
        var arr = errors.Select(x => $"{Environment.NewLine} -- {x.PropertyName}: {x.ErrorMessage} Severity: {x.Severity.ToString()}");
        return "Validation failed: " + string.Join(string.Empty, arr);
    }
    #endregion

#if NET8_0_OR_GREATER
    [Obsolete(DiagnosticId = "SYSLIB0051")]
#endif
    public ValidationErrorException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
        Errors = info.GetValue("errors", typeof(IEnumerable<ValidationFailure>)) as IEnumerable<ValidationFailure>;
    }

#if NET8_0_OR_GREATER
    [Obsolete(DiagnosticId = "SYSLIB0051")]
#endif
    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        if (info == null) throw new ArgumentNullException("info");

        info.AddValue("errors", Errors);
        base.GetObjectData(info, context);
    }
}
