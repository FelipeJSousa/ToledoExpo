using ToledoExpo.Services.Domain.Entities;
using Xunit;

namespace ToledoExpo.Services.UnitTest.Domain.Entities;

public class ClienteTests
{

    [Fact(DisplayName = "Deve instanciar um cliente vazio")]
    public void DeveInstanciarClienteVazio()
    {
        var obj = new Cliente();

        Assert.Equal(0, obj.Id);
        Assert.Null(obj.Nome);
    }

    [Fact(DisplayName = "Deve instanciar um cliente valido")]
    public void DeveInstanciarClienteValido()
    {
        var nome = "Gabriel Lanza";
        var capacidadeCognitiva = 2.50;
        var velocidadeMotora = 5;
         
        var obj = new Cliente(nome, velocidadeMotora, capacidadeCognitiva);

        Assert.NotNull(obj);
        Assert.Equal(nome, obj.Nome);
        Assert.Equal(capacidadeCognitiva, obj.CapacidadeCognitiva);
        Assert.Equal(velocidadeMotora, obj.VelocidadeMovimento);
    }

}