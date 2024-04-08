namespace Exception.Handler.Core.Exceptions;

public class EntityNotFoundException : BaseException
{
    public EntityNotFoundException() : this("The requested entity was not found") { }

    public EntityNotFoundException(string message) : base(message) { }

    public EntityNotFoundException(string message, System.Exception inner) : base(message, inner) { }
}
