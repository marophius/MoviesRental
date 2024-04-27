using MoviesRental.Query.Application.Features.Dvds.Queries.GetDvd;

namespace MoviesRental.Api.Cache
{
    public interface ICacheRepository
    {
        Task<GetDvdResponse> Get(string title);
        Task Update(GetDvdResponse response);
    }
}
