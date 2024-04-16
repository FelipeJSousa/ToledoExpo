using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToledoExpo.Services.Core.Interfaces.Repositories;
using ToledoExpo.Services.Core.Services;
using ToledoExpo.Services.Domain.Entities;
using ToledoExpo.Services.Domain.Interfaces.Services;

namespace ToledoExpo.Services.Application.Services;

public class AtendimentoService : ServiceBase<Atendimento>, IAtendimentoService
{
    private readonly IAtendenteService _AtendenteService;
    
    public AtendimentoService(IServiceProvider serviceProvider, IRepository<Atendimento> repoBase, IAtendenteService atendenteService) : base(serviceProvider, repoBase)
    {
        _AtendenteService = atendenteService;
    }

    public async Task<IEnumerable<Atendente>> ObterFilaVazia()
    {
        var _list = await GetList();
        
        if(_list?.Any() == false)
        {
            return await _AtendenteService.GetList();
        }
        
        var _group =  _list.GroupBy(x => x.AtendenteObj);
            
        return _group.Where(x => x.All(y => y.ObterSituacao() == AtendimentoSituacao.Finalizado)).Select(x => x.Key);
    }

    public async Task<Atendente> ObterPorMenorFila()
    {
        var _list = await ObterPendentes();
        return _list.FirstOrDefault()?.AtendenteObj;
    }

    public async Task<IEnumerable<Atendimento>> ObterPendentes()
    {
        return await GetList(
            predicate: x => x.DataInicioAtendimento > DateTime.Now, 
            orderBy: x => x.OrderByDescending(y => y.DataInicioAtendimento));
    }
    
}