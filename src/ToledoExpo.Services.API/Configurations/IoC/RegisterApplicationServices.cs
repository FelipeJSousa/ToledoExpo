using ToledoExpo.Services.Application.Services;
using ToledoExpo.Services.Domain.Interfaces.Services;

namespace ToledoExpo.Services.API.Configurations.IoC;

public static class RegisterApplicationServices
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IAtendenteService, AtendenteService>();
        
        return services;
    }
}