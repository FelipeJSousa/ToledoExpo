using System.Collections.Generic;
using System.Threading.Tasks;
using ToledoExpo.Services.Core.Interfaces.Services;
using ToledoExpo.Services.Domain.Entities;

namespace ToledoExpo.Services.Domain.Interfaces.Services;

public interface IAtendenteService : IService<Atendente>
{
    Task<IEnumerable<Atendente>> Listar(Atendente filter = null);

    Task<Atendente> Obter(Atendente filter = null);

    Task<Atendente> Cadastrar(Atendente obj);
}