using ToledoExpo.Services.Domain.Entities;

namespace ToledoExpo.Services.API.ViewModels.Response;

public class ApiResponseAtendimento
{
    public long Id { get; set; }
    
    public DateTime DataChegada { get; set; }
    
    public DateTime DataInicioAtendimento { get; set; }
    
    public DateTime DataFimAtendimento { get; set; }
    
    public AtendimentoSituacao Situacao { get; set; }
    
    public ApiResponseCliente ClienteObj { get; set; }
    
    public ApiResponseAtendente AtendenteObj { get; set; }
    
}