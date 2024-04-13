
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToledoExpo.Services.Domain.Entities;

namespace ToledoExpo.Services.Infraestructure.Data.Map;
public class AtendimentoMap : EntityMap<Atendimento>
{
    public override void Configure(EntityTypeBuilder<Atendimento> builder)
    {
        base.Configure(builder);

        builder.ToTable("atendimento");

        builder.Property(x => x.DataChegada).HasColumnName("data_chegada");
        builder.Property(x => x.DataInicioAtendimento).HasColumnName("data_inicio_atendimento");
        builder.Property(x => x.DataFimAtendimento).HasColumnName("data_fim_atendimento");

        builder.HasOne(x => x.ClienteObj).WithOne().HasForeignKey<Cliente>(x => x.Id).IsRequired();
        builder.HasOne(x => x.AtendenteObj).WithOne().HasForeignKey<Atendente>(x => x.Id).IsRequired();

    }
}