using MoviesRental.Core.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRental.Application.Features.Directors.Commands.UpdateDirector
{
    public record UpdateDirectorResponse(string Id,
        string FullName,
        DateTime UpdatedAt) : IResponse;
}
