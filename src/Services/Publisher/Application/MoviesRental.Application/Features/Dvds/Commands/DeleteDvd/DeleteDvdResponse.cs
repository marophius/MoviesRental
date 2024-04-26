using MoviesRental.Core.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRental.Application.Features.Dvds.Commands.DeleteDvd
{
    public record DeleteDvdResponse(string Id, DateTime DeletedAt) : IResponse;
}
