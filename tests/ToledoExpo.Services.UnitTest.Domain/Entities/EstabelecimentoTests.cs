using System;
using ToledoExpo.Services.Domain.Entities;
using Xunit;

namespace ToledoExpo.Services.UnitTest.Domain.Entities;

public class EstabelecimentoTests
{
    [Fact(DisplayName = "Deve instanciar um estabelecimento vazio")]
    public void DeveInstanciarEstabelecimentoVazio()
    {
        var obj = new Estabelecimento();
        
        Assert.Equal(0, obj.Id);
        Assert.Null(obj.Nome);
    }
    
    [Fact(DisplayName = "Deve instanciar um estabelecimento valido")]
    public void DeveInstanciarEstabelecimentoValido()
    {
        var obj = new Estabelecimento(1, "Estabelecimento 1", "Descrição do estabelecimento 1", "Felipe Sousa");
        
        Assert.NotNull(obj);
        Assert.Equal(1, obj.Id);
        Assert.Equal("Estabelecimento 1", obj.Nome);
        Assert.Equal("Descrição do estabelecimento 1", obj.Descricao);
        Assert.Equal("Felipe Sousa", obj.Proprietario);
        Assert.True(obj.DataCricao < DateTime.Now);
        Assert.True(obj.Ativo);
        
    }
}