using Microsoft.Extensions.DependencyInjection;
using MoviesRental.Query.Application.Contracts;
using MoviesRental.Query.Infrastructure.Context;
using MoviesRental.Query.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRental.Query.Infrastructure
{
    public static class InfrastructureServiceCollection
    {
        public static IServiceCollection AddQueryInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IMoviesRentalReadContext, MoviesRentalReadContext>();
            services.AddScoped<IDirectorsQueryRepository, DirectorsQueryRepository>();
            services.AddScoped<IDvdsQueryRepository, DvdsQueryRepository>();

            return services;
        }
    }
}
