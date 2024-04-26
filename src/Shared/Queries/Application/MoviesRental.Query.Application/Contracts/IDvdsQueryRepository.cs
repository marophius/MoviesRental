using MoviesRental.Query.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRental.Query.Application.Contracts
{
    public interface IDvdsQueryRepository : IQueryRepository<Dvd>
    {
        Task<Dvd> GetByTitle(string title);
    }
}
