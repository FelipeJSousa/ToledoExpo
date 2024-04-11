using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToledoExpo.Services.Domain.Entities;

namespace ToledoExpo.Services.Infraestructure.Data.Map;

public class EstabelecimentoMap : EntityMap<Estabelecimento>
{
    public override void Configure(EntityTypeBuilder<Estabelecimento> builder)
    {
        base.Configure(builder);
        
        builder.ToTable("estabelecimento");
        
        builder.Property(x => x.Nome).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Descricao).HasMaxLength(500).IsRequired();
        builder.Property(x => x.Proprietario).HasMaxLength(100).IsRequired();
        builder.Property(x => x.DataCricao).IsRequired();
        builder.Property(x => x.Ativo).IsRequired();

        builder.Property(x => x.Ativo).HasConversion(new BoolToStringConverter("N", "S"));

        builder.HasData(new List<Estabelecimento>()
        {
            new Estabelecimento(
                1,
                "Estabelecimento 1",
                "Descrição de teste.",
                "Felipe Sousa"
            )
        });
    }
}