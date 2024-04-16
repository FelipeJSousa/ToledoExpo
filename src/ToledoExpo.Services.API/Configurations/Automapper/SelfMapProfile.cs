using AutoMapper;
using AutoMapper.Internal;
using ToledoExpo.Services.Core.Extensions;
using ToledoExpo.Services.Domain.Entities;

namespace ToledoExpo.Services.API.Configurations.Automapper;

public class SelfMapProfile : Profile
{
    public SelfMapProfile() : base("SelfMapProfile")
    {
        AllowNullCollections = true;

        ((IProfileExpressionInternal) this).ForAllMaps((_, cnfg) =>
            cnfg.ForAllMembers(opts => opts.IgnoreSourceAndDefault()));
        ((IProfileExpressionInternal) this).ForAllMaps((_, e) =>
            e.AfterMap(MemberConfigurationExpressionExtensions.SetNullFromNullableDefault));

        CreateMap<Atendente, Atendente>();
    }
}