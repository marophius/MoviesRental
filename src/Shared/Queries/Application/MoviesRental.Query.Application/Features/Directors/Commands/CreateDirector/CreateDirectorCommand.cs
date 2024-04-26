using MediatR;
using MoviesRental.Core.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRental.Query.Application.Features.Directors.Commands.CreateDirector
{
    public record CreateDirectorCommand(
        string Id, 
        string FullName, 
        DateTime CreatedAt, 
        DateTime UpdatedAt) : ICommand, IRequest<bool>;
}
