using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Moq;
using ToledoExpo.Services.API.Controllers;
using ToledoExpo.Services.API.ViewModels.Request;
using ToledoExpo.Services.API.ViewModels.Response;
using ToledoExpo.Services.Domain.Entities;
using ToledoExpo.Services.Domain.Interfaces.Services;

public class AtendimentoControllerTests
{
    private readonly Mock<IServiceProvider> _MockServiceProvider = new ();
    private readonly Mock<IAtendimentoService> _MockAtendimentoService = new ();
    private readonly Mock<IClienteService> _MockClienteService = new ();
    
    [Fact]
    public async Task NovoCliente_DeveRetornarOkQuandoAdicionadoNaFila()
    {
        // Arrange
        var controller = new AtendimentoController(_MockServiceProvider.Object, _MockAtendimentoService.Object, _MockClienteService.Object);

        var request = new ApiRequestNovoAtendimento();
        var cliente = new Cliente();
        var atendimento = new Atendimento();
        var response = new ApiResponseAtendimento();

        _MockClienteService.Setup(x => x.Save(It.IsAny<Cliente>(), It.IsAny<bool>())).ReturnsAsync(cliente);
        _MockAtendimentoService.Setup(x => x.AdicionarNafila(cliente, It.IsAny<int>())).ReturnsAsync(atendimento);

        // Act
        var result = await controller.NovoCliente(request);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var model = Assert.IsAssignableFrom<ApiResponseAtendimento>(okResult.Value);
        Assert.Equal(response, model);
    }

    [Fact]
    public async Task ObterTodos_DeveRetornarOkComListaDeAtendimentos()
    {
        // Arrange
        var controller = new AtendimentoController(_MockServiceProvider.Object, _MockAtendimentoService.Object, _MockClienteService.Object);

        var atendimentos = new List<Atendimento>();
        var response = new List<ApiResponseAtendimento>();

        _MockAtendimentoService.Setup(x => x.GetList(It.IsAny<Expression<Func<Atendimento, bool>>>(), null, null)).ReturnsAsync(atendimentos);

        // Act
        var result = await controller.ObterTodos();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var model = Assert.IsAssignableFrom<List<ApiResponseAtendimento>>(okResult.Value);
        Assert.Equal(response, model);
    }

    [Fact]
    public async Task AtendimentoPendente_DeveRetornarOkComListaDeAtendimentosPendentes()
    {
        // Arrange
        var controller = new AtendimentoController(_MockServiceProvider.Object, _MockAtendimentoService.Object, _MockClienteService.Object);

        var atendimentos = new List<Atendimento>();
        var response = new List<ApiResponseAtendimento>();

        _MockAtendimentoService.Setup(x => x.ObterPendentes()).ReturnsAsync(atendimentos);

        // Act
        var result = await controller.AtendimentoPendente();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var model = Assert.IsAssignableFrom<List<ApiResponseAtendimento>>(okResult.Value);
        Assert.Equal(response, model);
    }

    [Fact]
    public async Task EmAtendimento_DeveRetornarOkComListaDeAtendimentosEmAndamento()
    {
        // Arrange
        var controller = new AtendimentoController(_MockServiceProvider.Object, _MockAtendimentoService.Object, _MockClienteService.Object);

        var atendimentos = new List<Atendimento>();
        var response = new List<ApiResponseAtendimento>();

        _MockAtendimentoService.Setup(x => x.GetList(It.IsAny<Expression<Func<Atendimento, bool>>>(), null, null)).ReturnsAsync(atendimentos);

        // Act
        var result = await controller.EmAtendimento();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var model = Assert.IsAssignableFrom<List<ApiResponseAtendimento>>(okResult.Value);
        Assert.Equal(response, model);
    }

    [Fact]
    public async Task Finalizados_DeveRetornarOkComListaDeAtendimentosFinalizados()
    {
        // Arrange
        var controller = new AtendimentoController(_MockServiceProvider.Object, _MockAtendimentoService.Object, _MockClienteService.Object);

        var atendimentos = new List<Atendimento>();
        var response = new List<ApiResponseAtendimento>();

        _MockAtendimentoService.Setup(x => x.GetList(It.IsAny<Expression<Func<Atendimento, bool>>>(), null, null)).ReturnsAsync(atendimentos);

        // Act
        var result = await controller.Finalizados();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var model = Assert.IsAssignableFrom<List<ApiResponseAtendimento>>(okResult.Value);
        Assert.Equal(response, model);
    }
}