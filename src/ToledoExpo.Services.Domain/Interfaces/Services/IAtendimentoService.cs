using System.Collections.Generic;
using System.Threading.Tasks;
using ToledoExpo.Services.Core.Interfaces.Services;
using ToledoExpo.Services.Domain.Entities;

namespace ToledoExpo.Services.Domain.Interfaces.Services;

public interface IAtendimentoService : IService<Atendimento>
{
    public Task<IEnumerable<Atendente>> ObterFilaVazia();
    
    public Task<Atendente> ObterPorMenorFila();

    public Task<IEnumerable<Atendimento>> ObterPendentes();

}