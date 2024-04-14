using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using ToledoExpo.Services.Core.Entities;

namespace ToledoExpo.Services.Core.Interfaces.Services;

public interface IService
{
    
}

public interface IService<TEntity> where TEntity : Entity
{

    public Task<TEntity> Save(TEntity obj, bool forced = false, bool ignoreQueryFilter = false);

    public Task<TEntity> Delete(long id, bool forced = false);

    public Task<TEntity> Delete(TEntity obj, bool forced = false);

    public Task<TEntity> FindById(long id,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);

    public Task<TEntity> GetSingle(Expression<Func<TEntity, bool>> predicate = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);

    public Task<IEnumerable<TEntity>> GetList(Expression<Func<TEntity, bool>> predicate = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);

    public Task<TEntity> SaveTransaction(TEntity obj, bool ignoreQueryFilter = false);

    public Task<TEntity> DeleteTransaction(TEntity obj);

}