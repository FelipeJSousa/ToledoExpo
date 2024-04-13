

using Microsoft.EntityFrameworkCore;
using ToledoExpo.Services.API.Configurations.IoC;
using ToledoExpo.Services.Domain.Interfaces;
using ToledoExpo.Services.Infraestructure.Data.Contexts;
using ToledoExpo.Services.Infraestructure.Data.Repositories;

namespace ToledoExpo.Services.API.Configurations;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        
        services.AddCors(options =>
        {
            options.AddPolicy("Padrao",
                builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
            );
        });
        
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddDbContext<ToledoExpoContext>(options =>
        {
            options.UseMySQL(configuration.GetConnectionString("DefaultConnection"));
        });

        services.RegisterServices();
        
        return services;
    }
}