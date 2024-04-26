using MediatR;
using MoviesRental.Core.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRental.Query.Application.Features.Dvds.Commands.RentDvd
{
    public record RentDvdCommand(string Id, DateTime UpdatedAt) : ICommand, IRequest<bool>;
}
