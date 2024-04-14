using Microsoft.AspNetCore.Mvc;

namespace ToledoExpo.Services.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AtendenteController : ApiBaseController
{
    public AtendenteController()
    {
        
    }
    
    /// <summary>
    ///     Criar novo atendente.
    /// </summary>
    /// <returns></returns>
    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpPost]
    public IActionResult NovoAtendente()
    {
        return Ok();
    }
}