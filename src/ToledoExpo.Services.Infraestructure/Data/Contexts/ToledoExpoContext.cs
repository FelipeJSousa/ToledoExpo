using Microsoft.EntityFrameworkCore;
using ToledoExpo.Services.Core.Entities;
using ToledoExpo.Services.Domain.Entities;

namespace ToledoExpo.Services.Infraestructure.Data.Contexts;

public class ToledoExpoContext : DbContext
{
    public ToledoExpoContext(DbContextOptions<DbContext> dbcontext) : base(dbcontext)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ToledoExpoContext).Assembly);
        modelBuilder.Ignore<Entity>();
            
        base.OnModelCreating(modelBuilder);
    }

    
}