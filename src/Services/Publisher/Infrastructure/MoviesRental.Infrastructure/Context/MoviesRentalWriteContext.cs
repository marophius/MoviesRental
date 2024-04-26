using Microsoft.EntityFrameworkCore;
using MoviesRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRental.Infrastructure.Context
{
    public class MoviesRentalWriteContext : DbContext
    {
        public MoviesRentalWriteContext(DbContextOptions<MoviesRentalWriteContext> options) : base(options)
        {

        }

        public DbSet<Dvd> Dvds { get; set; }
        public DbSet<Director> Directors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MoviesRentalWriteContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
