using Microsoft.EntityFrameworkCore;
using MoviesRental.Application.Contracts;
using MoviesRental.Domain.Entities;
using MoviesRental.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRental.Infrastructure.Repositories
{
    public class DirectorWriteRepository : IDirectorsWriteRepository
    {
        private readonly MoviesRentalWriteContext _context;

        public DirectorWriteRepository(MoviesRentalWriteContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(Director entity)
        {
            await _context.Directors.AddAsync(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(Guid Id)
        {
            await _context.Directors
                                    .Where(d => d.Id == Id)
                                    .ExecuteDeleteAsync();
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Director> Get(Guid Id) =>
            await _context.Directors
                                    .FindAsync(Id);

        public async Task<Director> GetDirectorWithMovies(Guid Id) =>
            await _context.Directors.AsNoTracking()
                                    .Include(d => d.Dvds)
                                    .Where(d => d.Id == Id)
                                    .FirstOrDefaultAsync();

        public async Task<bool> Update(Director entity)
        {
            _context.Directors.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
