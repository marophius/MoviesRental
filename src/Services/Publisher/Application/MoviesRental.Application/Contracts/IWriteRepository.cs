using MoviesRental.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRental.Application.Contracts
{
    public interface IWriteRepository<T> where T : Entity
    {
        Task<bool> Create(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(Guid Id);
        Task<T> Get(Guid Id);
    }
}
