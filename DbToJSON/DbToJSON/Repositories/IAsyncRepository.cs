using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbToJSON.Repositories
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> GetAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync(); 
        Task DeleteAsync(Guid id);  
            
    }
}
