using System.Collections.Generic;
using System.Threading.Tasks;
using ToledoExpo.Services.Core.Interfaces.Services;
using ToledoExpo.Services.Domain.Entities;

namespace ToledoExpo.Services.Domain.Interfaces.Services;

public interface IEstabelecimentoService : IService<Estabelecimento>
{
    Task<IEnumerable<Estabelecimento>> Listar(Estabelecimento filter = null);

    Task<Estabelecimento> Obter(Estabelecimento filter = null);

    Task<Estabelecimento> Cadastrar(Estabelecimento obj);
}