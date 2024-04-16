using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
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

    public async Task<IEnumerable<Estabelecimento>> Listar(Estabelecimento filter = null)
    {
        if (filter is null)
            return await GetList();

        Expression<Func<Estabelecimento, bool>> predicate = PredicateBuilder.New<Estabelecimento>(true);

        if (!string.IsNullOrEmpty(filter.Nome))
            predicate = predicate.And(x => x.Nome.Contains(filter.Nome));

        if (!string.IsNullOrEmpty(filter.Proprietario))
            predicate = predicate.And(x => x.Proprietario.Contains(filter.Proprietario));

        if (!string.IsNullOrEmpty(filter.Descricao))
            predicate = predicate.And(x => x.Descricao.Contains(filter.Descricao));

        return await GetList(predicate);
    }

    public async Task<Estabelecimento> Obter(Estabelecimento filter = null)
    {
        Expression<Func<Estabelecimento, bool>> predicate = PredicateBuilder.New<Estabelecimento>(true);

        if (filter?.Id > 0)
            predicate = predicate.And(x => x.Id == filter.Id);

        if (!string.IsNullOrEmpty(filter?.Nome))
            predicate = predicate.And(x => x.Nome.Contains(filter.Nome));

        if (!string.IsNullOrEmpty(filter?.Proprietario))
            predicate = predicate.And(x => x.Proprietario.Contains(filter.Proprietario));

        if (!string.IsNullOrEmpty(filter?.Descricao))
            predicate = predicate.And(x => x.Descricao.Contains(filter.Descricao));

        return await GetSingle(predicate);
    }

    public async Task<Estabelecimento> Cadastrar(Estabelecimento obj)
    {
        if (obj is null)
            return default;

        obj.Novo();

        return await Save(obj);
    }
}