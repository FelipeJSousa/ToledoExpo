using Microsoft.EntityFrameworkCore;
using ToledoExpo.Services.Domain.Entities;

namespace ToledoExpo.Services.Infraestructure.Data.Contexts;

public class ToledoExpoContext : DbContext
{
    public ToledoExpoContext()
    {
        
    }

    public ToledoExpoContext(DbContextOptions<ToledoExpoContext> options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ToledoExpoContext).Assembly);

        modelBuilder.Ignore<Entity>();

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySQL("Server=localhost;Port=3306;Database=bd_toledo;Uid=root;Pwd=061074;");
        }
    }

}