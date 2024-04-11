using ToledoExpo.Services.Application.Services;
using ToledoExpo.Services.Domain.Interfaces.Services;

namespace ToledoExpo.Services.API.Configurations.IoC;

public static class RegisterServices
{
    public static IServiceCollection Register(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IAtendenteService, AtendenteService>();
        
        return services;
    }
}