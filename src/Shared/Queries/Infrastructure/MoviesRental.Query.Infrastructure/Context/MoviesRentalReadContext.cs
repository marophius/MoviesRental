using MongoDB.Driver;
using MoviesRental.Query.Domain.Models;
using MoviesRental.Query.Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRental.Query.Infrastructure.Context
{
    public class MoviesRentalReadContext : IMoviesRentalReadContext
    {
        public MoviesRentalReadContext(MongoDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            Dvds = database.GetCollection<Dvd>(settings.DvdsCollection);
            Directors = database.GetCollection<Director>(settings.DirectorsCollection);
        }
        public IMongoCollection<Dvd> Dvds { get; }

        public IMongoCollection<Director> Directors {  get; }
    }
}
