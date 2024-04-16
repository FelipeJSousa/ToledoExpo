using Microsoft.AspNetCore.Mvc;
using ToledoExpo.Services.API.ViewModels.Request;
using ToledoExpo.Services.API.ViewModels.Response;
using ToledoExpo.Services.Domain.Entities;
using ToledoExpo.Services.Domain.Interfaces.Services;

namespace ToledoExpo.Services.API.Controllers;

public class AtendimentoController : ApiBaseController
{
    private readonly IAtendimentoService _AtendimentoService;
    private readonly IClienteService _ClienteService;
    
    public AtendimentoController(IServiceProvider serviceProvider, IAtendimentoService atendimentoService, IClienteService clienteService) : base(serviceProvider)
    {
        _AtendimentoService = atendimentoService;
        _ClienteService = clienteService;
    }

    /// <summary>
    ///     Criar novo atendimento.
    /// </summary>
    /// <returns></returns>
    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpPost]
    public async Task<IActionResult> NovoCliente(ApiRequestNovoAtendimento request)
    {
        var _objCliente = await _ClienteService.Save(Mapear<Cliente>(request));

        var _ret = await _AtendimentoService.AdicionarNafila(_objCliente, request?.atendenteId ?? 0);

        return Response(Mapear<ApiResponseAtendimento>(_ret));
    }

    /// <summary>
    ///     Obter todos atendimentos.
    /// </summary>
    /// <returns></returns>
    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpGet]
    public async Task<IActionResult> ObterTodos()
    {
        var _ret = await _AtendimentoService.GetList();

        return Response(Mapear<List<ApiResponseAtendimento>>(_ret));
    }
    
    /// <summary>
    ///     Obter atendimentos por situação pendente.
    /// </summary>
    /// <returns></returns>
    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpGet("pendentes")]
    public async Task<IActionResult> AtendimentoPendente()
    {
        var _ret = await _AtendimentoService.ObterPendentes();

        return Response(Mapear<List<ApiResponseAtendimento>>(_ret));
    }
    
    /// <summary>
    ///     Obter atendimentos por situação em atendimento.
    /// </summary>
    /// <returns></returns>
    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpGet("atendendo")]
    public async Task<IActionResult> EmAtendimento()
    {
        var _ret = await _AtendimentoService.GetList(x => x.DataInicioAtendimento < DateTime.Now && x.DataFimAtendimento > DateTime.Now);

        return Response(Mapear<List<ApiResponseAtendimento>>(_ret));
    }
    
    /// <summary>
    ///     Obter atendimentos por situação finalizado.
    /// </summary>
    /// <returns></returns>
    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpGet("finalizado")]
    public async Task<IActionResult> Finalizados()
    {
        var _ret = await _AtendimentoService.GetList(x => x.DataFimAtendimento < DateTime.Now);

        return Response(Mapear<List<ApiResponseAtendimento>>(_ret));
    }
}