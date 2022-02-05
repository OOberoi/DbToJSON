using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbToJSON.BusinessDomain.Entities;

namespace DbToJSON.Application.Contracts.Persistence
{
    internal interface ICategoryRepository : IAsyncRepository<Category>
    {
    }
}
