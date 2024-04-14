using ToledoExpo.Services.Core.Interfaces.Repositories;
using ToledoExpo.Services.Domain.Entities;
using ToledoExpo.Services.Domain.Interfaces.Services;

namespace ToledoExpo.Services.Application.Services;

public class AtendenteService : IAtendenteService
{
    private IRepository<Atendente> _Repo;
    
    public AtendenteService(IRepository<Atendente> repo)
    {
        _Repo = repo;
    }
}