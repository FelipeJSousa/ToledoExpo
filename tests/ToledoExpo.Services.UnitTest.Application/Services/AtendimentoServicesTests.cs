using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using Moq;
using ToledoExpo.Services.Application.Services;
using ToledoExpo.Services.Core.Interfaces.Repositories;
using ToledoExpo.Services.Domain.Entities;
using ToledoExpo.Services.Domain.Interfaces.Services;
using Xunit;

namespace ToledoExpo.Services.UnitTest.Application.Services;

public class AtendimentoServicesTests
{
    private readonly Mock<IServiceProvider> _MockServiceProvider = new ();
    private readonly Mock<IRepository<Atendimento>> _MockRepositoryProvider = new ();
    private readonly Expression<Func<Atendimento, bool>> anyExpression = It.IsAny<Expression<Func<Atendimento, bool>>>();
    private readonly Func<IQueryable<Atendimento>, IIncludableQueryable<Atendimento, object>> anyInclude = It.IsAny<Func<IQueryable<Atendimento>, IIncludableQueryable<Atendimento, object>>>();
    private readonly Func<IQueryable<Atendimento>, IOrderedQueryable<Atendimento>> anyOrder = It.IsAny<Func<IQueryable<Atendimento>, IOrderedQueryable<Atendimento>>>();

    [Fact]
    public async Task ObterFilaVazia_DeveRetornarAtendentesQuandoListaDeAtendimentosVazia()
    {
        // Arrange
        var mockAtendimentoService = new Mock<IAtendimentoService>();
        var mockAtendenteService = new Mock<IAtendenteService>();
        var atendimentoService = new AtendimentoService(_MockServiceProvider.Object, _MockRepositoryProvider.Object, mockAtendenteService.Object);

        mockAtendimentoService.Setup(s => s.GetList(null, null, null)).ReturnsAsync(new List<Atendimento>());
        mockAtendenteService.Setup(s => s.GetList(null, null, null)).ReturnsAsync(new List<Atendente> { new Atendente { Id = 1, Nome = "Atendente 1" } });

        // Act
        var result = await atendimentoService.ObterFilaVazia();

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal("Atendente 1", result.First().Nome);
    }

    [Fact]
    public async Task ObterFilaVazia_DeveRetornarAtendentesSemAtendimentosEmAndamento()
    {
        // Arrange
        var mockAtendimentoService = new Mock<IAtendimentoService>();
        var mockAtendenteService = new Mock<IAtendenteService>();
        var atendimentoService = new AtendimentoService(_MockServiceProvider.Object, _MockRepositoryProvider.Object, mockAtendenteService.Object);

        var atendente1 = new Atendente { Id = 1, Nome = "Atendente 1" };
        var atendente2 = new Atendente { Id = 2, Nome = "Atendente 2" };
        var atendente3 = new Atendente { Id = 3, Nome = "Atendente 3" };

        var atendimentos = new List<Atendimento>
        {
            new Atendimento { Id = 1, AtendenteObj = atendente1, DataFimAtendimento = DateTime.Now.AddMinutes(-10) },
            new Atendimento { Id = 2, AtendenteObj = atendente1, DataInicioAtendimento = DateTime.Now.AddMinutes(-5), DataFimAtendimento = DateTime.Now.AddMinutes(5) },
            new Atendimento { Id = 3, AtendenteObj = atendente2, DataFimAtendimento = DateTime.Now.AddMinutes(-15) },
            new Atendimento { Id = 4, AtendenteObj = atendente3, DataFimAtendimento = DateTime.Now.AddMinutes(-20) }
        };

        mockAtendimentoService.Setup(s => s.GetList(anyExpression, anyInclude, anyOrder)).ReturnsAsync(atendimentos);
        _MockRepositoryProvider.Setup(s => s.GetAll(anyExpression, anyInclude, anyOrder)).ReturnsAsync(atendimentos);
        mockAtendenteService.Setup(s => s.GetList(null, null, null)).ReturnsAsync(new List<Atendente> { atendente1, atendente2, atendente3 });

        // Act
        var result = await atendimentoService.ObterFilaVazia();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
        Assert.Contains(atendente2, result);
        Assert.Contains(atendente3, result);
    }
}