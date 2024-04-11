using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToledoExpo.Services.Domain.Entities;

namespace ToledoExpo.Services.Infraestructure.Data.Map;

public class AtendenteMap : EntityMap<Atendente>
{
    public override void Configure(EntityTypeBuilder<Atendente> builder)
    {
        base.Configure(builder);
        
        builder.ToTable("atendente");
        
        builder.Property(x => x.Estabelecimento).HasColumnName("estabelecimentoId").HasMaxLength(100).IsRequired();
        
        builder.HasOne(x => x.EstabelecimentoObj).WithMany().HasForeignKey(x => x.Estabelecimento).IsRequired();

    }
}