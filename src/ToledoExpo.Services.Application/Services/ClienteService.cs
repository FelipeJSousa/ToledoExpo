using System;
using ToledoExpo.Services.Core.Interfaces.Repositories;
using ToledoExpo.Services.Core.Services;
using ToledoExpo.Services.Domain.Entities;
using ToledoExpo.Services.Domain.Interfaces.Services;

namespace ToledoExpo.Services.Application.Services;

public class ClienteService : ServiceBase<Cliente>, IClienteService
{
    public ClienteService(IServiceProvider serviceProvider, IRepository<Cliente> repoBase) : base(serviceProvider, repoBase)
    {
    }
}