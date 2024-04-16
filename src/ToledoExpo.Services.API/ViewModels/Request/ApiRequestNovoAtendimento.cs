namespace ToledoExpo.Services.API.ViewModels.Request;

public class ApiRequestNovoAtendimento
{
    public long? atendenteId { get; set; }
    
    public ApiRequestClienteAtendimento Cliente { get; set; }
}