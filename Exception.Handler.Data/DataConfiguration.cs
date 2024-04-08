using Exception.Handler.Core.Services;
using Exception.Handler.Data.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Exception.Handler.Data;

public static class DataConfiguration
{
    public static void Register(this IServiceCollection services)
    {
        services.AddTransient<ICustomService, CustomService>();
    }
}
