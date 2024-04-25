using MediatR;
using MoviesRental.Core.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRental.Application.Features.Directors.Commands.DeleteDirector
{
    public record DeleteDirectorCommand(Guid Id) : ICommand, IRequest<bool>;
}
