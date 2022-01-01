using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DbToJSON.Repositories
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> GetAsync(Guid id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);  
        Task DeleteAsync(T entity);  
    }
}
