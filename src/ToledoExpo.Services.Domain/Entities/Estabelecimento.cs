namespace ToledoExpo.Services.Domain.Entities;

public class Estabelecimento : Entity
{
    public string Nome { get; set; }

    public string Descricao { get; set; }

    public DateTime DataCricao { get; set; }

    public string Proprietario { get; set; }

    public bool Ativo { get; set; }

    public Estabelecimento() { }

    public Estabelecimento(long id, string nome, string descricao, string proprietario)
    {
        Id = id;
        Nome = nome;
        Descricao = descricao;
        Proprietario = proprietario;
        DataCricao = DateTime.Now;
        Ativo = true;
    }
}