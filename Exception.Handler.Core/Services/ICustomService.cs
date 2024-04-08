using Exception.Handler.Core.Common;
using Exception.Handler.Core.Model;

namespace Exception.Handler.Core.Services;

public interface ICustomService
{
    ResponseResult<ServiceResponse> GenerateNotFoundException();
}
