using MoviesRental.Core.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRental.Application.Features.Dvds.Commands.CreateDvd
{
    public record CreateDvdResponse(
        string Id,
        string Title,
        string Genre,
        DateTime Published,
        bool Available,
        int Copies,
        string DirectorId,
        DateTime CreatedAt,
        DateTime UpdatedAt) : IResponse;
}
