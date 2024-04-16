using ToledoExpo.Services.Core.Entities;

namespace ToledoExpo.Services.Domain.Entities;

public class Atendente : Entity
{
    public string Nome { get; set; }

    public long Estabelecimento { get; set; }

    public Estabelecimento EstabelecimentoObj { get; set; }

    public double TempoAtendimentoMinimo { get; set; }

    #region Regras de Negócios

    public Atendente Novo()
    {
        TempoAtendimentoMinimo = 5;
        Ativo = true;

        return this;
    }

    #endregion
}