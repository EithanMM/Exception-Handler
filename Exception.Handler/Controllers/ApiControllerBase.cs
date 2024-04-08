using Microsoft.AspNetCore.Mvc;
using Exception.Handler.Extensions;
using FluentValidation;
using Exception.Handler.Core.Exceptions;

namespace Exception.Handler.Controllers
{
    [ApiController]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public class ApiControllerBase : ControllerBase
    {

        protected IActionResult IssueFromException(System.Exception exception, ILogger logger)
        {
            if (exception.InnerException is EntityNotFoundException)
                return Problem(exception.ExtractExceptionMessage(), statusCode: StatusCodes.Status404NotFound);

            if (exception.InnerException is ValidationException ex)
                return BadRequest(ex.ToProblemDetails());

            return UnkownIssue(exception, logger);
        }

        protected IActionResult UnkownIssue(System.Exception exception, ILogger logger)
        {
            var details = BaseException.DefaultErrorMessage;

            if (exception is BaseException ex)
            {
                if (!string.IsNullOrWhiteSpace(ex.Message))
                    details = ex.Message;
            }
            else if (exception is not null)
            {
                logger.LogError(exception.ToString());
            }

            return Problem(details);
        }
    }
}
