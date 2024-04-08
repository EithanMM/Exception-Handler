namespace Exception.Handler.Extensions
{
    public static class ExceptionsExtension
    {
        public static string ExtractExceptionMessage(this System.Exception exception)
        {
            return exception.InnerException!.Message;
        }
    }
}
