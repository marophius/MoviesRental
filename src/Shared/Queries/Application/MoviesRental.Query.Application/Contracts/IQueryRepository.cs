using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRental.Query.Application.Contracts
{
    public interface IQueryRepository<T> where T : class
    {
        Task<T> Create(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(string id);
        Task<T> Get(string id);
    }
}
