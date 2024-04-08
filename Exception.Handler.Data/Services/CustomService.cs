using Exception.Handler.Core.Common;
using Exception.Handler.Core.Exceptions;
using Exception.Handler.Core.Model;
using Exception.Handler.Core.Services;

namespace Exception.Handler.Data.Services;

public class CustomService : ICustomService
{
    public ResponseResult<ServiceResponse> GenerateNotFoundException()
    {
        return new(new EntityNotFoundException());
    }
}
