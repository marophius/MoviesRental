using MoviesRental.Query.Application.Contracts;
using MoviesRental.Query.Domain.Models;
using MoviesRental.Query.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace MoviesRental.Query.Infrastructure.Repositories
{
    public class DvdsQueryRepository : IDvdsQueryRepository
    {
        private readonly IMoviesRentalReadContext _context;

        public DvdsQueryRepository(IMoviesRentalReadContext context)
        {
            _context = context;
        }

        public async Task<Dvd> Create(Dvd entity)
        {
            await _context
                          .Dvds
                          .InsertOneAsync(entity);
            return entity;
        }

        public async Task<bool> Delete(string id)
        {
            var result = await _context
                                       .Dvds
                                       .DeleteOneAsync(p => p.Id == id);

            return result.IsAcknowledged && result.DeletedCount > 0;
        }

        public async Task<Dvd> Get(string id) =>
            await _context
                          .Dvds
                          .Find(p => p.Id == id)
                          .FirstOrDefaultAsync();   

        public async Task<Dvd> GetByTitle(string title) =>
            await _context
            .Dvds
            .Find(p => p.Title == title)
            .FirstOrDefaultAsync();

        public async Task<bool> Update(Dvd entity)
        {
            var result = await _context
                                       .Dvds
                                       .ReplaceOneAsync(d => d.Id == entity.Id, entity);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }
    }
}
