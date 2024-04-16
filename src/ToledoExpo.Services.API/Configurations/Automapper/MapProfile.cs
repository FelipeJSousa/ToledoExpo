using AutoMapper;
using AutoMapper.Internal;
using ToledoExpo.Services.API.ViewModels.Request;
using ToledoExpo.Services.API.ViewModels.Response;
using ToledoExpo.Services.Core.Extensions;
using ToledoExpo.Services.Domain.Entities;

namespace ToledoExpo.Services.API.Configurations.Automapper;

public class MapProfile : Profile
{
    public MapProfile() : base("MapProfile")
    {
        AllowNullCollections = true;
        ((IProfileExpressionInternal) this).ForAllMaps((_, cnfg) =>
            cnfg.ForAllMembers(opts => opts.IgnoreSourceWhenDefault()));
        CreateMap();
    }

    private void CreateMap()
    {
        RequestMaps();
        ResponseMaps();
    }
    
    private void RequestMaps()
    {
        CreateMap<ApiRequestNovoAtendente, Atendente>().ReverseMap();
        CreateMap<ApiRequestAtualizarAtendente, Atendente>().ReverseMap();
        CreateMap<ApiRequestClienteAtendimento, Cliente>().ReverseMap();
        CreateMap<ApiRequestNovoAtendimento, Atendimento>().ReverseMap();
    }
    
    private void ResponseMaps()
    {
        CreateMap<ApiResponseAtendente, Atendente>().ReverseMap();
        CreateMap<ApiResponseAtendimento, Atendimento>().ReverseMap();
        CreateMap<ApiResponseCliente, Cliente>().ReverseMap();
        CreateMap<ApiResponseEstabelecimento, Estabelecimento>().ReverseMap();
    }
}