using Microsoft.AspNetCore.Mvc;
using ToledoExpo.Services.Domain.Interfaces.Services;

namespace ToledoExpo.Services.API.Controllers;

[ApiController]
[Route("[controller]")]
public class EstabelecimentoController : ApiBaseController
{
    private readonly IEstabelecimentoService _EstabelecimentoService;
    
    public EstabelecimentoController(IEstabelecimentoService estabelecimentoService)
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
    public IActionResult ObterEstabelecimento()
    {
        return Response(_EstabelecimentoService.GetList());
    }
}