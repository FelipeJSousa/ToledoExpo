
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToledoExpo.Services.Domain.Entities;

namespace ToledoExpo.Services.Infraestructure.Data.Map;

public class ClienteMap : EntityMap<Cliente>
{
    public override void Configure(EntityTypeBuilder<Cliente> builder)
    {
        base.Configure(builder);

        builder.ToTable("cliente");

        builder.Property(x => x.Nome).HasMaxLength(100).IsRequired();
        builder.Property(x => x.VelocidadeMovimento).HasColumnName("velocidade_movimento");
        builder.Property(x => x.CapacidadeCognitiva).HasColumnName("capacidade_cognitiva");


    }
}
