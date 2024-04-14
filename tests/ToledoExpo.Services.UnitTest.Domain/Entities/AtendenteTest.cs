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

}