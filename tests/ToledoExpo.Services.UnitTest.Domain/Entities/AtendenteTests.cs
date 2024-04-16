using ToledoExpo.Services.Domain.Entities;
using Xunit;

namespace ToledoExpo.Services.UnitTest.Domain.Entities;

public class AtendenteTests
{

    [Fact]
    public void DeveIntanciarAtendenteVazio()
    {
        var obj = new Atendente();
        
        Assert.Equal(0, obj.Id);
    }

}