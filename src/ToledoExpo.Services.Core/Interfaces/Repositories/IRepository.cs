using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using ToledoExpo.Services.Core.Entities;

namespace ToledoExpo.Services.Core.Interfaces.Repositories;

public interface IRepository<T> where T : Entity
{
    public Task<T> Create(T entity);
    
    public T GetById(long id);
    
    public Task<T> Get(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
    
    public Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);

    public Task<T> Update(T entity);
    
    public Task<T> Delete(T entity);

    public bool Commit();
}