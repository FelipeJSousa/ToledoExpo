using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace ToledoExpo.Services.API.Configurations;

public static class WebApplicationExtensions
{
    public static async Task<WebApplication> UseWebApplication(this WebApplication app, IConfiguration configuration)
    {
        var env = app.Environment;
        
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors("Padrao");

        app.MapControllers();
        
        app.UseHttpsRedirection();
        
        return app;
    }
}