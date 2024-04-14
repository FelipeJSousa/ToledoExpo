using ToledoExpo.Services.Application.Services;
using ToledoExpo.Services.Core.Interfaces.Repositories;
using ToledoExpo.Services.Domain.Interfaces.Services;
using ToledoExpo.Services.Infraestructure.Data.Repositories;

namespace ToledoExpo.Services.API.Configurations.IoC;

public static class RegisterApplicationServices
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        services.AddScoped<IAtendenteService, AtendenteService>();
        services.AddScoped<IEstabelecimentoService, EstabelecimentoService>();

        return services;
    }
}