namespace ToledoExpo.Services.Domain.Entities;

public class Atendente : Entity
{
    public string Nome { get; set; }
    
    public long Estabelecimento { get; set; }
    
    public Estabelecimento EstabelecimentoObj { get; set; }

    public double TempoAtendimentoMinimo { get; set; }
}