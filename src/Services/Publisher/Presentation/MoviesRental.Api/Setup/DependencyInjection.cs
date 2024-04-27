using MoviesRental.Application;
using MoviesRental.Infrastructure;
using MoviesRental.Query.Infrastructure;
using MoviesRental.Query.Application;
using MoviesRental.Api.Cache;
using MoviesRental.Core.Mediator;

namespace MoviesRental.Api.Setup
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddWriteApplication();
            services.AddWriteInfrastructure();
            services.AddQueryApplication();
            services.AddQueryInfrastructure();
            services.AddScoped<ICacheRepository, CacheRepository>();
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            return services;
        }
    }
}
