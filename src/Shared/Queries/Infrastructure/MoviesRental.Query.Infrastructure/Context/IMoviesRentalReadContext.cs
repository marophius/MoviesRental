using MongoDB.Driver;
using MoviesRental.Query.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRental.Query.Infrastructure.Context
{
    public interface IMoviesRentalReadContext
    {
        IMongoCollection<Dvd> Dvds { get; }
        IMongoCollection<Director> Directors { get; }
    }
}
