using ToledoExpo.Services.Application.Services;
using ToledoExpo.Services.Domain.Interfaces;
using ToledoExpo.Services.Domain.Interfaces.Services;
using ToledoExpo.Services.Infraestructure.Data.Repositories;

namespace ToledoExpo.Services.API.Configurations.IoC;

public static class RegisterApplicationServices
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        services.AddScoped<IAtendenteService, AtendenteService>();

        return services;
    }
}