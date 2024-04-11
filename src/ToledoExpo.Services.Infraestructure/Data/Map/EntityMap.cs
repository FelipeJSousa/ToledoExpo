using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToledoExpo.Services.Domain.Entities;

namespace ToledoExpo.Services.Infraestructure.Data.Map;

public class EntityMap<T> : IEntityTypeConfiguration<T> where T : Entity
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        
        builder.Property(x => x.Ativo).IsRequired();

        builder.Property(x => x.Ativo).HasConversion(new BoolToStringConverter("N", "S"));
    }
}