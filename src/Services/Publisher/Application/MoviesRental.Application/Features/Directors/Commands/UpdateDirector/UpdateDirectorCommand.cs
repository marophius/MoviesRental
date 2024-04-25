using MediatR;
using MoviesRental.Core.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRental.Application.Features.Directors.Commands.UpdateDirector
{
    public record UpdateDirectorCommand(Guid Id,
                                         string Name,
                                         string Surname) : ICommand, IRequest<UpdateDirectorResponse>;
}
