using Microsoft.Extensions.DependencyInjection;
using MoviesRental.Application.Contracts;
using MoviesRental.Infrastructure.Context;
using MoviesRental.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRental.Infrastructure
{
    public static class InfrastructureServiceCollection
    {
        public static void AddWriteInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<MoviesRentalWriteContext>();
            services.AddScoped<IDvdsWriteRepository, DvdWriteRepository>();
            services.AddScoped<IDirectorsWriteRepository, DirectorWriteRepository>();
        }
    }
}
