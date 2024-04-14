using ToledoExpo.Services.Core.Entities;

namespace ToledoExpo.Services.Core.Interfaces.Services;

public interface IService
{
    
}

public interface IService<T> where T : Entity
{
    
}