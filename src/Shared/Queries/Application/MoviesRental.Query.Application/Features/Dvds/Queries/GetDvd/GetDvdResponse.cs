using MoviesRental.Core.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRental.Query.Application.Features.Dvds.Queries.GetDvd
{
    public record GetDvdResponse(
        string Id,
        string Title,
        string Genre,
        DateTime Published,
        int Copies,
        string DirectorId,
        DateTime CreatedAt,
        DateTime UpdatedAt
        ) : IResponse;
}
