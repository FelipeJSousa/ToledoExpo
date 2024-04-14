using System;
using ToledoExpo.Services.Core.Interfaces.Repositories;
using ToledoExpo.Services.Core.Services;
using ToledoExpo.Services.Domain.Entities;
using ToledoExpo.Services.Domain.Interfaces.Services;

namespace ToledoExpo.Services.Application.Services;

public class EstabelecimentoService : ServiceBase<Estabelecimento>, IEstabelecimentoService
{
    public EstabelecimentoService(IServiceProvider serviceProvider, IRepository<Estabelecimento> repoBase) : base(serviceProvider, repoBase)
    {
    }
}