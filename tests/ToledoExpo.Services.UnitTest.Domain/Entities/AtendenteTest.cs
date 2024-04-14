using ToledoExpo.Services.Domain.Entities;

namespace ToledoExpo.Services.UnitTestDomain.Entities;

public class AtendenteTest
{

    [Fact]
    public void DeveIntanciarAtendenteVazio()
    {
        var obj = new Atendente();
        
        Assert.Equal(0, obj.Id);
    }

    [Fact]
    public void DeveIniciarAtendimento()
    {
        // arrange
        var obj = new Atendente();

        // act
        obj.IniciarAtendimento("felipe");
        
        // assert
        Assert.NotEqual(0, obj.Id);
        Assert.Equal("felipe", obj.Nome);
    }
}