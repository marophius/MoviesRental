using MoviesRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRental.Application.Contracts
{
    public interface IDirectorsWriteRepository : IWriteRepository<Director>
    {
        Task<Director> GetDirectorWithMovies(Guid Id);
    }
}
