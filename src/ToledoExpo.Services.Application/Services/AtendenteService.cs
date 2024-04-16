using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LinqKit;
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

    public async Task<IEnumerable<Atendente>> Listar(Atendente filter = null)
    {
        if (filter is null)
            return await GetList();
        
        Expression<Func<Atendente, bool>> predicate = PredicateBuilder.New<Atendente>(true);

        if (!string.IsNullOrEmpty(filter.Nome))
            predicate = predicate.And(x => x.Nome.Contains(filter.Nome));

        if (filter.Estabelecimento > 0)
            predicate = predicate.And(x => x.Estabelecimento == filter.Estabelecimento);

        return await GetList(predicate);
    }

    public async Task<Atendente> Obter(Atendente filter = null)
    {
        Expression<Func<Atendente, bool>> predicate = PredicateBuilder.New<Atendente>(true);

        if (filter?.Id > 0)
            predicate = predicate.And(x => x.Id == filter.Id);

        if (!string.IsNullOrEmpty(filter?.Nome))
            predicate = predicate.And(x => x.Nome.Contains(filter.Nome));

        if (filter?.Estabelecimento > 0)
            predicate = predicate.And(x => x.Estabelecimento == filter.Estabelecimento);

        return await GetSingle(predicate);
    }

    public async Task<Atendente> Cadastrar(Atendente obj)
    {
        if (obj is null)
            return default;

        obj.Novo();

        return await Save(obj);
    }
}