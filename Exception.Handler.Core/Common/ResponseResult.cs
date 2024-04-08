using Ardalis.GuardClauses;

namespace Exception.Handler.Core.Common;

public enum ResponseStatus : byte
{
    Error,
    Success
}

public readonly struct ResponseResult<TValue>
{
    internal readonly ResponseStatus Status;
    public readonly TValue? Value { get; }
    public readonly System.Exception? Exception { get; }


    public bool isError => Status == ResponseStatus.Error;
    public bool isSuccess => Status == ResponseStatus.Success;

    #region Constructors
    public ResponseResult(TValue? value)
    {
        Guard.Against.Null(value, nameof(value));

        Status = ResponseStatus.Success;
        Value = value;
        Exception = null;
    }

    public ResponseResult(System.Exception exception)
    {
        Status = ResponseStatus.Error;
        Value = default;
        Exception = new AggregateException(exception);
    }

    public ResponseResult(ICollection<System.Exception> exceptions)
    {
        Status = ResponseStatus.Error;
        Value = default;
        Exception = new AggregateException(exceptions);
    }
    #endregion

    public R Match<R>(Func<TValue, R> onSuccess, Func<System.Exception, R> onFail) =>
        isError ? onFail(Exception!) : onSuccess(Value!);
}
