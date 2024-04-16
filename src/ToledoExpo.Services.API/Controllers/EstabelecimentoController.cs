using Microsoft.AspNetCore.Mvc;
using ToledoExpo.Services.Domain.Interfaces.Services;

namespace ToledoExpo.Services.API.Controllers;

[ApiController]
[Route("[controller]")]
public class EstabelecimentoController : ApiBaseController
{
    private readonly IEstabelecimentoService _EstabelecimentoService;
    
    public EstabelecimentoController(ServiceProvider serviceProvider, IEstabelecimentoService estabelecimentoService) : base(serviceProvider)
    {
        _EstabelecimentoService = estabelecimentoService;
    }
    
    /// <summary>
    ///     Obter estabelecimentos.
    /// </summary>
    /// <returns></returns>
    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpPost]
    public async Task<IActionResult> ObterEstabelecimento()
    {
        return Response(await _EstabelecimentoService.GetList());
    }
}