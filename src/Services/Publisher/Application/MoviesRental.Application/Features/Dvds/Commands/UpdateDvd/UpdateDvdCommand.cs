using MediatR;
using MoviesRental.Core.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRental.Application.Features.Dvds.Commands.UpdateDvd
{
    public record UpdateDvdCommand(Guid Id,
                                    string Title,
                                    int Genre,
                                    DateTime Published,
                                    Guid DirectorId,
                                    int Copies) : ICommand, IRequest<UpdateDvdResponse>;
}
