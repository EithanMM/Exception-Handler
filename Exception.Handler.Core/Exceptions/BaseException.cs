namespace Exception.Handler.Core.Exceptions;

// System.Exception is used because Exception alone is not bein recognized
public class BaseException : System.Exception
{
    public const string DefaultErrorMessage = "An unkown issue occurred. Please contact customer support";

    public BaseException() : this(DefaultErrorMessage) {}

    public BaseException(string errorMessage) : base(errorMessage) { }

    public BaseException(string errorMessage, System.Exception inner) : base(errorMessage, inner) { }
}
