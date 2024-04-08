using Exception.Handler.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Exception.Handler.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ExceptionController(ICustomService customService, ILogger<ExceptionController> logger) : ApiControllerBase
    {
        [HttpGet]
        public IActionResult GetNotFoundException()
        {
            var result = customService.GenerateNotFoundException();

            if (result.isError)
                return IssueFromException(result.Exception!, logger);

            return Ok(result.Value);
        }
    }
}
