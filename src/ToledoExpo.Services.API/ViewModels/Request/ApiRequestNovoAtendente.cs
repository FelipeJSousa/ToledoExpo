namespace ToledoExpo.Services.API.ViewModels.Request;

public class ApiRequestNovoAtendente
{
    public string Nome { get; set; }

    public long Estabelecimento { get; set; }

}

public class ApiRequestAtualizarAtendente
{
    public long Id { get; set; }
    
    public string Nome { get; set; }
    
    public long Estabelecimento { get; set; }

}