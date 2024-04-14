using System;
using ToledoExpo.Services.Core.Interfaces.Repositories;
using ToledoExpo.Services.Core.Services;
using ToledoExpo.Services.Domain.Entities;
using ToledoExpo.Services.Domain.Interfaces.Services;

namespace ToledoExpo.Services.Application.Services;

public class AtendenteService : ServiceBase<Atendente>, IAtendenteService
{
    public AtendenteService(IServiceProvider serviceProvider, IRepository<Atendente> repoBase) : base(serviceProvider, repoBase)
    {
    }
}