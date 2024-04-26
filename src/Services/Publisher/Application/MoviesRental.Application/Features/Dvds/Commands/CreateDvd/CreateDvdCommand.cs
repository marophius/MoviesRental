using MediatR;
using MoviesRental.Core.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRental.Application.Features.Dvds.Commands.CreateDvd
{
    public record CreateDvdCommand(
        string Title,
        int Genre,
        DateTime Published,
        int Copies,
        Guid DirectorId) : ICommand, IRequest<CreateDvdResponse>;
}
