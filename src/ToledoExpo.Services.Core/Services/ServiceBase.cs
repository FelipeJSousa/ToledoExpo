using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.DependencyInjection;
using ToledoExpo.Services.Core.Entities;
using ToledoExpo.Services.Core.Interfaces.Repositories;
using ToledoExpo.Services.Core.Interfaces.Services;
using ToledoExpo.Services.Core.ValueObjects;

namespace ToledoExpo.Services.Core.Services;

public abstract class ServiceBase : IService
{
    private readonly IMapper _Mapper;
    protected readonly INotificationService Notifications;

    #region Constructor

    protected ServiceBase(IServiceProvider serviceProvider)
    {
        _Mapper = serviceProvider.GetService<IMapper>()!;
        Notifications = serviceProvider.GetService<INotificationService>()!;
    }

    #endregion
    
    #region Mapper

    protected TDestination Mapear<TDestination>(object origem)
    {
        return _Mapper.Map<TDestination>(origem);
    }

    protected TDestination Merge<TDestination>(TDestination destino, object origem)
    {
        return _Mapper.Map(origem, destino);
    }

    protected TDestination MergeInto<TDestination>(TDestination destino, object origem)
    {
        return _Mapper.Map(origem, Mapear<TDestination>(destino));
    }

    #endregion

    #region Notification

    protected void NewNotification(string key, string message, NotificationType notificationType = NotificationType.Error)
    {
        Notifications.NewNotification(key, message, notificationType);
    }

    protected bool HasNotificationsErrors()
    {
        return Notifications.HasNotificationsErrors();
    }

    #endregion
}

public abstract class ServiceBase<TEntity> : ServiceBase, IService<TEntity> where TEntity : Entity
{
    private readonly IRepository<TEntity> _RepoBase;

    protected ServiceBase(IServiceProvider serviceProvider, IRepository<TEntity> repoBase) : base(serviceProvider)
    {
        _RepoBase = repoBase;
    }

    public virtual async Task<TEntity> Save(TEntity obj, bool forced = false)
    {
        var _retorno = await SaveTransaction(obj);

        await Commit(forced);

        return _retorno;
    }

    public async Task<TEntity> Delete(long id, bool forced = false)
    {
        var _obj = await GetSingle(x => x.Id == id);
        
        await DeleteTransaction(_obj);
        
        await Commit(forced);
        
        return _obj;
    }

    public virtual async Task<TEntity> Delete(TEntity obj, bool forced = false)
    {
        if (obj is null) 
            return default;
        
        await DeleteTransaction(obj);

        await Commit(forced);
        
        return obj;
    }

    public virtual async Task<TEntity> FindById(long id,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
    {
        if (id <= 0) return default;

        var _item = await _RepoBase.Get(x => x.Id == id, include, orderBy);
        return await Task.FromResult(_item);
    }

    public virtual async Task<TEntity> GetSingle(Expression<Func<TEntity, bool>> predicate = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
    {
        var _item = await _RepoBase.Get(predicate, include, orderBy);
        return await Task.FromResult(_item);
    }

    public virtual async Task<IEnumerable<TEntity>> GetList(Expression<Func<TEntity, bool>> predicate = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
    {
        var _lista = await _RepoBase.GetAll(predicate, include, orderBy);
        return await Task.FromResult(_lista);
    }

    public virtual async Task<TEntity> SaveTransaction(TEntity obj)
    {
        if (obj is null)
        {
            NewNotification("Objeto", "Objeto não encontrado");
            return null;
        }

        if (obj.Id > 0)
            obj = await Update(obj);
        else
            obj = await Add(obj);

        return await Task.FromResult(obj);
    }
    
    
    protected virtual async Task<TEntity> Add(TEntity obj)
    {
        await _RepoBase.Create(obj);

        return await Task.FromResult(obj);
    }

    public virtual async Task<TEntity> DeleteTransaction(TEntity obj)
    {
        if (obj == null)
        {
            NewNotification(typeof(TEntity).Name, "Objeto não encontrado.");
            return default;
        }

        await _RepoBase.Delete(obj);

        return await Task.FromResult(obj);
    }

    protected virtual async Task<TEntity> Update(TEntity obj)
    {
        var _objExistente = await FindById(obj.Id);
        if (_objExistente == null)
        {
            NewNotification("Registro", "Registro não encontrado.");
            return obj;
        }

        var _objMerge = MergeInto(_objExistente, obj);

        await _RepoBase.Update(_objMerge);

        return _objMerge;
    }

    #region UoW

    protected async Task<bool> Commit(bool forced = false)
    {
        if (!forced && HasNotificationsErrors()) return await Task.FromResult(false);

        if (_RepoBase.Commit()) return await Task.FromResult(true);

        NewNotification("Commit", "Ocorreu um erro ao salvar os dados no banco de dados");
        return await Task.FromResult(false);
    }

    #endregion
}

